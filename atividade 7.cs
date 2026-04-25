using System;

public class Filme
{
    public string Nome;
    public string Genero;
    public int DuracaoMinutos;
    public int ClassificacaoIndicativa;

    public Filme(string nome, string genero, int duracao, int classificacao)
    {
        Nome = string.IsNullOrWhiteSpace(nome) ? "Sem Nome" : nome;
        Genero = string.IsNullOrWhiteSpace(genero) ? "Sem Gênero" : genero;
        DuracaoMinutos = duracao > 0 ? duracao : 1;
        ClassificacaoIndicativa = classificacao >= 0 ? classificacao : 0;
    }

    public void ExibirResumo()
    {
        Console.WriteLine($"Filme: {Nome} | Gênero: {Genero} | Duração: {DuracaoMinutos} min | Classificação: +{ClassificacaoIndicativa}");
    }

    public bool EhPermitido(int idade)
    {
        return idade >= ClassificacaoIndicativa;
    }

    public void AlterarDuracao(int novaDuracao)
    {
        if (novaDuracao > 0)
            DuracaoMinutos = novaDuracao;
        else
            Console.WriteLine("Duração inválida.");
    }
}

public class ProgramEx7
{
    public static void Main()
    {
        Filme f1 = new Filme("Interestelar", "Ficção Científica", 169, 12);
        Filme f2 = new Filme("", "", -30, -5);

        f1.ExibirResumo();
        f2.ExibirResumo();

        Console.WriteLine(f1.EhPermitido(10)); // False
        Console.WriteLine(f1.EhPermitido(15)); // True

        f2.AlterarDuracao(120);
        f2.ExibirResumo();
    }
}