using System;
using Xunit;
using ExchangeRate.Api;
using System.Linq;

namespace ExchangeRate.Tests
{
    public class CurrencyTest
    {
        public CurrencyTest()
        {
        }

        [Fact]
        public void Load()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();
            var currencies = exchangeRate.GetCurrencies();
            Assert.Equal("20", currencies.Count.ToString());
        }

        [Fact]
        public void Where()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();
            var currency = exchangeRate.GetCurrencies(w => w.CurrencyCode == "USD").FirstOrDefault();
            Assert.Equal("7.5785", currency.ForexBuying.ToString());
        }

        [Fact]
        public void OrderBy()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();
            var currency = exchangeRate.GetCurrencies(o => o.CrossOrder, false).FirstOrDefault();
            Assert.Equal("USD", currency.CurrencyCode.ToString());
        }

        [Fact]
        public void OrderByDescending()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();
            var currency = exchangeRate.GetCurrencies(o => o.CrossOrder, false).FirstOrDefault();
            Assert.Equal("USD", currency.CurrencyCode.ToString());
        }

        [Fact]
        public void WhereOrderBy()
        {
            var exchangeRate = new TcmbExchangeRate();
            exchangeRate.Load();
            var currency = exchangeRate.GetCurrencies(w => w.Unit == 1, o => o.CrossOrder, false).FirstOrDefault();
            Assert.Equal("USD", currency.CurrencyCode.ToString());
        }
    }
}
