public class Computer {

    public string CPU { get; set; }
    public string RAM { get; set; }
    public string Disk { get; set; }
    public string GPU { get; set; }

    public void DisplaySpecs()
    {
        Console.WriteLine($"Bilgisayar Özellikleri: CPU:{CPU}, RAM:{RAM}, Disk:{Disk}, GPU:{GPU}");
    }

}

public interface IComputerBuilder {

    void SetCPU();
    void SetRAM();
    void SetDisk();
    void SetGPU();
    Computer GetComputer();

}


public class GamingComputerBuilder : IComputerBuilder
{
    private Computer _computer = new Computer();
    public Computer GetComputer()
    {
        return _computer;
    }

    public void SetCPU()
    {
        _computer.CPU = "Intel i9 9900K";
    }

    public void SetDisk()
    {
        _computer.Disk = "1TB SSD";
    }

    public void SetGPU()
    {
        _computer.GPU = "Nvidia RTX 4080 Ti";
    }

    public void SetRAM()
    {
        _computer.RAM = "32GB DDR4";
    }
}

public class ComputerDirector
{
    private IComputerBuilder _computerBuilder;

    public ComputerDirector(IComputerBuilder computerBuilder)
    {
        _computerBuilder = computerBuilder;
    }

    public void BuildComputer()
    {
        _computerBuilder.SetCPU();
        _computerBuilder.SetRAM();
        _computerBuilder.SetDisk();
        _computerBuilder.SetGPU();
    }
}

public class FlexibleComputerBuilder
{
    private Computer _computer = new Computer();

    public FlexibleComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public FlexibleComputerBuilder SetRAM(string ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public FlexibleComputerBuilder SetDisk(string disk)
    {
        _computer.Disk = disk;
        return this;
    }

    public FlexibleComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public Computer Build()
    {
        return _computer;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Builder ile direkt kullanım
        Console.WriteLine("Builder ile oluşturma:");
        var gamingComputerBuilder = new GamingComputerBuilder();
        gamingComputerBuilder.SetCPU();
        gamingComputerBuilder.SetRAM();
        gamingComputerBuilder.SetDisk();
        gamingComputerBuilder.SetGPU();
        var gamingComputer = gamingComputerBuilder.GetComputer();
        gamingComputer.DisplaySpecs();

        // Director ile kullanım
        Console.WriteLine("\nDirector ile oluşturma:");

        var directorBuilder = new GamingComputerBuilder();
        var director = new ComputerDirector(directorBuilder);
        director.BuildComputer();
        var directorComputer = directorBuilder.GetComputer();
        directorComputer.DisplaySpecs();

        // Fluent Builder ile kullanım
        Console.WriteLine("\nFluent Builder ile oluşturma:");
        var computer = new FlexibleComputerBuilder()
            .SetRAM("16GB DDR4")
            .SetGPU("Nvidia RTX 3080")
            .SetCPU("Intel i7 10700K")
            .SetDisk("512GB SSD")
            .Build();

        computer.DisplaySpecs();
    }
}