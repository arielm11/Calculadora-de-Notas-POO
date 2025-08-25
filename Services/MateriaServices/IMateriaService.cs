using Calculadora_de_Notas_POO.Models;
using System.Collections.Generic;

namespace Calculadora_de_Notas_POO.Services.MateriaServices
{
    public interface IMateriaServices
    {
        List<Materias> ListarMaterias();
        bool CadastrarMateria(string nomeMateria, string nomeProfessor, int periodo);
        bool EditarMateria(int id, string nomeMateria, string nomeProfessor, int periodo);
        bool ExcluirMateria(int id);
    }
}
