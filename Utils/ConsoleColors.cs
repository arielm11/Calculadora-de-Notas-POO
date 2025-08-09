using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_Notas_POO.Utils
{
    public class ConsoleColors
    {
        public const string Red = "\u001b[31m";
        public const string Green = "\u001b[32m";
        public const string Yellow = "\u001b[33m";
        public const string Blue = "\u001b[34m";
        public const string Cyan = "\u001b[36m";
        public const string Reset = "\u001b[0m";
        public const string Bold = "\u001b[1m";

        public static string Colorize(string text, string colorCode)
        {
            return $"{colorCode}{text}{Reset}";
        }

        public static string BoldText(string text)
        {
            return $"{Bold}{text}{Reset}";
        }
    }
}
