﻿using System.Collections.Generic;

namespace MailRu.Marusia.Models
{
    public class State : Dictionary<string, object>
    {
        public bool TryGetValue<T>(string key, out T result)
        {
            result = default;

            var success = base.TryGetValue(key, out object resultObject);

            if (!success)
            {
                return false;
            }

            if (!(resultObject is T castedResult))
            {
                return false;
            }

            result = castedResult;

            return true;
        }
    }
}
