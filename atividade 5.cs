using System;

public class Hospede
{
    public string Nome;
    public string Cpf;
    public string Telefone;

    public void ReceberDados()
    {
        Console.Write("Nome do hóspede: ");
        Nome = Console.ReadLine();
        Console.Write("CPF: ");
        Cpf = Console.ReadLine();
        Console.Write("Telefone: ");
        Telefone = Console.ReadLine();
    }

    public void MostrarDados()
    {
        Console.WriteLine($"[Hóspede] Nome: {Nome} | CPF: {Cpf} | Telefone: {Telefone}");
    }

    public void AtualizarTelefone(string novoTelefone)
    {
        Telefone = novoTelefone;
    }
}

public class Reserva
{
    public int NumeroReserva;
    public int QuantidadeDiarias;
    public double ValorDiaria;
    public double ValorTotal;

    public void ReceberDadosReserva()
    {
        Console.Write("Número da reserva: ");
        NumeroReserva = int.Parse(Console.ReadLine());
        Console.Write("Quantidade de diárias: ");
        QuantidadeDiarias = int.Parse(Console.ReadLine());
        Console.Write("Valor da diária: ");
        ValorDiaria = double.Parse(Console.ReadLine());
    }

    public void CalcularTotal()
    {
        ValorTotal = QuantidadeDiarias * ValorDiaria;
    }

    public void AplicarDesconto(double percentual)
    {
        ValorTotal -= ValorTotal * (percentual / 100);
    }

    public void MostrarReserva()
    {
        Console.WriteLine($"[Reserva #{NumeroReserva}] Diárias: {QuantidadeDiarias} | Valor Diária: R${ValorDiaria:F2} | Total: R${ValorTotal:F2}");
    }
}

public class ProgramEx5
{
    public static void Main()
    {
        Hospede h = new Hospede();
        h.ReceberDados();
        
        Reserva r = new Reserva();
        r.ReceberDadosReserva();
        r.CalcularTotal();

        Console.WriteLine("\n--- Resumo ---");
        h.MostrarDados();
        r.MostrarReserva();

        Console.WriteLine("\nAplicando 10% de desconto e trocando telefone...");
        r.AplicarDesconto(10);
        h.AtualizarTelefone("99999-0000");

        h.MostrarDados();
        r.MostrarReserva();
    }
}