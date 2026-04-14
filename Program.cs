class Program
{
    static void Main(string[] args)
    {
        ContaBancaria conta = new ContaBancaria();

        conta.ReceberDados();
        conta.MostrarSaldo();

        conta.Depositar();
        conta.MostrarSaldo();

        conta.Sacar();
        conta.MostrarSaldo();
    }
}
