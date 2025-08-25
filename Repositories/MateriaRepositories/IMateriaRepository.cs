using Calculadora_de_Notas_POO.Models;

namespace Calculadora_de_Notas_POO.Repositories.MateriaRepositories
{
    public interface IMateriaRepository
    {
        List<Materias> ListarMaterias();
        bool CadastrarMateria(Materias materia);
        bool EditarMateria(Materias materia);
        bool DeletarMateria(int id);
    }
}
