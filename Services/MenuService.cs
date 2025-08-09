using Calculadora_de_Notas_POO.Utils;
using System;

namespace Calculadora_de_Notas_POO.Services
{
    public class MenuService
    {
        // Método para rodar o menu principal
        public void runMenu()
        {
            while (true)
            {
                printHeader();
                printMenuHome();

                Console.Write(ConsoleColors.Colorize("\nDigite o número da operação: ", ConsoleColors.Yellow));
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int operacaoHome) || operacaoHome < 1 || operacaoHome > 3)
                {
                    Console.Write(ConsoleColors.Colorize("Entrada inválida. Por favor, insira um número entre 1 e 10.\n", ConsoleColors.Yellow));
                    continue;
                }
                switch (operacaoHome)
                {
                    case 1:
                        runMenuMaterias();
                        break;
                    case 2:
                        runMenuNotas();
                        break;
                    case 3:
                        Console.WriteLine(ConsoleColors.Colorize("Saindo do programa...", ConsoleColors.Red));
                        return;
                }
            }
        }

        // Método para rodar o menu de matérias
        public void runMenuMaterias()
        {
            while (true)
            {
                printMenuMaterias();
                Console.Write(ConsoleColors.Colorize("\nDigite o número da operação: ", ConsoleColors.Yellow));
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int operacaoMaterias) || operacaoMaterias < 1 || operacaoMaterias > 5)
                {
                    Console.Write(ConsoleColors.Colorize("Entrada inválida. Por favor, insira um número entre 1 e 5.\n", ConsoleColors.Yellow));
                    continue;
                }
                switch (operacaoMaterias)
                {
                    case 1:
                        Console.WriteLine(ConsoleColors.Colorize("Cadastrar Matéria", ConsoleColors.Green));
                        break;
                    case 2:
                        Console.WriteLine(ConsoleColors.Colorize("Consultar Matérias Cadastradas", ConsoleColors.Green));
                        break;
                    case 3:
                        Console.WriteLine(ConsoleColors.Colorize("Editar Matéria", ConsoleColors.Green));
                        break;
                    case 4:
                        Console.WriteLine(ConsoleColors.Colorize("Deletar Matéria", ConsoleColors.Green));
                        break;
                    case 5:
                        return; // Voltar ao Menu Principal
                }
            }
        }

        // Método para rodar o menu de notas
        public void runMenuNotas()
        {
            while (true)
            {
                printMenuNotas();
                Console.Write(ConsoleColors.Colorize("\nDigite o número da operação: ", ConsoleColors.Yellow));
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int operacaoNotas) || operacaoNotas < 1 || operacaoNotas > 7)
                {
                    Console.Write(ConsoleColors.Colorize("Entrada inválida. Por favor, insira um número entre 1 e 7.\n", ConsoleColors.Yellow));
                    continue;
                }
                switch (operacaoNotas)
                {
                    case 1:
                        Console.WriteLine(ConsoleColors.Colorize("Cadastrar Notas", ConsoleColors.Green));
                        break;
                    case 2:
                        Console.WriteLine(ConsoleColors.Colorize("Consultar Notas", ConsoleColors.Green));
                        break;
                    case 3:
                        Console.WriteLine(ConsoleColors.Colorize("Editar Notas", ConsoleColors.Green));
                        break;
                    case 4:
                        Console.WriteLine(ConsoleColors.Colorize("Calcular Nota para o 2° Bimestre", ConsoleColors.Green));
                        break;
                    case 5:
                        Console.WriteLine(ConsoleColors.Colorize("Calcular Nota para o Exame Final", ConsoleColors.Green));
                        break;
                    case 6:
                        Console.WriteLine(ConsoleColors.Colorize("Verificar Aprovação", ConsoleColors.Green));
                        break;
                    case 7:
                        return; // Voltar ao Menu Principal
                }
            }
        }
       

        // Método para imprimir o Cabeçalho
        static void printHeader()
        {
            Console.Clear();
            Console.WriteLine(ConsoleColors.Colorize(new string('=', 60), ConsoleColors.Blue));
            Console.WriteLine(ConsoleColors.BoldText("SISTEMA DE CLASSIFICAÇÃO DE ALUNOS"));
            Console.WriteLine(ConsoleColors.Colorize(new string('=', 60), ConsoleColors.Blue));
        }

        // Método para imprimir o menu
        static void printMenuHome()
        {
            Console.WriteLine(ConsoleColors.Colorize("Menu Principal", ConsoleColors.Cyan));
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("1 - Matérias");
            Console.WriteLine("2 - Notas");
            Console.WriteLine("3 - Sair");
            Console.WriteLine(new string('-', 60));
        }

        // Método para imprimir o menu de matérias
        static void printMenuMaterias()
        {
            Console.WriteLine(ConsoleColors.Colorize("Menu de Matérias", ConsoleColors.Cyan));
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("1 - Cadastrar Matéria");
            Console.WriteLine("2 - Consultar Matérias Cadastradas");
            Console.WriteLine("3 - Editar Matéria");
            Console.WriteLine("4 - Deletar Matéria");
            Console.WriteLine("5 - Voltar ao Menu Principal");
            Console.WriteLine(new string('-', 60));
        }

        // Método para imprimir o menu de notas
        static void printMenuNotas()
        {
            Console.WriteLine(ConsoleColors.Colorize("Menu de Notas", ConsoleColors.Cyan));
            Console.WriteLine(new string('-', 60));
            Console.WriteLine("1 - Cadastrar Notas");
            Console.WriteLine("2 - Consultar Notas");
            Console.WriteLine("3 - Editar Notas");
            Console.WriteLine("4 - Saber quanto precisa tirar no 2° Bimestre");
            Console.WriteLine("5 - Saber quanto precisa tirar no Exame Final");
            Console.WriteLine("6 - Ver se foi aprovado");
            Console.WriteLine("7 - Voltar ao Menu Principal");
            Console.WriteLine(new string('-', 60));
        }
    }
}
