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
    }
}
