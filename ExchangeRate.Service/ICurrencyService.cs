using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExchangeRate.Infrastructure;
using ExchangeRate.Model;

namespace ExchangeRate.Service
{
    public interface ICurrencyService
    {
        bool Load();

        IList<Currency> GetCurrencies();

        IList<Currency> GetCurrencies(Expression<Func<Currency, object>> orderby, bool desc);

        IList<Currency> GetCurrencies(Func<Currency, bool> where);

        IList<Currency> GetCurrencies(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc);

        string ExportToXml(IList<Currency> currencies);

        string ExportToCsv(IList<Currency> currencies);

        dynamic ExportToCustomFormat(IList<Currency> currencies, IExporter exporter);
    }
}
