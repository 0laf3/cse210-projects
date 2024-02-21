using System;
using System.Collections.Generic;

public abstract class FinancialInstrument
{
    public string Symbol { get; set; }
    public decimal Price { get; set; }

    public abstract void DisplayInfo();
}

public class Stock 
{
    
}

public class Bond 
{
    public DateTime MaturityDate { get; set; }

    
}

public interface IMarketDataProvider
{
    
}


public class AlphaVantageMarketDataProvider 
{
    
}

public class Portfolio
{


    public Portfolio()
    {
       
    }

    public void AddToPortfolio(FinancialInstrument instrument)
    {
       
    }

    public void DisplayPortfolio()
    {
        
    }
}

class Program
{
    static void Main()
    {
       
    }
}
