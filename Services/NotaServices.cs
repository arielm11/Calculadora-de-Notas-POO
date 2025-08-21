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
        public List<Notas> ListarNotas() {
            return _repository.ListarNotas();
        }

        // Método para cadastrar uma nova nota
        public bool CadastrarNotas(int idMateria, decimal primeiraNota, decimal segundaNota, decimal? exameFinal = null)
        {
            decimal mediaBimestral = CalcularMedia(primeiraNota, segundaNota);
            decimal notaFinal = mediaBimestral;

            if (mediaBimestral < 70 && exameFinal.HasValue)
            {
                notaFinal = CalcularMedia(exameFinal.Value, mediaBimestral);
            }

            var novaNota = new Notas
            {
                IdMateria = idMateria,
                PrimeiraNota = primeiraNota,
                SegundaNota = segundaNota,
                ExameFinal = exameFinal, 
                NotaFinal = notaFinal
            };

                return _repository.CadastrarNota(novaNota);
        }

        // Método para calcular a média da primeira nota e com a segunda nota
        public decimal CalcularMedia(decimal nota1, decimal nota2)
        {
            return (nota1 * 2 + nota2 * 3) / 5;
        }

        // Método para editar uma nota existente
        public bool EditarNotas(int id, decimal primeiraNota, decimal segundaNota, decimal? exameFinal = null)
        {
            var notaExistente = _repository.ListarNotas().FirstOrDefault(n => n.Id == id);
            if (notaExistente == null)
            {
                Console.WriteLine(ConsoleColors.Colorize("Nota não encontrada.", ConsoleColors.Red));
                return false;
            }
            else 
            { 
                decimal mediaBimestral = CalcularMedia(primeiraNota, segundaNota);
                decimal notaFinal = mediaBimestral;
                if (mediaBimestral < 70 && exameFinal.HasValue)
                {
                    notaFinal = CalcularMedia(exameFinal.Value, mediaBimestral);
                }
                var notaAtualizada = new Notas
                {
                    Id = id,
                    IdMateria = notaExistente.IdMateria,
                    PrimeiraNota = primeiraNota,
                    SegundaNota = segundaNota,
                    ExameFinal = exameFinal,
                    NotaFinal = notaFinal
                };
                return _repository.EditarNota(notaAtualizada);
            }
        }

        // Método para excluir uma nota existente
        public bool ExcluirNota(int id)
        {
            var notaExistente = _repository.ListarNotas().FirstOrDefault(n => n.Id == id);
            if (notaExistente == null)
            {
                Console.WriteLine(ConsoleColors.Colorize("Nota não encontrada.", ConsoleColors.Red));
                return false;
            }
            else 
            { 
                return _repository.DeletarNota(id);
            }
        }
    }
}
