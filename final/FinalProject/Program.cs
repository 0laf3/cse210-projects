using System;
class Program
{
    static void Main()
    {
        // Instantiate the market data provider
        IMarketDataProvider marketDataProvider = new AlphaVantageMarketDataProvider();

        // Create instances of financial instruments
        FinancialInstrument stock1 = marketDataProvider.GetMarketData("AAPL");
        FinancialInstrument stock2 = marketDataProvider.GetMarketData("GOOGL");
        FinancialInstrument bond1 = marketDataProvider.GetMarketData("XYZ123");

        // Create a portfolio and add instruments
        Portfolio portfolio = new Portfolio();
        portfolio.AddToPortfolio(stock1);
        portfolio.AddToPortfolio(stock2);
        portfolio.AddToPortfolio(bond1);

        // Display portfolio information
        Console.WriteLine("Portfolio Information:");
        portfolio.DisplayPortfolio();
    }
}

