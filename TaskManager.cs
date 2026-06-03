using System;

public interface IPrinter
{
    void Print();
}

public interface IScanner
{
    void Scan();
}

public class Printer : IPrinter
{
    public void Print()
    {
        Console.WriteLine("Printing document...");
    }
}

public class Scanner : IScanner
{
    public void Scan()
    {
        Console.WriteLine("Scanning document...");
    }
}

public class PrintScanner : IPrinter, IScanner
{
    
    private readonly IPrinter _printer;
    private readonly IScanner _scanner;

    public PrintScanner(IPrinter printer, IScanner scanner)
    {
        _printer = printer;
        _scanner = scanner;
    }

    public void Print()
    {
        Console.WriteLine("PrintScanner: Printing document...");
        _printer.Print();
    }

    public void Scan()
    {
        Console.WriteLine("PrintScanner: Scanning document...");
        _scanner.Scan();
    }
}

public class TaskManager
{
    public void PrintTask(int taskId, IPrinter printer)
    {
        Console.WriteLine($"Executing Print Task: {taskId}");
        printer.Print();
    }

    public void ScanTask(int taskId, IScanner scanner)
    {
        Console.WriteLine($"Executing Scan Task: {taskId}");
        scanner.Scan();
    }
}

public class Program
{
    public static void Main()
    {
        var printer = new Printer();
        var scanner = new Scanner();
        var printScanner = new PrintScanner(printer,scanner);

        var scheduler = new TaskManager();

        scheduler.PrintTask(101, printer);
        scheduler.ScanTask(102, scanner);

        scheduler.PrintTask(103, printScanner);
        scheduler.ScanTask(104, printScanner);
    }
}