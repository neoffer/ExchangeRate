using System;
using System.Collections.Generic;
using System.IO;
using ExchangeRate.Model;

namespace ExchangeRate.Infrastructure
{
    public class XmlExporter:IExporter
    {
        public dynamic Export(IList<Currency> currencies)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(currencies.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                x.Serialize(textWriter, currencies);
                return textWriter.ToString();
            }
        }
    }
}
