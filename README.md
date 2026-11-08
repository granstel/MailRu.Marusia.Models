# MailRu.Marusia.Models

Models for Marusia from Mail.ru

Install
-------
It's available via [nuget package](https://www.nuget.org/packages/MailRu.Marusia.Models/)
PM> `Install-Package MailRu.Marusia.Models`

JSON serialization in 2.x
-------------------------

Use `System.Text.Json.JsonSerializer` to read `InputModel` and write `OutputModel`. The SDK preserves the protocol field names, card type strings, and state keys with the default serializer options.

Read scalar state values with `TryGetFromSessionState<T>` or `TryGetFromUserState<T>`. JSON integers become `long` (or `BigInteger` outside its range) and fractional numbers become `double`. Untyped JSON objects and arrays in state, entity values, and button payloads are exposed as `JsonElement`.

Use the protocol casing when reading JSON. To accept different casing for model fields, set `JsonSerializerOptions.PropertyNameCaseInsensitive`.

Development
-----------

From the repository root, run `dotnet test MailRu.Marusia.Models.slnx -c Release` with the SDK pinned in `global.json`.

Create a package with `dotnet pack src/MailRu.Marusia.Models.csproj -c Release`.
