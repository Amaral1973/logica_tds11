using System;
using System.Diagnostics;
using static System.Console;
using System.Text;
using System.IO;

namespace ConsoleCRUD
{
    class MainClass
    {
        public static void printMenu(String[] options)
        {
            foreach (String option in options)
            {
                WriteLine(option);
            }
            WriteLine("Escolha a sua opção:");
        }

        public static void Main(String[] args)
        {
            WriteLine(">>>> CADASTRO DE PESSOAS >>>>");
            String[] options = {"1 - Cadastrar",
                                "2 - Editar",
                                "3 - Excluir",
                                "4 - Listar",
                                "5 - Gravar",
                                "6 - Ler",
                                "7 - Sair"};
            int option = 0;
            while (true)
            {
                printMenu(options);
                try
                {
                    option = Convert.ToInt32(ReadLine());
                }
                catch (System.FormatException)
                {
                    WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                    continue;
                }
                catch (Exception)
                {
                    WriteLine("Um erro aconteceu!");
                    continue;
                }
                switch (option)
                {
                    case 1:
                        Cadastrar();
                        break;
                    case 2:
                        Editar();
                        break;
                    case 3:
                        Excluir();
                        break;
                    case 4:
                        Listar();
                        break;
                    case 5:
                        Gravar();
                        break;
                    case 6:
                        Ler();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        WriteLine("Por favor, digite uma opção entre 1 e " + options.Length);
                        break;
                }
            }
        }

        static List<string> nomes = new List<string>();
        static List<int> idades = new List<int>();

        private static void Cadastrar()
        {
            Clear();
            WriteLine(">>>> CADASTRO DE PESSOAS <<<<");
            WriteLine();
            WriteLine("Digite o nome da pessoa:");
            string nome = ReadLine();
            var repetido = nomes.Any(x=> x.Contains(nome));
            if (repetido == true)
            {
                WriteLine("Esta pessoa já existe em nossa base de dados!\n");
                return;
            }
            else
            {
                nomes.Add(nome);
            }
            WriteLine("Digite a idade da pessoa:");
            idades.Add(Convert.ToInt32(ReadLine()));
            WriteLine();
        }

        private static void Listar()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> LISTAGEM DAS PESSOAS <<<<");
            int pos = 0;
            foreach (var item in nomes)
            {
                WriteLine($"Nome: {item}, idade: {idades[pos]}");
                pos++;
            }
            WriteLine();
        }

        private static void Editar()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EDIÇÃO DE PESSOAS <<<<");
            WriteLine();
            ResetColor();
            string nome = "";
            WriteLine("Digite o nome que você deseja editar:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> REGISTRO QUE SERÁ EDITADO <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {idades[index]}");
                WriteLine();
                WriteLine("Digite o novo nome da pessoa:");
                nomes[index] = ReadLine();
                WriteLine("Digite a nova idade da pessoa:");
                idades[index] = Convert.ToInt32(ReadLine());
                WriteLine();
                WriteLine("Pessoa editada com sucesso!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Pessoa não encontrada!!!");
                ResetColor();
            }
        }

        private static void Excluir()
        {
            Clear();
            WriteLine();
            ForegroundColor = ConsoleColor.Green;
            WriteLine(">>>> EXCLUSÃO DE PESSOAS <<<<");
            WriteLine();
            ResetColor();
            string nome = "";
            WriteLine("Digite o nome que você deseja excluir:");
            nome = ReadLine();
            int index = nomes.IndexOf(nome);
            if (index >= 0)
            {
                WriteLine(">>>> REGISTRO QUE SERÁ EXCLUÍDO <<<<");
                WriteLine($"Nome: {nomes[index]}");
                WriteLine($"Idade: {idades[index]}");
                WriteLine();
                nomes.RemoveAt(index);
                idades.RemoveAt(index);
                WriteLine();
                WriteLine("Pessoa excluído com sucesso!");
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Pessoa não encontrada!!!");
                ResetColor();
            }
        }

        private static void Gravar()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> GRAVAR OS DADOS <<<<");
            try
            {
                StreamWriter dados;
                string arq = @"C:\\Programas_Console\\aula0606\\dados.txt";
                dados = File.CreateText(arq);
                foreach (var item in nomes)
                {
                    dados.WriteLine($"{item}");
                }
                dados.Close();
                StreamWriter dados2;
                string arq2 = @"C:\\Programas_Console\\aula0606\\dados2.txt";
                dados2 = File.CreateText(arq2);
                foreach (var item2 in idades)
                {
                    dados2.WriteLine($"{item2}");
                }
                dados2.Close();
            }
            catch (Exception erro)
            {
                WriteLine(erro.Message);
            }
            finally
            {
                WriteLine("Dados gravados com sucesso!");
            }
        }

        private static void Ler()
        {
            Clear();
            WriteLine();
            WriteLine(">>>> LER O ARQUIVO <<<<");
            WriteLine();
            var nome = File.ReadAllLines(@"C:\\Programas_Console\\aula0606\\dados.txt");
            for (int i = 0; i < nome.Length; i++)
            {7
                nomes.Add(nome[i]);
            }
            var idade = File.ReadAllLines(@"C:\\Programas_Console\\aula0606\\dados2.txt");
            for (int x = 0; x < idade.Length; x++)
            {
                idades.Add(Convert.ToInt32(idade[x]));
            }
            WriteLine();
            WriteLine("Leitura de dados concluída com sucesso!");
        }
    }
}