using System;
using System.Collections.Generic;
using ExchangeRate.Model;
using Newtonsoft.Json;

namespace ExchangeRate.Tests
{
    public class JsonExporter:ExchangeRate.Api.IExporter
    {
        public JsonExporter()
        {
        }

        public dynamic Export(IList<Currency> currencies)
        {
            return JsonConvert.SerializeObject(currencies);
        }
    }
}
