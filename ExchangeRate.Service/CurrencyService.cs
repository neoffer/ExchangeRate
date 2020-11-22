using System;
using ExchangeRate.Model;
using ExchangeRate.Data;
using ExchangeRate.Infrastructure;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExchangeRate.Service
{
    public class CurrencyService:ICurrencyService
    {
        private readonly ICurrencyRepository repository;
        public CurrencyService(ICurrencyRepository repository)
        {
            this.repository = repository;
        }
        public bool Load()
        {
            return repository.Load();
        }

        public IList<Currency> GetCurrencies()
        {
            return repository.GetCurrencies();
        }

        public IList<Currency> GetCurrencies(Expression<Func<Currency, object>> orderby, bool desc)
        {
            return repository.GetCurrencies(orderby, desc);
        }

        public IList<Currency> GetCurrencies(Func<Currency, bool> where)
        {
            return repository.GetCurrencies(where);
        }

        public IList<Currency> GetCurrencies(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc)
        {
            return repository.GetCurrencies(where, orderby, desc);
        }

        public string ExportToXml(IList<Currency> currencies)
        {
            IExporter exporter = new XmlExporter();
            return exporter.Export(currencies);
        }

        public string ExportToCsv(IList<Currency> currencies)
        {
            IExporter exporter = new CsvExporter();
            return exporter.Export(currencies);
        }

        public dynamic ExportToCustomFormat(IList<Currency> currencies, IExporter exporter)
        {
            return exporter.Export(currencies);
        }
    }
}
