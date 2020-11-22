using System;
using System.Collections.Generic;
using ExchangeRate.Model;

namespace ExchangeRate.Infrastructure
{
    public interface IExporter
    {
        dynamic Export(IList<Currency> currencies);
    }
}
