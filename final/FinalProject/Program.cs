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
// Interface representing a financial market data provider
public interface IMarketDataProvider
{
    FinancialInstrument GetMarketData(string symbol);
}

// Class implementing the market data provider interface
public class AlphaVantageMarketDataProvider : IMarketDataProvider
{
    public FinancialInstrument GetMarketData(string symbol)
    {
        // Simulated data retrieval from Alpha Vantage or any other market data provider
        // Replace this with actual data fetching logic
        Random random = new Random();
        return new Stock { Symbol = symbol, Price = random.Next(50, 200), SharesOwned = random.Next(1, 1000) };
    }
}