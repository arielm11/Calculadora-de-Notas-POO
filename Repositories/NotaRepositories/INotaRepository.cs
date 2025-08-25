using Calculadora_de_Notas_POO.Models;

namespace Calculadora_de_Notas_POO.Repositories.NotaRepositories
{
    public interface INotaRepository
    {
        List<Notas> ListarNotas();
        bool CadastrarNota(Notas nota);
        bool EditarNota(Notas nota);
        bool DeletarNota(int id);
    }
}
