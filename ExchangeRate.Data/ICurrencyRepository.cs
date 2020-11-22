using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ExchangeRate.Model;

namespace ExchangeRate.Data
{
    public interface ICurrencyRepository
    {
        bool Load();

        IList<Currency> GetCurrencies();

        IList<Currency> GetCurrencies(Expression<Func<Currency, object>> orderby, bool desc);

        IList<Currency> GetCurrencies(Func<Currency, bool> where);

        IList<Currency> GetCurrencies(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc);
    }
}
