using System;
using System.Collections.Generic;
using ExchangeRate.Model;

namespace ExchangeRate.Infrastructure
{
    public class CsvExporter:IExporter
    {
        public CsvExporter()
        {
        }

        public dynamic Export(IList<Currency> currencies)
        {
            return ServiceStack.Text.CsvSerializer.SerializeToCsv(currencies);
        }
    }
}
