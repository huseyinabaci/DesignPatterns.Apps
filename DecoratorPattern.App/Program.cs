public interface ICoffee
{

    string GetDescription();
    double GetCost();
}

public class SimpleCoffee : ICoffee
{
    public double GetCost()
    {
        return 5.0;
    }

    public string GetDescription()
    {
        return "Basit Kahve";
    }
}

public abstract class CoffeeDecorator : ICoffee
{
    protected ICoffee _coffee;

    protected CoffeeDecorator(ICoffee coffee)
    {
        _coffee = coffee;
    }
    public virtual double GetCost()
    {
        return _coffee.GetCost();
    }

    public virtual string GetDescription()
    {
        return _coffee.GetDescription();
    }
}

public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(ICoffee coffee) : base(coffee) { }

    public override double GetCost()
    {
        return _coffee.GetCost() + 2.0;
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Süt";
    }
}

public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(ICoffee coffee) : base(coffee)
    {
    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 1.0;
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Şeker";
    }
}

public class ChocolateDecarator : CoffeeDecorator
{
    public ChocolateDecarator(ICoffee coffee) : base(coffee)
    {

    }

    public override double GetCost()
    {
        return _coffee.GetCost() + 3.0;
    }

    public override string GetDescription()
    {
        return _coffee.GetDescription() + ", Çikolata";
    }

}

public static class CoffeeExtensions
{
    public static ICoffee AddMilk(this ICoffee coffee)
    {
        return new MilkDecorator(coffee);
    }

    public static ICoffee AddSugar(this ICoffee coffee)
    {
        return new SugarDecorator(coffee);
    }

    public static ICoffee AddChocolate(this ICoffee coffee)
    {
        return new ChocolateDecarator(coffee);
    }
}

class Program
{

    static void Main(string[] args)
    {
        // Basit kahve
        ICoffee coffee = new SimpleCoffee();
        Console.WriteLine($"{coffee.GetDescription()} - Maliyeti: {coffee.GetCost()}");

        // Süt eklenmiş kahve
        coffee = new MilkDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Maliyeti: {coffee.GetCost()}");

        // Şeker eklenmiş kahve
        coffee = new SugarDecorator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Maliyeti: {coffee.GetCost()}");

        // Çikolata eklenmiş kahve
        coffee = new ChocolateDecarator(coffee);
        Console.WriteLine($"{coffee.GetDescription()} - Maliyeti: {coffee.GetCost()}");

        // Extension metotlar ile kahve oluşturma
        ICoffee coffee1 = new SimpleCoffee()
            .AddMilk()
            .AddSugar()
            .AddChocolate();

        Console.WriteLine($"{coffee1.GetDescription()} - Maliyeti: {coffee1.GetCost()}");

    }
}