using System;
using System.Collections.Generic;
using ExchangeRate.Model;
using System.Linq;
using System.Linq.Expressions;

namespace ExchangeRate.Data
{
    public class CurrencyRepository:ICurrencyRepository
    {
        private readonly IContext context;
        private readonly IList<Currency> currencies;
        public CurrencyRepository(IContext context)
        {
            this.context = context;
            this.currencies = context.Currencies;
        }

        public bool Load()
        {
            return context.Load();
        }

        public IList<Currency> GetCurrencies()
        {
            return currencies.ToList();
        }

        public IList<Currency> GetCurrencies(Expression<Func<Currency, object>> orderby, bool desc)
        {
            if (desc == false)
            {
                return currencies.AsQueryable().OrderBy(orderby).ToList();
            } else
            {
                return currencies.AsQueryable().OrderByDescending(orderby).ToList();
            }
            
        }

        public IList<Currency> GetCurrencies(Func<Currency, bool> where)
        { 
            return currencies.Where(where).ToList();
        }

        public IList<Currency> GetCurrencies(Func<Currency, bool> where, Expression<Func<Currency, object>> orderby, bool desc)
        {
            if (desc == false)
            {
                return currencies.Where(where).AsQueryable().OrderBy(orderby).ToList();
            } else
            {
                return currencies.Where(where).AsQueryable().OrderByDescending(orderby).ToList();
            }
        }
    }
}
