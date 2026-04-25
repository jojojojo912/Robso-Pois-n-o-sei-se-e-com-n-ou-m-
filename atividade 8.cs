using System;

public class ReservaHotel
{
    public string NomeHospede;
    public int NumeroQuarto;
    public int QuantidadeDiarias;
    public double ValorDiaria;
    public string StatusReserva;

    // Construtor 1
    public ReservaHotel(string nome, int quarto) 
        : this(nome, quarto, 1, 50.0) // Redireciona para o construtor completo
    {
    }

    // Construtor 2
    public ReservaHotel(string nome, int quarto, int diarias, double valor)
    {
        NomeHospede = string.IsNullOrWhiteSpace(nome) ? "Hóspede não informado" : nome;
        NumeroQuarto = quarto <= 0 ? 1 : quarto;
        QuantidadeDiarias = diarias <= 0 ? 1 : diarias;
        ValorDiaria = valor <= 0 ? 50.0 : valor;
        StatusReserva = "Ativa";
    }

    public double CalcularTotal()
    {
        return QuantidadeDiarias * ValorDiaria;
    }

    public void ExibirReserva()
    {
        Console.WriteLine($"[Reserva {StatusReserva}] Hóspede: {NomeHospede} | Quarto: {NumeroQuarto} | Diárias: {QuantidadeDiarias} | Valor/Dia: R${ValorDiaria:F2}");
    }

    public void AdicionarDiarias(int quantidade)
    {
        if (quantidade > 0) QuantidadeDiarias += quantidade;
    }

    public void CancelarReserva()
    {
        StatusReserva = "Cancelada";
    }

    public void ReativarReserva()
    {
        StatusReserva = "Ativa";
    }
}

public class ProgramEx8
{
    public static void Main()
    {
        ReservaHotel r1 = new ReservaHotel("Carlos", 12);
        ReservaHotel r2 = new ReservaHotel("", -8, 0, -300);

        r1.ExibirReserva();
        r2.ExibirReserva();

        Console.WriteLine($"Total R1: R${r1.CalcularTotal()}");
        Console.WriteLine($"Total R2: R${r2.CalcularTotal()}");

        r1.AdicionarDiarias(2);
        r1.ExibirReserva();

        r2.CancelarReserva();
        r2.ExibirReserva();

        r2.ReativarReserva();
        r2.ExibirReserva();
    }
}