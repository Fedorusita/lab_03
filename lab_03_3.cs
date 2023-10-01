using System;

public abstract class Currency
{
    protected double value;
}
class CurrencyUSD : Currency
{
    public CurrencyUSD(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyEUR(CurrencyUSD val)
    {
        return new CurrencyEUR(val.value * CurrencyEUR.ExChange);
    }
    public static implicit operator CurrencyRUB(CurrencyUSD val)
    {
        return new CurrencyRUB(val.value * CurrencyRUB.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyEUR : Currency
{
    public static double ExChange { get; set; }

    public CurrencyEUR(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyRUB(CurrencyEUR val)
    {
        return new CurrencyRUB((val.value / CurrencyEUR.ExChange) *  CurrencyRUB.ExChange);
    }
    public static implicit operator CurrencyUSD(CurrencyEUR val)
    {
        return new CurrencyUSD(val.value / CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}
class CurrencyRUB : Currency
{
    public static double ExChange { get; set; }
    public CurrencyRUB(double value)
    {
        this.value = value;
    }
    public static implicit operator CurrencyUSD(CurrencyRUB val)
    {
        return new CurrencyUSD(val.value / CurrencyRUB.ExChange);
    }
    public static implicit operator CurrencyEUR(CurrencyRUB val)
    {
        return new CurrencyEUR((val.value / CurrencyRUB.ExChange) * CurrencyEUR.ExChange);
    }
    public double Value
    {
        get { return this.value; }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CurrencyEUR.ExChange = 0.94;
        CurrencyRUB.ExChange = 97.4;
        


        CurrencyUSD cur = new CurrencyUSD(500);
        Console.WriteLine($"На счету 500 долларов");
        CurrencyEUR eur = cur;
        Console.WriteLine($"Это {eur.Value} EUR");
        CurrencyRUB rub = eur;
        Console.WriteLine($"Это {rub.Value} RUB");
    }
}
