using System;

namespace ExchangeRate.Model
{
    public class Currency
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string BulletinNum { get; set; }
        public int CrossOrder { get; set; }
        public string TurkishCode { get; set; }
        public string CurrencyCode { get; set; }
        public int Unit { get; set; }
        public string TurkishName { get; set; }
        public string CurrencyName { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public decimal? BanknoteBuying { get; set; }
        public decimal? BanknoteSelling { get; set; }
        public decimal? CrossRateUSD { get; set; }
        public decimal? CrossRateOther { get; set; }
    }
}
