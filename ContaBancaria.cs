using System;

class ContaBancaria
{
    public string NumeroConta;
    public string NomeTitular;
    public double Saldo;

    public void ReceberDados()
    {
        Console.Write("Digite o número da conta: ");
        NumeroConta = Console.ReadLine();

        Console.Write("Digite o nome do titular: ");
        NomeTitular = Console.ReadLine();

        Console.Write("Digite o saldo inicial: ");
        Saldo = double.Parse(Console.ReadLine());
    }

    public void Depositar()
    {
        Console.Write("Digite o valor a depositar: ");
        double valor = double.Parse(Console.ReadLine());
        Saldo += valor;
        Console.WriteLine($"Depósito de R$ {valor:F2} realizado com sucesso!");
    }

    public void Sacar()
    {
        Console.Write("Digite o valor a sacar: ");
        double valor = double.Parse(Console.ReadLine());

        if (valor <= Saldo)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de R$ {valor:F2} realizado com sucesso!");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente para realizar o saque.");
        }
    }

    public void MostrarSaldo()
    {
        Console.WriteLine("\n--- Dados da Conta ---");
        Console.WriteLine($"Número da conta : {NumeroConta}");
        Console.WriteLine($"Nome do titular : {NomeTitular}");
        Console.WriteLine($"Saldo atual     : R$ {Saldo:F2}");
        Console.WriteLine("----------------------");
    }
}
