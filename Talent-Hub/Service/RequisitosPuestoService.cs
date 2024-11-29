using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Talent_Hub.Models;
using Talent_Hub.Repository;

namespace Talent_Hub.Service
{
    public class RequisitosPuestoService : RequisitosPuestoRepository
    {
        private readonly string connectionString;
        public RequisitosPuestoService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TalentHubConnection"].ConnectionString;
        }

        public void agregarRequisitos(Requisitos_Puesto requisitos_puesto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Requisitos_Puesto (Id_puesto, Id_metodo)" +
                        "VALUES (@Id_puesto, @Id_metodo)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_puesto", requisitos_puesto.Id_puesto);
                        command.Parameters.AddWithValue("@Id_metodo", requisitos_puesto.Id_metodo);
                        connection.Open();

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Requisito agregado correctamente");
                        else
                            Console.WriteLine("No se ha podido guardar el requisito");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar el requisito para el puesto {ex.Message}");
            }
        }
    }
}