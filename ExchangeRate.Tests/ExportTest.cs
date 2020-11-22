using System;
using Xunit;
using ExchangeRate.Api;
namespace ExchangeRate.Tests
{
    public class ExportTest
    {
        [Fact]
        public void ExportToJson()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();

            var currencies = exchangeRate.GetCurrencies();

            var jsonExporter = new JsonExporter();
            string result = exchangeRate.ExportToCustomFormat(currencies, jsonExporter);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void ExportToXml()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();

            var currencies = exchangeRate.GetCurrencies();

            string result = exchangeRate.ExportToXml(currencies);

            Assert.NotEmpty(result);
        }

        [Fact]
        public void ExportToCsv()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();

            var currencies = exchangeRate.GetCurrencies();

            string result = exchangeRate.ExportToCsv(currencies);

            Assert.NotEmpty(result);
        }
    }
}
