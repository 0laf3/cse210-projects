
public class AlphaVantageMarketDataProvider : IMarketDataProvider
{
    public FinancialInstrument GetMarketData(string symbol)
    {
        
        Random random = new Random();
        return new Stock { Symbol = symbol, Price = random.Next(50, 200), SharesOwned = random.Next(1, 1000) };
    }
}