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
        public List<Materias> ListarMaterias()  
        {
            return _repository.ListarMaterias();
        }

        // Método para cadastrar uma nova matéria
        public bool CadastrarMateria(string nomeMateria, string nomeProfessor, int periodo)
        {
            var novaMateria = new Materias
            {
                Nome = nomeMateria,
                Professor = nomeProfessor,
                Periodo = periodo
            };
            return _repository.CadastrarMateria(novaMateria);
        }

        // Método para editar uma matéria existente
        public bool EditarMateria(int id, string nomeMateria, string nomeProfessor, int periodo)
        {
            var materiaExistente = _repository.ListarMaterias().FirstOrDefault(m => m.Id == id);

            if (materiaExistente == null)
            {
                Console.WriteLine(ConsoleColors.Colorize("Matéria não encontrada.", ConsoleColors.Red));
                return false;
            }
            else 
            { 
                var materiaAtualizada = new Materias
                {
                    Id = id,
                    Nome = nomeMateria,
                    Professor = nomeProfessor,
                    Periodo = periodo
                };

                return _repository.EditarMateria(materiaAtualizada);
            }
        }
    }
}
