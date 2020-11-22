using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExchangeRate.Data;
using ExchangeRate.Model;
using ExchangeRate.Service;

namespace ExchangeRate.Api
{
    public class TcmbExchangeRate
    {
        private readonly ICurrencyService service;
        private readonly IContext context;
        private readonly ICurrencyRepository repository;
        public TcmbExchangeRate()
        {
            this.context = new TcmbContext();
            this.repository = new CurrencyRepository(context);
            this.service = new CurrencyService(repository);
        }

        public bool Load()
        {
            return service.Load();
        }

        public IList<Currency> GetCurrencies()
        {
            return service.GetCurrencies();
        }

        public IList<Currency> GetCurrencies(Expression<Func<Currency, object>> orderby, bool desc)
        {
            return service.GetCurrencies(orderby, desc);
        }

        public IList<Currency> GetCurrencies(Func<Currency, bool> where)
        {
            return service.GetCurrencies(where);
        }

        public IList<Currency> GetCurrencies(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc)
        {
            return service.GetCurrencies(where, orderby, desc);
        }

        public string ExportToXml(IList<Currency> currencies)
        {
            return service.ExportToXml(currencies);
        }

        public string ExportToCsv(IList<Currency> currencies)
        {
            return service.ExportToCsv(currencies);
        }

        public dynamic ExportToCustomFormat(IList<Currency> currencies, IExporter exporter)
        {
            return service.ExportToCustomFormat(currencies, exporter);
        }

        public string GetCurrenciesAsXml(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc)
        {
            return service.ExportToXml(service.GetCurrencies(where, orderby, desc));
        }

        public string GetCurrenciesAsCsv(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc)
        {
            return service.ExportToCsv(service.GetCurrencies(where, orderby, desc));
        }

        public dynamic GetCurrenciesAsCustomFormat(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc, IExporter exporter)
        {
            return service.ExportToCustomFormat(service.GetCurrencies(where, orderby, desc), exporter);
        }
    }
}
