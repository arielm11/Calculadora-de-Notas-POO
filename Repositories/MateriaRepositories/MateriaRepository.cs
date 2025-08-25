using Microsoft.Data.SqlClient;
using Calculadora_de_Notas_POO.Models;
using Calculadora_de_Notas_POO.Utils;

namespace Calculadora_de_Notas_POO.Repositories.MateriaRepositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly string connectionString = "Server=.\\SQLEXPRESS;Database=MeuBancoTeste;Trusted_Connection=True;TrustServerCertificate=True";

        // Método para listas as matérias cadastradas no banco de dados
        public List<Materias> ListarMaterias()
        {
            var materias = new List<Materias>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Materias";
                using (var cmd = new SqlCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            materias.Add(new Materias
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("COD_MATERIA")),
                                Nome = reader.GetString(reader.GetOrdinal("NOM_MATERIA")),
                                Professor = reader.GetString(reader.GetOrdinal("NOM_PROFESSOR")),
                                Periodo = Convert.ToInt32(reader["PERIODO"])
                            });
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ConsoleColors.Colorize($"Erro ao ler dados da matéria: {ex.Message}", ConsoleColors.Red));
                        }
                    }
                }
            }
            return materias;
        }

        // Método para cadastrar uma nova matéria no banco de dados
        public bool CadastrarMateria(Materias materia)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Materias (NOM_MATERIA, NOM_PROFESSOR, PERIODO) VALUES (@Nome, @Professor, @Periodo)";

                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nome", materia.Nome);
                    cmd.Parameters.AddWithValue("@Professor", materia.Professor);
                    cmd.Parameters.AddWithValue("@Periodo", materia.Periodo);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        // Método para editar uma matéria existente no banco de dados
        public bool EditarMateria(Materias materia)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Materias SET NOM_MATERIA = @Nome, NOM_PROFESSOR = @Professor, PERIODO = @Periodo WHERE COD_MATERIA = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", materia.Id);
                    cmd.Parameters.AddWithValue("@Nome", materia.Nome);
                    cmd.Parameters.AddWithValue("@Professor", materia.Professor);
                    cmd.Parameters.AddWithValue("@Periodo", materia.Periodo);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }

        // Método para deletar uma matéria existente no banco de dados
        public bool DeletarMateria(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Materias WHERE COD_MATERIA = @Id";
                using (var cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
