using System;
using System.Collections.Generic;

// Abstract class representing a generic financial instrument
public abstract class FinancialInstrument
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }

    public abstract void DisplayInfo();
}

// Concrete class representing a stock, inheriting from FinancialInstrument
public class Stock : FinancialInstrument
{
    public int SharesOwned { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Stock - Symbol: {Symbol}, Price: {Price:C}, Shares Owned: {SharesOwned}");
    }
}

// Concrete class representing a bond, inheriting from FinancialInstrument
public class Bond : FinancialInstrument
{
    public DateTime MaturityDate { get; set; }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Bond - Symbol: {Symbol}, Price: {Price:C}, Maturity Date: {MaturityDate:d}");
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

// Class representing a portfolio that holds a collection of financial instruments
public class Portfolio
{
    private List<FinancialInstrument> holdings;

    public Portfolio()
    {
        holdings = new List<FinancialInstrument>();
    }

    public void AddToPortfolio(FinancialInstrument instrument)
    {
        holdings.Add(instrument);
    }

    public void DisplayPortfolio()
    {
        foreach (var instrument in holdings)
        {
            instrument.DisplayInfo();
        }
    }
}

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
