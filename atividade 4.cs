using System;

public class CalculadoraDeSalario
{
    public string NomeFuncionario;
    public double SalarioBase;
    public double SalarioFinal;

    public void ReceberDados()
    {
        Console.Write("Nome do funcionário: ");
        NomeFuncionario = Console.ReadLine();
        Console.Write("Salário base: ");
        SalarioBase = double.Parse(Console.ReadLine());
        SalarioFinal = SalarioBase; // Inicializa igual ao base
    }

    public void CalcularAumento(double percentual)
    {
        SalarioFinal += SalarioBase * (percentual / 100);
    }

    public void CalcularDesconto(double percentual)
    {
        SalarioFinal -= SalarioBase * (percentual / 100);
    }

    public void MostrarSalario()
    {
        Console.WriteLine($"\n[Funcionário] Nome: {NomeFuncionario} | Salário Base: R${SalarioBase:F2} | Salário Final: R${SalarioFinal:F2}");
    }
}

public class ProgramEx4
{
    public static void Main()
    {
        CalculadoraDeSalario calc = new CalculadoraDeSalario();
        calc.ReceberDados();
        calc.CalcularAumento(10); // +10%
        calc.MostrarSalario();
        calc.CalcularDesconto(5); // -5% sobre o base
        calc.MostrarSalario();
    }
}