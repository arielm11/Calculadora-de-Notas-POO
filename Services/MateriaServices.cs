using Calculadora_de_Notas_POO.Models;
using Calculadora_de_Notas_POO.Repositories;
using Calculadora_de_Notas_POO.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_Notas_POO.Services
{
    public class MateriaServices
    {
        private readonly MateriaRepository _repository;
        public MateriaServices()
        {
            _repository = new MateriaRepository();
        }
        
        // Método para listar todas as matérias cadastradas
        public void ListarMaterias()
        {
            var materias = _repository.ListarMaterias();

            if (materias == null || materias.Count == 0)
            { 
                Console.WriteLine(ConsoleColors.Colorize("Nenhuma matéria cadastrada.", ConsoleColors.Red));
                return;
            }
            Console.WriteLine(ConsoleColors.Colorize("Matérias Cadastradas:", ConsoleColors.Green));
            foreach (var materia in materias)
            { 
                Console.WriteLine($"ID: {materia.Id}, Nome: {materia.Nome}, Professor: {materia.Professor}, Período: {materia.Periodo}");
            }
        }

        // Método para cadastrar uma nova matéria
        public void CadastrarMateria()
        {
            Console.Write(ConsoleColors.Colorize("Digite o nome da matéria: ", ConsoleColors.Yellow));
            string? nome = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine(ConsoleColors.Colorize("Nome da matéria não pode ser vazio.", ConsoleColors.Red));
                return;
            }
            Console.Write(ConsoleColors.Colorize("Digite o nome do professor: ", ConsoleColors.Yellow));
            string? professor = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(professor))
            {
                Console.WriteLine(ConsoleColors.Colorize("Nome do professor não pode ser vazio.", ConsoleColors.Red));
                return;
            }
            Console.Write(ConsoleColors.Colorize("Digite o período (número inteiro): ", ConsoleColors.Yellow));
            string? periodoInput = Console.ReadLine();
            if (!int.TryParse(periodoInput, out int periodo) || periodo <= 0)
            {
                Console.WriteLine(ConsoleColors.Colorize("Período inválido. Deve ser um número inteiro positivo.", ConsoleColors.Red));
                return;
            }
            var novaMateria = new Materias
            {
                Nome = nome,
                Professor = professor,
                Periodo = periodo
            };
            _repository.CadastrarMateria(novaMateria);
        }
    }
}
