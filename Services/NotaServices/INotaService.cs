using Calculadora_de_Notas_POO.Models;
using System.Collections.Generic;

namespace Calculadora_de_Notas_POO.Services.NotaServices
{
    public interface INotaServices
    {
        List<Notas> ListarNotas();
        bool CadastrarNotas(int idMateria, decimal primeiraNota, decimal segundaNota, decimal? exameFinal = null);
        bool EditarNotas(int id, decimal primeiraNota, decimal segundaNota, decimal? exameFinal = null);
        bool ExcluirNota(int id);
        decimal CalcularMedia(decimal primeiraNota, decimal segundaNota);
        decimal CalcularNota2Bimestre(decimal nota1);
        decimal CalcularNotaExameFinal(decimal exameFinal, decimal mediaBimestral);
    }
}
