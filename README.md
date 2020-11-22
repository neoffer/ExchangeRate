# TCMB Exchange Rate 

.NET 5 project with Onion Architecture.

Tiers:
1) Model
2) Data
3) Infrastructure
4) Service
5) Tests

Currencies are filterable and orderable.
Built-in support Xml and CSV export. And Pluggable Exporter feature.

I've used ServiceStack.Text Nuget Package for CSV Export.
I've used Repository Design Pattern.

How to Run Unit Tests:
1) Open project with Visual Studio
2) Rebuild All
3) Run Unit Tests

How to Use ExchangeRate.Api in Your Project.
1) Include ExchangeRate.Api DLL
2) Create an instance of TcmbExchangeRate
3) Don't forget to call Load method first
4) Use GetCurrencies methods to get currencies.
5) Use ExportTo method to get exports.
