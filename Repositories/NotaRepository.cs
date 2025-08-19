using Microsoft.Data.SqlClient;
using Calculadora_de_Notas_POO.Models;
using Calculadora_de_Notas_POO.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Pkcs;

namespace Calculadora_de_Notas_POO.Repositories
{
    public class NotaRepository
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=MeuBancoTeste;Trusted_Connection=True;TrustServerCertificate=True";

        // Método para listas as notas cadastradas no banco de dados
        public List<Notas> ListarNotas()
        {
            var notas = new List<Notas>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT N.COD_NOTA, N.COD_MATERIA, M.NOM_MATERIA, N.PRIMEIRA_NOTA, N.SEGUNDA_NOTA, N.EXAME_FINAL, N.NOTA_FINAL FROM Notas N JOIN Materias M ON N.COD_MATERIA = M.COD_MATERIA;\r\n";
                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            notas.Add(new Notas
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("COD_NOTA")),
                                IdMateria = reader.GetInt32(reader.GetOrdinal("COD_MATERIA")),
                                PrimeiraNota = reader.IsDBNull(reader.GetOrdinal("PRIMEIRA_NOTA")) ? 0 : reader.GetDecimal(reader.GetOrdinal("PRIMEIRA_NOTA")),
                                SegundaNota = reader.IsDBNull(reader.GetOrdinal("SEGUNDA_NOTA")) ? 0 : reader.GetDecimal(reader.GetOrdinal("SEGUNDA_NOTA")),
                                ExameFinal = reader.IsDBNull(reader.GetOrdinal("EXAME_FINAL")) ? 0 : reader.GetDecimal(reader.GetOrdinal("EXAME_FINAL")),
                                NotaFinal = reader.IsDBNull(reader.GetOrdinal("NOTA_FINAL")) ? 0 : reader.GetDecimal(reader.GetOrdinal("NOTA_FINAL"))
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ConsoleColors.Colorize($"Erro ao ler dados da nota: {ex.Message}", ConsoleColors.Red));
                        }
                    }
                }
            }
            return notas;
        }
    }
}
