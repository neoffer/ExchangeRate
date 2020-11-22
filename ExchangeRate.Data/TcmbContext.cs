using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ExchangeRate.Model;

namespace ExchangeRate.Data
{
    public class TcmbContext : IContext
    {
        public IList<Currency> Currencies { get; set; } = new List<Currency>();

        public bool Load()
        {


                XmlDocument doc = new XmlDocument();

                doc.Load("https://www.tcmb.gov.tr/kurlar/today.xml");

                var firstChild = doc.SelectSingleNode("/Tarih_Date");

                var date = DateTime.Parse(firstChild.Attributes["Date"].Value);
                var bulletinNum = firstChild.Attributes["Bulten_No"].Value;

                XmlNodeList nodeList = doc.SelectNodes("/Tarih_Date/Currency");

                foreach (XmlNode node in nodeList)
                {
                    var currency = new Currency();

                    currency.Id = Guid.NewGuid().ToString();
                    currency.Date = date;
                    currency.BulletinNum = bulletinNum;
                    currency.CrossOrder = int.Parse(node.Attributes["CrossOrder"].Value);
                    currency.TurkishCode = node.Attributes["Kod"].Value;
                    currency.TurkishName = node.SelectSingleNode(".//Isim").InnerText;
                    currency.CurrencyCode = node.Attributes["CurrencyCode"].Value;
                    currency.CurrencyName = node.SelectSingleNode(".//CurrencyName").InnerText;
                    currency.Unit = int.Parse(node.SelectSingleNode(".//Unit").InnerText);

                    decimal forexBuying;
                    var result = decimal.TryParse(node.SelectSingleNode(".//ForexBuying").InnerText, out forexBuying);
                    currency.ForexBuying = result?forexBuying:null;

                    decimal forexSelling;
                    result = decimal.TryParse(node.SelectSingleNode(".//ForexSelling").InnerText, out forexSelling);
                    currency.ForexSelling = result?forexSelling:null;

                    decimal banknoteBuying; 
                    result = decimal.TryParse(node.SelectSingleNode(".//BanknoteBuying").InnerText, out banknoteBuying);
                    currency.BanknoteBuying = result?banknoteBuying:null;

                    decimal banknoteSelling;
                    result = decimal.TryParse(node.SelectSingleNode(".//BanknoteSelling").InnerText, out banknoteSelling);
                    currency.BanknoteSelling = result?banknoteSelling:null; 

                    decimal crossRateUSD;
                    result = decimal.TryParse(node.SelectSingleNode(".//CrossRateUSD").InnerText, out crossRateUSD);
                    currency.CrossRateUSD = result?crossRateUSD:null;

                    decimal crossRateOther;
                    result = decimal.TryParse(node.SelectSingleNode(".//CrossRateUSD").InnerText, out crossRateOther);
                    currency.CrossRateOther = result?crossRateOther:null;

                    this.Currencies.Add(currency);
                }

            return true;
        }
    }
}
