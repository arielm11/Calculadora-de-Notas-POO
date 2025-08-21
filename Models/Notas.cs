using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Calculadora_de_Notas_POO.Models
{
    public class Notas
    {
        public int Id { get; set; } 
        public int IdMateria { get; set; } 
        public decimal PrimeiraNota { get; set; } 
        public decimal SegundaNota { get; set; } 
        public decimal? ExameFinal { get; set; } 
        public decimal NotaFinal { get; set; }
    }
}
