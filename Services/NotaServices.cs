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
    public class NotaServices
    {
        private readonly NotaRepository _repository;
        public NotaServices()
        {
            _repository = new NotaRepository();
        }

        // Método para listar todas as notas cadastradas
        public void ListarNotas()
        { 
            var notas = _repository.ListarNotas();

            if (notas == null || notas.Count == 0)
            { 
                Console.WriteLine(ConsoleColors.Colorize("Nenhuma nota cadastrada.", ConsoleColors.Red));
                return;
            }
            Console.WriteLine(ConsoleColors.Colorize("Notas Cadastradas:", ConsoleColors.Green));
            foreach (var nota in notas)
            { 
                Console.WriteLine($"ID: {nota.Id}, ID Matéria: {nota.IdMateria}, Primeira Nota: {nota.PrimeiraNota}, Segunda Nota: {nota.SegundaNota}, Exame Final: {nota.ExameFinal}, Nota Final: {nota.NotaFinal}");
            }
        }
    }
}
