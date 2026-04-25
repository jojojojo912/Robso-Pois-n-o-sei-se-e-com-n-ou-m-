using System;

public class Cliente
{
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Cidade { get; set; }

    public void ExibirDados() => Console.WriteLine($"Cliente: {Nome} | CPF: {Cpf} | Cidade: {Cidade}");
    public string RetornarApresentacao() => $"Olá, sou {Nome}, moro em {Cidade} e meu CPF é {Cpf}.";
}

public class Vendedor
{
    private double _percentualComissao;
    public string Nome { get; set; }
    public string Matricula => Nome + "10";
    public double PercentualComissao 
    { 
        get => _percentualComissao; 
        set { if(value >= 0) _percentualComissao = value; } 
    }

    public void ExibirDados() => Console.WriteLine($"Vendedor: {Nome} | Matrícula: {Matricula} | Comissão: {PercentualComissao}%");
    public double CalcularComissao(double valorPedido) => valorPedido * (PercentualComissao / 100);
}

public class Produto
{
    private double _precoUnitario;
    private int _quantidade;

    public string Descricao { get; set; }
    public double PrecoUnitario 
    { 
        get => _precoUnitario; 
        set { if(value >= 0) _precoUnitario = value; } 
    }
    public int Quantidade 
    { 
        get => _quantidade; 
        set { if(value > 0) _quantidade = value; } 
    }

    public void ExibirDados() => Console.WriteLine($"Produto: {Descricao} | Preço: R${PrecoUnitario:F2} | Qtd: {Quantidade}");
    public double CalcularSubtotal() => PrecoUnitario * Quantidade;
}

public class Pagamento
{
    private int _parcelas;
    public string FormaPagamento { get; set; }
    public int Parcelas 
    { 
        get => _parcelas; 
        set { if(value >= 1) _parcelas = value; } 
    }

    public void ExibirDados() => Console.WriteLine($"Pagamento: {FormaPagamento} em {Parcelas}x");
    public bool ValidarPagamento() => Parcelas >= 1;
    public double CalcularAcrescimo(double valorBase) => FormaPagamento.ToLower() == "credito" ? valorBase * 0.05 : 0; // Exemplo de juros
}

public class Entrega
{
    private double _distanciaKm;
    public string Endereco { get; set; }
    public string TipoEntrega { get; set; }
    public double DistanciaKm 
    { 
        get => _distanciaKm; 
        set { if(value >= 0) _distanciaKm = value; } 
    }

    public void ExibirDados() => Console.WriteLine($"Entrega: {Endereco} ({DistanciaKm}km) - {TipoEntrega}");
    public double CalcularTaxaEntrega() => DistanciaKm * 2.50; // Exemplo de taxa por km
}

public class Pedido
{
    public int Numero { get; private set; }
    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; }
    public Produto Produto { get; set; }
    public Pagamento Pagamento { get; set; }
    public Entrega Entrega { get; set; }

    public Pedido(int numero, Cliente c, Vendedor v, Produto p, Pagamento pag, Entrega e)
    {
        if (c == null || v == null || p == null || pag == null || e == null)
            throw new ArgumentException("Nenhum dado pode ser nulo.");
            
        Numero = numero;
        Cliente = c;
        Vendedor = v;
        Produto = p;
        Pagamento = pag;
        Entrega = e;
    }

    public double CalcularValorFinal()
    {
        double sub = Produto.CalcularSubtotal();
        double taxa = Entrega.CalcularTaxaEntrega();
        double acrescimo = Pagamento.CalcularAcrescimo(sub);
        return sub + taxa + acrescimo;
    }

    public double CalcularComissaoVendedor() => Vendedor.CalcularComissao(Produto.CalcularSubtotal());

    public void ExibirResumo()
    {
        Console.WriteLine($"\n=== RESUMO DO PEDIDO #{Numero} ===");
        Cliente.ExibirDados();
        Vendedor.ExibirDados();
        Produto.ExibirDados();
        Pagamento.ExibirDados();
        Entrega.ExibirDados();
        Console.WriteLine($"Total Final: R${CalcularValorFinal():F2}");
        Console.WriteLine($"Comissão do Vendedor: R${CalcularComissaoVendedor():F2}\n");
    }
}

public class ProgramEx6
{
    public static void Main()
    {
        var c = new Cliente { Nome = "João", Cpf = "123", Cidade = "São Paulo" };
        var v = new Vendedor { Nome = "Maria", PercentualComissao = 5 };
        var p = new Produto { Descricao = "Notebook", PrecoUnitario = 3000, Quantidade = 2 };
        var pag = new Pagamento { FormaPagamento = "Credito", Parcelas = 10 };
        var e = new Entrega { Endereco = "Rua A", DistanciaKm = 10, TipoEntrega = "Expressa" };

        var pedido = new Pedido(1, c, v, p, pag, e);
        pedido.ExibirResumo();
    }
}