using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Aluno
    {
        public int RA;
        public string Nome;
        public double NotaProva;
        public double NotaTrabalho;
        public double NotaFinal;

        public void ReceberDados()
        {
            Console.WriteLine("Digite o RA");
            RA = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome");
            Nome = (Console.ReadLine());

            Console.WriteLine("Digite a nota da prova");
            NotaProva = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nota do trabalho");
            NotaTrabalho = double.Parse(Console.ReadLine());



        }

        public void CalcularMedia()
        {
            NotaFinal = (NotaProva + NotaTrabalho) / 2;

        }
        public bool CalcularNotaFinal()
        {
            if (NotaFinal >= 7)
            {
                Console.WriteLine("Aluno Aprovado");
                return true;
            }
            else
            {
                double NotaNecessaria = 10 - NotaFinal;

                Console.WriteLine("Aluno está de p3");
                Console.WriteLine("Aluno precisa dessa nota:" + NotaNecessaria);
                return false;
            }
           

        }
        public void ImprimirNotaFinal()
        {

            Console.WriteLine("Essa e a Nota Final" + NotaFinal);


        }

    }
}
