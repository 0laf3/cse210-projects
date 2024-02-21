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