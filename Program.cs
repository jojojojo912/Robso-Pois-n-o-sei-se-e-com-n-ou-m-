using ConsoleApp4;
using System;

class Program
{
    static void Main()
    {
        Aluno aluno = new Aluno();

        aluno.ReceberDados();
        aluno.CalcularMedia();
        aluno.CalcularNotaFinal();
        aluno.ImprimirNotaFinal();




    }
}