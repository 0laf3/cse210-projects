using System;
class Program
{
    static void Main()
    {
        
        IMarketDataProvider marketDataProvider = new AlphaVantageMarketDataProvider();

        
        FinancialInstrument stock1 = marketDataProvider.GetMarketData("AAPL");
        FinancialInstrument stock2 = marketDataProvider.GetMarketData("GOOGL");
        FinancialInstrument bond1 = marketDataProvider.GetMarketData("XYZ123");

    
        Portfolio portfolio = new Portfolio();
        portfolio.AddToPortfolio(stock1);
        portfolio.AddToPortfolio(stock2);
        portfolio.AddToPortfolio(bond1);

    
        Console.WriteLine("Portfolio Information:");
        portfolio.DisplayPortfolio();
    }
}

