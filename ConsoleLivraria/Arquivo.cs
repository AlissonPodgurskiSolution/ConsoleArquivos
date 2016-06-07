using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLivraria

{
    public class Arquivo
    {
        public IDictionary<int, string> Conteudos = new Dictionary<int, string>();
        public IDictionary<string, int> ArquivosConteudo = new Dictionary<string, int>();
        public DirectoryInfo Dir;

        public Arquivo() { }


        public void carregarArquivosEmMemoria()
        {
            Console.WriteLine("Informe o diretório ao qual deseja carregar os arquivos:");
            string diretorio = Console.ReadLine();
            //C:\Users\Alisson Podgurski\Desktop\Exercicio HBSis\ConsoleHBSis\Arquivos_problema1
            try
            {
                Dir = new DirectoryInfo(@diretorio);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Diretório não encontrado!");
                return;
            }

            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
            int i = 1;

            //Gravar Conteudos
            foreach (FileInfo File in Files.OrderBy(r => r.Name))
            {
                if (Conteudos.Count == 0)
                {
                    Conteudos.Add(i, File.OpenText().ReadToEnd());
                    i++;
                }
                else
                {
                    if (!Conteudos.Values.Contains(File.OpenText().ReadToEnd()))
                    {
                        Conteudos.Add(i, File.OpenText().ReadToEnd());
                        i++;
                    }
                }
            }

            foreach (FileInfo File in Files.OrderBy(r => r.Name))
            {
                ArquivosConteudo.Add(File.Name, Conteudos.Where(r => r.Value == File.OpenText().ReadToEnd()).FirstOrDefault().Key);
            }

            foreach (var item in ArquivosConteudo)
            {
                System.Console.WriteLine("Nome do Arquivo = {0}, Conteudo = {1}", item.Key.ToString(), item.Value.ToString());
            }
            Console.WriteLine("\nNúmero de Arquivos: {0} \nNúmero de Conteúdos:{1} \n", Files.Count(), Conteudos.Count());
            Console.WriteLine("Informe o nome do arquivo ao qual deseja ver o conteúdo:");
            string nomeArquivoEscolhido = Console.ReadLine();

            int conteudoEscolhido = ArquivosConteudo.Where(r => r.Key.ToUpper() == nomeArquivoEscolhido.ToUpper()).FirstOrDefault().Value;

            string conteudoParaExibir = Conteudos.Where(r => r.Key == conteudoEscolhido).FirstOrDefault().Value;

            Console.WriteLine("Arquivo escolhido: {0} Conteúdo:{1}", nomeArquivoEscolhido, conteudoParaExibir);

        }
    }
}
