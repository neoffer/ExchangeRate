using System;
using System.Collections.Generic;
using ExchangeRate.Model;

namespace ExchangeRate.Data
{ 
    public interface IContext
    {
        IList<Currency> Currencies { get; set; }
        bool Load();
    }
}
