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
        private const decimal mediaParaAprovacao = 70;
        private const decimal mediaAprovacaoExameFinal = 50;
        private const decimal pesoPrimeiraNota = 2;
        private const decimal pesoSegundaNota = 3;
        private const decimal pesoBimestral = 3;
        private const decimal pesoExameFinal = 5;

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
        
        // Método para calcular a média da primeira nota e com a segunda nota
        public decimal CalcularMedia(decimal nota1, decimal nota2)
        {
            return (nota1 * pesoPrimeiraNota + nota2 * pesoSegundaNota) / pesoExameFinal;
        }

        // Método para calcular quanto o aluno precisa tirar no 2° bimestre para passar na matéria
        public decimal CalcularNota2Bimestre(decimal nota1)
        {
            decimal media = mediaParaAprovacao * pesoExameFinal;
            decimal influenciaNota1 = nota1 * pesoPrimeiraNota;

            decimal nota2Necessaria = (media - influenciaNota1) / pesoSegundaNota;

            return nota2Necessaria;
        }

        // Método para calcular quanto o aluno precisa tirar no exame final para passar na matéria
        public decimal CalcularNotaExameFinal(decimal nota1, decimal nota2)
        {
            decimal mediaBimestral = CalcularMedia(nota1, nota2);
            decimal parteDaMedia = mediaParaAprovacao * pesoExameFinal;
            decimal influenciaNotaBimestral = mediaBimestral * pesoBimestral;
            
            decimal notaExameNecessaria = (parteDaMedia - influenciaNotaBimestral) / pesoExameFinal;
            
            return notaExameNecessaria;
        }
    }
}
