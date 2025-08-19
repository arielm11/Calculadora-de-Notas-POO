using Calculadora_de_Notas_POO.Utils;
using Calculadora_de_Notas_POO.Models;
using Calculadora_de_Notas_POO.Repositories;
using System;
using Microsoft.Identity.Client;

namespace Calculadora_de_Notas_POO.Services
{
    public class MenuService
    {
        private readonly MateriaServices _materiaServices;
        private readonly NotaServices _notaServices;

        public MenuService()
        {
            _materiaServices = new MateriaServices();
            _notaServices = new NotaServices();
        }


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
                        Console.WriteLine(ConsoleColors.Colorize("Consultar Matérias Cadastradas", ConsoleColors.Green));
                        ConsultarMateriaMenu();
                        break;
                    case 2:
                        Console.WriteLine(ConsoleColors.Colorize("Cadastrar Matéria", ConsoleColors.Green));
                        CadastrarMateriaMenu();
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
                        Console.WriteLine(ConsoleColors.Colorize("Consultar Notas", ConsoleColors.Green));
                        ConsultarNotaMenu();
                        break;
                    case 2:
                        Console.WriteLine(ConsoleColors.Colorize("Cadastrar Notas", ConsoleColors.Green));
                        CadastrarNotaMenu();
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
            Console.WriteLine("1 - Consultar Matérias Cadastradas");
            Console.WriteLine("2 - Cadastrar Matéria");
            Console.WriteLine("3 - Editar Matéria");
            Console.WriteLine("4 - Deletar Matéria");
            Console.WriteLine("5 - Voltar ao Menu Principal");
            Console.WriteLine(new string('-', 60));
        }

        // Método para imprimir o menu de notas
        static void printMenuNotas()
        {
            Console.WriteLine(ConsoleColors.Colorize("Menu de Notas", ConsoleColors.Cyan));
            Console.WriteLine(ConsoleColors.Colorize("\n" + new string('=', 60), ConsoleColors.Blue));
            Console.WriteLine("1 - Consultar Notas");
            Console.WriteLine("2 - Cadastrar Notas");
            Console.WriteLine("3 - Editar Notas");
            Console.WriteLine("4 - Saber quanto precisa tirar no 2° Bimestre");
            Console.WriteLine("5 - Saber quanto precisa tirar no Exame Final");
            Console.WriteLine("6 - Ver se foi aprovado");
            Console.WriteLine("7 - Voltar ao Menu Principal");
            Console.WriteLine(ConsoleColors.Colorize("\n" + new string('=', 60), ConsoleColors.Blue));
        }

        //Método para mostrar o menu de consulta de matérias
        public void ConsultarMateriaMenu()
        {
            List<Materias> materias = _materiaServices.ListarMaterias();

            if (materias == null || materias.Count == 0)
            {
                Console.WriteLine(ConsoleColors.Colorize("Nenhuma matéria cadastrada. Por favor, cadastre uma matéria primeiro.", ConsoleColors.Red));
                Console.WriteLine(ConsoleColors.Colorize("Pressione qualquer tecla para voltar ao menu...", ConsoleColors.Yellow));
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine(ConsoleColors.Colorize("Notas cadastradas:", ConsoleColors.Green));
                foreach (var materia in materias)
                {
                    Console.WriteLine($"ID: {materia.Id}, Matéria: {materia.Nome}, Professor: {materia.Professor}, Periodo: {materia.Periodo}");
                }
            }

        }

        // Método para mostrar o menu de consulta de notas
        public void ConsultarNotaMenu()
        {
            List<Notas> notas = _notaServices.ListarNotas();

            if (notas == null || notas.Count == 0)
            {
                Console.WriteLine(ConsoleColors.Colorize("Nenhuma nota cadastrada cadastrada. Por favor, cadastre uma nota primeiro.", ConsoleColors.Red));
                Console.WriteLine(ConsoleColors.Colorize("Pressione qualquer tecla para voltar ao menu...", ConsoleColors.Yellow));
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine(ConsoleColors.Colorize("Notas cadastradas:", ConsoleColors.Green));
                foreach (var nota in notas)
                {
                    Console.WriteLine($"ID: {nota.Id}, ID Matéria: {nota.IdMateria}, Primeira Nota: {nota.PrimeiraNota}, Segunda Nota: {nota.SegundaNota}, Nota Final: {nota.NotaFinal}");
                }
            }
        }

        // Método para cadastrar uma nova matéria
        public void CadastrarMateriaMenu()
        {
            string nomeMateria = ReadString("Digite o nome da matéria: ", "Nome da matéria não pode ser vazio.");
            string nomeProfessor = ReadString("Digite o nome do professor: ", "Nome do professor não pode ser vazio.");
            int periodo = ReadInt("Digite o período (número inteiro): ", "Período inválido. Deve ser um número inteiro positivo.");

            bool sucesso = _materiaServices.CadastrarMateria(nomeMateria, nomeProfessor, periodo);

            if(sucesso)
            {
                Console.WriteLine(ConsoleColors.Colorize("Matéria cadastrada com sucesso!", ConsoleColors.Green));
            }
            else
            {
                Console.WriteLine(ConsoleColors.Colorize("Erro ao cadastrar matéria. Tente novamente", ConsoleColors.Red));
            }

            Console.WriteLine(ConsoleColors.Colorize("Pressione qualquer tecla para continuar...", ConsoleColors.Yellow));
            Console.ReadKey();
        }

        // Método para cadastrar uma nova nota
        public void CadastrarNotaMenu()
        {
            var materiasDisponiveis = _materiaServices.ListarMaterias();

            if (materiasDisponiveis == null || materiasDisponiveis.Count == 0)
            {
                Console.WriteLine(ConsoleColors.Colorize("Nenhuma matéria cadastrada. Por favor, cadastre uma matéria primeiro.", ConsoleColors.Red));
                Console.WriteLine(ConsoleColors.Colorize("Pressione qualquer tecla para voltar ao menu...", ConsoleColors.Yellow));
                Console.ReadKey();
                return;
            }
            foreach (var materia in materiasDisponiveis)
            {
                Console.WriteLine($"ID: {materia.Id} | Nome: {materia.Nome} | Periodo: {materia.Periodo}");
            }

            int idMateria = ReadInt("Digite o ID da matéria para lançar a nota: ", "ID inválido");

            if (!materiasDisponiveis.Any(m => m.Id == idMateria))
            {
                Console.WriteLine(ConsoleColors.Colorize("ID de matéria não encontrado. Tente novamente.", ConsoleColors.Red));
                Console.WriteLine(ConsoleColors.Colorize("Pressione qualquer tecla para voltar...", ConsoleColors.Yellow));
                Console.ReadKey();
                return;
            }

            decimal primeiraNota = ReadDecimal("Digite a primeira nota: ", "Nota inválida. Deve ser um número decimal positivo.", 0, 100);
            decimal segundaNota = ReadDecimal("Digite a segunda nota: ", "Nota inválida. Deve ser um número decimal positivo.", 0, 100);

            decimal media = _notaServices.CalcularMedia(primeiraNota, segundaNota);
            decimal? exameFinal = null;

            if (media < 70)
            {
                Console.WriteLine(ConsoleColors.Colorize($"\nMédia do bimestre ({media:F2}) é menor que 70. É necessário cadastrar a nota do exame final.", ConsoleColors.Yellow));
                exameFinal = ReadDecimal("Digite a nota do Exame Final: ", "Nota inválida! A nota do exame deve estar entre 0 e 100.", 0, 100);
            }

            bool sucesso = _notaServices.CadastrarNotas(idMateria, primeiraNota, segundaNota, exameFinal);

            if(sucesso)
            {
                Console.WriteLine(ConsoleColors.Colorize("Notas cadastradas com sucesso!", ConsoleColors.Green));
            }
            else
            {
                Console.WriteLine(ConsoleColors.Colorize("Ocorreu um erro ao cadastrar as notas. Tente novamente.", ConsoleColors.Red));
            }

            Console.WriteLine(ConsoleColors.Colorize("Pressione qualquer tecla para continuar...", ConsoleColors.Yellow));
            Console.ReadKey();
        }

        // Método auxiliar para ler uma string e validar senão é vazia
        private string ReadString(string prompt, string errorMassage)
        {
            while (true)
            {
                Console.Write(ConsoleColors.Colorize(prompt, ConsoleColors.Yellow));
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(ConsoleColors.Colorize(errorMassage, ConsoleColors.Red));
                }
                else
                {
                    return input;
                }
            }
        }

        // Método auxiliar para ler um inteiro e validar se é valido
        private int ReadInt(string prompt, string errorMessage)
        {
            while (true)
            {
                Console.Write(ConsoleColors.Colorize(prompt, ConsoleColors.Yellow));
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int result) || result <= 0)
                {
                    Console.WriteLine(ConsoleColors.Colorize(errorMessage, ConsoleColors.Red));
                }
                else
                {
                    return result;
                }
            }
        }

        // Método auxiliar para ler um decimal e validar se é valido
        private decimal ReadDecimal(string prompt, string errorMessage, decimal min, decimal max)
        {
            while (true)
            {
                Console.Write(ConsoleColors.Colorize(prompt, ConsoleColors.Yellow));
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input) || !decimal.TryParse(input, out decimal result) || result < min || result > max)
                {
                    Console.WriteLine(ConsoleColors.Colorize(errorMessage, ConsoleColors.Red));
                }
                else
                {
                    return result;
                }
            }
        }
    }

}
