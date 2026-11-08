using System.Linq;
using System.Numerics;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using MailRu.Marusia.Models.Buttons;
using MailRu.Marusia.Models.Cards;
using MailRu.Marusia.Models.Input;
using Xunit;

namespace MailRu.Marusia.Models.Tests;

public class JsonContractTests
{
    [Fact]
    public void ReadsAndWritesTheInputEnvelope()
    {
        const string json = """
            {
              "meta": {
                "locale": "ru-RU", "timezone": "Europe/Moscow", "client_id": "client",
                "interfaces": { "screen": {}, "payments": {} }
              },
              "request": {
                "original_utterance": "два", "command": "два", "type": "SimpleUtterance",
                "nlu": { "entities": [
                  { "tokens": { "start": 0, "end": 1 }, "type": "number", "value": 2 },
                  { "tokens": { "start": 1, "end": 2 }, "type": "other", "value": { "NestedKey": [true, null] } }
                ] }
              },
              "session": {
                "new": true, "skill_id": "skill", "session_id": "session", "message_id": 7, "user_id": "user",
                "user": { "user_id": "user" },
                "application": { "application_id": "app", "application_type": "speaker" }
              },
              "state": {
                "session": { "ShowHint": true, "Index": 42, "MissingValue": null, "NestedKey": { "Values": [1, false] } },
                "user": { "Locale": "ru", "Rate": 0.5, "LargeIndex": 9223372036854775808 }
              },
              "version": "1.0"
            }
            """;

        var model = SdkJson.Read<InputModel>(json);

        Assert.True(model.Session.New);
        Assert.Equal("skill", model.Session.SkillId);
        Assert.Equal(7, model.Session.MessageId);
        Assert.Equal(ApplicationTypes.Speaker, model.Session.Application.ApplicationType);
        Assert.Equal("два", model.Request.OriginalUtterance);
        Assert.Equal(2L, Assert.IsType<long>(model.Request.Nlu.Entities.First().Value));
        Assert.NotNull(model.Meta.Interfaces.Screen);
        Assert.NotNull(model.Meta.Interfaces.Payments);
        Assert.True(model.TryGetFromSessionState<bool>("ShowHint", out var showHint));
        Assert.True(showHint);
        Assert.True(model.TryGetFromSessionState<long>("Index", out var index));
        Assert.Equal(42L, index);
        Assert.True(model.TryGetFromUserState<string>("Locale", out var locale));
        Assert.Equal("ru", locale);
        Assert.True(model.TryGetFromUserState<double>("Rate", out var rate));
        Assert.Equal(0.5, rate);
        Assert.True(model.TryGetFromUserState<BigInteger>("LargeIndex", out var largeIndex));
        Assert.Equal(BigInteger.Parse("9223372036854775808"), largeIndex);
        Assert.False(model.TryGetFromSessionState<int>("Index", out _));
        Assert.False(model.TryGetFromSessionState<bool>("show_hint", out _));
        Assert.False(model.TryGetFromSessionState<object>("MissingValue", out _));

        AssertJson(json, SdkJson.Write(model));
    }

    [Theory]
    [InlineData("{}")]
    [InlineData("""{"state":null}""")]
    [InlineData("""{"state":{"session":null,"user":null}}""")]
    [InlineData("""{"state":{"session":{},"user":{}}}""")]
    public void MissingStateReturnsFalseAndTheDefaultValue(string json)
    {
        var model = SdkJson.Read<InputModel>(json);

        Assert.False(model.TryGetFromSessionState<bool>("key", out var flag));
        Assert.False(flag);
        Assert.False(model.TryGetFromUserState<string>("key", out var text));
        Assert.Null(text);
    }

    [Fact]
    public void WritesTheOutputEnvelope()
    {
        var model = new OutputModel
        {
            Response = new Response
            {
                Text = "ответ",
                Tts = "отв+ет",
                EndSession = true,
                Buttons = new[]
                {
                    new ResponseButton
                    {
                        Title = "Дальше",
                        Hide = true,
                        Payload = new { ActionKey = "next" }
                    }
                }
            },
            Session = new Session { SessionId = "session", MessageId = 7 },
            Version = "1.0"
        };
        model.AddToSessionState("ShowHint", false);
        model.AddToUserState("LastIndex", 3);
        model.AddToUserState("Cleared", null);

        const string expected = """
            {
              "response": {
                "text": "ответ", "tts": "отв+ет", "end_session": true, "card": null,
                "buttons": [{ "title": "Дальше", "hide": true, "payload": { "ActionKey": "next" }, "url": null }]
              },
              "session": { "session_id": "session", "message_id": 7, "user_id": null, "user": null, "application": null },
              "session_state": { "ShowHint": false },
              "user_state_update": { "LastIndex": 3, "Cleared": null },
              "version": "1.0"
            }
            """;

        AssertJson(expected, SdkJson.Write(model));
        var read = SdkJson.Read<OutputModel>(expected);
        Assert.True(read.SessionState.TryGetValue<bool>("ShowHint", out var hint));
        Assert.False(hint);
        Assert.True(read.UserStateUpdate.TryGetValue<long>("LastIndex", out var lastIndex));
        Assert.Equal(3L, lastIndex);
        AssertJson(expected, SdkJson.Write(read));
    }

    [Theory]
    [MemberData(nameof(Cards))]
    public void WritesConcreteCardFieldsAndExactDiscriminator(ICard card, string expected)
    {
        var response = JsonNode.Parse(SdkJson.Write(new Response { Card = card }));

        AssertJson(expected, response["card"].ToJsonString());
        AssertJson(expected, SdkJson.Write(card));
        AssertJson(expected, SdkJson.Write<object>(card));
    }

    [Theory]
    [InlineData(CardType.BigImage, "BigImage")]
    [InlineData(CardType.ItemsList, "ItemsList")]
    [InlineData(CardType.MiniApp, "MiniApp")]
    [InlineData(CardType.Link, "Link")]
    public void ReadsAndWritesCardType(CardType type, string name)
    {
        Assert.Equal(type, SdkJson.Read<CardType>($"\"{name}\""));
        Assert.Equal($"\"{name}\"", SdkJson.Write(type));
    }

    [Fact]
    public void PreservesSdkNamesForStandaloneModelsAndBaseTypes()
    {
        AssertJson("""{"first_name":"example","last_name":null,"patronymic_name":null}""",
            SdkJson.Write(new EntityValue { FirstName = "example" }));
        AssertJson("""{"text":"button","payload":null,"url":"https://example.org"}""",
            SdkJson.Write<Button>(new CardButton { Text = "button", Url = "https://example.org" }));
        AssertJson("""{"type":"BigImage","image_id":1}""",
            SdkJson.Write<CardItem>(new BigImageCard { ImageId = 1 }));
        AssertJson("""
            {"new":true,"skill_id":"skill","session_id":null,"message_id":0,"user_id":null,"user":null,"application":null}
            """, SdkJson.Write<Session>(new InputSession { New = true, SkillId = "skill" }));
    }

    [Fact]
    public void WritesAnExternalCardImplementation()
    {
        var response = new Response { Card = new CustomCard() };
        var json = JsonNode.Parse(SdkJson.Write(response));

        AssertJson("""{"type":"Link","customField":"custom"}""", json["card"].ToJsonString());
    }

    private sealed class CustomCard : ICard
    {
        public CardType Type => CardType.Link;

        [JsonPropertyName("customField")]
        public string CustomField => "custom";
    }

    public static TheoryData<ICard, string> Cards => new()
    {
        { new BigImageCard { ImageId = 1 }, """{"type":"BigImage","image_id":1}""" },
        { new ItemsListCard { Items = new[] { new CardItem { ImageId = 2 } } }, """{"type":"ItemsList","items":[{"image_id":2}]}""" },
        { new MiniAppCard { Url = "https://example.org/mini" }, """{"type":"MiniApp","url":"https://example.org/mini"}""" },
        { new LinkCard { ImageId = 3, Url = "https://example.org", Title = "title", Text = "text" },
            """{"type":"Link","url":"https://example.org","title":"title","text":"text","image_id":3}""" }
    };

    private static void AssertJson(string expected, string actual)
    {
        Assert.True(JsonNode.DeepEquals(JsonNode.Parse(expected), JsonNode.Parse(actual)), actual);
    }
}
