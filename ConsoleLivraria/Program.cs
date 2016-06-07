using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLivraria
{
    class Program
    {
        static void Main(string[] args)
        {
            Arquivo arquivo = new Arquivo();
            arquivo.carregarArquivosEmMemoria();

            Console.WriteLine("Preciona qualquer tecla para sair.");
            System.Console.ReadKey();
        }
    }

}
