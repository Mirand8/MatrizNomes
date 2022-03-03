using System;
using System.IO;

namespace MatrizNomes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("=> Digite quantas linha e quantas colunas terá sua matriz: ");
            // Console.Write("Linhas: ");
            //int rows = int.Parse(Console.ReadLine());
            // Console.Write("Colunas: ");
            //int cols = int.Parse(Console.ReadLine());


            string[,] namesMatrix = new string[3, 5];
            Console.Clear();
            int option = 7;
            string filePath = "";
            
            while (option != 0)
            {
                if (filePath == "")
                {
                    Menu();
                }
                else
                {
                    Menu(filePath);
                }
                option = MenuChoice();

                switch (option)
                {
                    case 0:
                        break;
                    
                    case 1:
                        Console.Clear();
                        Console.WriteLine("========= ADICIONAR NOMES =========");
                        Console.WriteLine("1 - Digitar nomes");
                        Console.WriteLine("2 - Preencher matriz aleatoriamente");
                        Console.WriteLine("3 - Fazer upload de arquivo para preencher a matriz");
                        Console.Write("Opcao: ");
                        int addOption = int.Parse(Console.ReadLine());
                        
                        if (addOption == 1)
                        {
                            Add(namesMatrix);
                        }
                        else if (addOption == 2)
                        {
                            AddRandom(namesMatrix);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("=> Fazer download de arquivo para preencher a matriz");
                            Console.WriteLine("Digite o caminho do arquivo: ");
                            filePath = Console.ReadLine();
                            Console.ReadKey();
                            DownloadMatrix(filePath, namesMatrix);
                        }

                        Console.WriteLine("\nDigite qualquer coisa para voltar para o menu");
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("========= ITENS DA MATRIZ =========");
                        PrintMatrix(namesMatrix);
                        Console.WriteLine("\nDigite qualquer coisa para voltar para o menu");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("LINHA: ");
                        int rowSearch = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine($"========= ITENS DA LINHA {rowSearch} =========");
                        PrintRow(rowSearch, namesMatrix);
                        Console.WriteLine("\nDigite qualquer coisa para voltar para o menu");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        Console.Write("COLUNA: ");
                        int colSearch = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.WriteLine($"========= ITENS DA COLUNA {colSearch} =========");
                        PrintCol(colSearch, namesMatrix);
                        Console.WriteLine("\nDigite qualquer coisa para voltar para o menu");
                        Console.ReadKey();
                        break;

                    case 5:
                        Console.Clear();
                        Console.WriteLine("=========PROCURAR NOME =========");
                        Console.Write("PROCURAR: ");
                        string nameSearch = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine();
                        Find(nameSearch, namesMatrix);
                        Console.WriteLine("\nDigite qualquer coisa para voltar para o menu");
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.Clear();
                        Console.Write("ORDENAR LINHA: ");
                        int rowToSort = int.Parse(Console.ReadLine());
                        while (rowToSort > namesMatrix.GetLength(0))
                        {
                            Console.WriteLine($"Sua matriz tem linhas {namesMatrix.GetLength(0)}, digite um numero de 0 a {namesMatrix.GetLength(0)}!");
                            Console.Write("\nORDENAR LINHA: ");
                            rowToSort = int.Parse(Console.ReadLine());
                        }
                        Console.Clear();

                        Console.WriteLine($"========= ORDENAR LINHA =========n\n");
                        SortRow(rowToSort, namesMatrix);
                        Console.WriteLine("\nDigite qualquer coisa para voltar para o menu");
                        Console.ReadKey();
                        break;

                    case 7:
                        Console.WriteLine("=> Upload para arquivo");
                        Console.Write("Digite o caminho do arquivo: ");
                        filePath = Console.ReadLine();
                        UploadMatrix(filePath, namesMatrix);
                        Console.WriteLine("Upload para " + filePath + "feito com sucesso!");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("\nDigite uma das opcoes!\n");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void DownloadMatrix(string filePath, string[,] namesMatrix)
        {
            try
            {
                StreamReader reader = new StreamReader(filePath);
                string data = reader.ReadToEnd();
                string[] dataSplited = data.Split(",");

                foreach (string name in dataSplited)
                {
                    for (int i = 0; i < namesMatrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < namesMatrix.GetLength(1); j++)
                        {
                            namesMatrix[i, j] = name;
                        }
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Excecao: " + e.Message);
            }
        }

        private static void UploadMatrix(string filePath, string[,] namesMatrix)
        {
            try
            {
                StreamWriter writer = new StreamWriter(filePath);
                for (int i = 0; i < namesMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < namesMatrix.GetLength(1); j++)
                    {
                        writer.Write(string.Format($"{namesMatrix[i, j]},"));
                    }
                }
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Excecao: " + e.Message);
            }
        }

        private static void Menu(string filePath)
        {
            Console.Clear();
            Console.WriteLine("Arquivo utilizado: " + filePath);
            Console.WriteLine("----------- MENU ----------\n");
            Console.WriteLine("[1] - Adicionar nomes");
            Console.WriteLine("[2] - Imprimir");
            Console.WriteLine("[3] - Imprimir linha");
            Console.WriteLine("[4] - Imprimir coluna");
            Console.WriteLine("[5] - Procurar nome");
            Console.WriteLine("[6] - Ordenar linha");
            Console.WriteLine("[7] - Exportar matriz para arquivo txt");
            Console.WriteLine("[8] - Importar matriz para arquivo txt");
            Console.WriteLine("[0] - Sair\n");
        }

        private static void Menu()
        {
            Console.Clear();
            Console.WriteLine("----------- MENU ----------\n");
            Console.WriteLine("[1] - Adicionar nomes");
            Console.WriteLine("[2] - Imprimir");
            Console.WriteLine("[3] - Imprimir linha");
            Console.WriteLine("[4] - Imprimir coluna");
            Console.WriteLine("[5] - Procurar nome");
            Console.WriteLine("[6] - Ordenar linha");
            Console.WriteLine("[7] - Exportar matriz para arquivo txt");
            Console.WriteLine("[8] - Importar matriz para arquivo txt");
            Console.WriteLine("[0] - Sair\n");
        }

        private static int MenuChoice()
        {
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=");
            Console.Write("Opcao: ");
            return int.Parse(Console.ReadLine());
        }

        private static void Add(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("Digite o nome: ");
                    matrix[i, j] = Console.ReadLine();
                }
            }
        }

        private static void AddRandom(string[,] matrix)
        {
            Console.Clear();
            matrix[0, 0] = "Gabriel";
            matrix[0, 1] = "Joao";
            matrix[0, 2] = "Pedro";
            matrix[0, 3] = "Ana";
            matrix[0, 4] = "ana";

            matrix[1, 0] = "ana";
            matrix[1, 1] = "pedro";
            matrix[1, 2] = "miranda";
            matrix[1, 3] = "Matheus";
            matrix[1, 4] = "andre";

            matrix[2, 0] = "paulo";
            matrix[2, 1] = "victor";
            matrix[2, 2] = "Hugo";
            matrix[2, 3] = "Joao Pedro";
            matrix[2, 4] = "Casemiro";

            Console.WriteLine("Nomes aleatorios adicionados...");
            Console.ReadKey();
        }

        private static void PrintMatrix(string[,] namesMatrix)
        {
            for (int i = 0; i < namesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < namesMatrix.GetLength(1); j++)
                {
                    Console.WriteLine(string.Format($"{namesMatrix[i, j]}\t"));
                }
                Console.WriteLine();
            }
        }

        private static void PrintRow(int rowChoice, string[,] namesMatrix)
        {
            for (int i = 0; i < namesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < namesMatrix.GetLength(1); j++)
                {
                    if (i == rowChoice)
                    {
                        Console.WriteLine(namesMatrix[i, j]);
                    }
                }
            }
        }

        private static void PrintCol(int colChoice, string[,] namesMatrix)
        {
            for (int i = 0; i < namesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < namesMatrix.GetLength(1); j++)
                {
                    if (colChoice == j)
                    {
                        Console.WriteLine(namesMatrix[i, j]);
                    }
                }
            }
        }

        private static void Find(string nameSearch, string[,] namesMatrix)
        {
            int foundCount = CountNames(nameSearch, namesMatrix);
            int rows = namesMatrix.GetLength(0);
            int cols = namesMatrix.GetLength(1);

            if (foundCount > 0)
            {
                Console.WriteLine($"--- {foundCount} resultados encontrados! --- \n");
                Console.WriteLine(" Posicao\t | Nome");
                Console.WriteLine(" ----------------");
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (nameSearch.ToLower().Equals(namesMatrix[i, j].ToLower()))
                        {
                            Console.WriteLine($" [{i}, {j}] \t | {namesMatrix[i, j]}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Nenhum resultado encontrado!");
            }
        }

        private static int CountNames(string nameSearch, string[,] namesMatrix)
        {
            int foundCount = 0;
            int rows = namesMatrix.GetLength(0);
            int cols = namesMatrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (nameSearch.ToLower().Equals(namesMatrix[i, j].ToLower()))
                    {
                        foundCount++;
                    }
                }
            }
            return foundCount;
        }

        private static void SortRow(int rowToSort, string[,] namesMatrix)
        {

            Console.WriteLine($"-=-=-=-=-=-=- LINHA {rowToSort} -=-=-=-=-=-=-=-=-=-");
            PrintRow(rowToSort, namesMatrix);
            Console.WriteLine($"-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=\n");

            Console.WriteLine("Ordenando... \n");
                for (int j = 0; j < namesMatrix.GetLength(1) - 1; j++)
                {
                    for (int k = j + 1; k < namesMatrix.GetLength(1); k++)
                    {
                        if (string.Compare(namesMatrix[rowToSort, j] , namesMatrix[rowToSort, k]) > 0)
                        {
                            string temp = namesMatrix[rowToSort, j];
                            namesMatrix[rowToSort, j] = namesMatrix[rowToSort, k];
                            namesMatrix[rowToSort, k] = temp;
                        }
                    }
                }

                PrintRow(rowToSort, namesMatrix);
        }



    }
}
