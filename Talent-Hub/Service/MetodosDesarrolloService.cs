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
    public class MetodosDesarrolloService : MetodosDesarrolloRepository
    {
        public readonly string connectionString;

        public MetodosDesarrolloService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TalentHubConnection"].ConnectionString;
        }

        public void agregarMetodoDesarrollo(Metodos_Desarrollo metodos_Desarrollo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Metodos_Desarrollo (Nombre_metodo, Descripcion, Habilidades_desarrolla)" +
                        "VALUES (@Nombre_metodo, @Descripcion, @Habilidades_desarrolla)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_metodo", metodos_Desarrollo.Nombre_metodo);
                        command.Parameters.AddWithValue("@Descripcion", metodos_Desarrollo.Descripcion);
                        command.Parameters.AddWithValue("@Habilidades_desarrolla", metodos_Desarrollo.Habilidades_desarrolla);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine($"Metodo de desarrollo agregado exitosamente");
                        else
                            Console.WriteLine("No se pudo agregar el metodo de desarrollo");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agregar el metodo de desarrollo {ex.Message}");
            }
        }
        public void updateMetodoDesarrollo(Metodos_Desarrollo metodos_Desarrollo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Metodos_Desarrollo" +
                        "SET Nombre_metodo = @Nombre_metodo, Descripcion = @Descripcion, Habilidades_desarrolla = @Habilidades_desarrolla" +
                        "WHERE Id_metodo = @Id_metodo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id_metodo", metodos_Desarrollo.Id_metodo);
                        command.Parameters.AddWithValue("@Nombre_metodo", metodos_Desarrollo.Nombre_metodo);
                        command.Parameters.AddWithValue("@Descripcion", metodos_Desarrollo.Descripcion);
                        command.Parameters.AddWithValue("@Habilidades_desarrolla", metodos_Desarrollo.Habilidades_desarrolla);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine("Metodo de desarrollo actualizado exitosamente.");
                        else
                            Console.WriteLine("No se pudo actualizar el método de desarrollo.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar el metodo de desarrollo: {ex.Message}");
            }
        }

        public List<Metodos_Desarrollo> buscarPorNombre(string nombre_metodo)
        {
            List<Metodos_Desarrollo> metodos_Desarrollos = new List<Metodos_Desarrollo>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Metodos_Desarrollo WHERE Nombre_metodo LIKE @Nombe_metodo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_metodo", "%" + nombre_metodo + "%");
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            metodos_Desarrollos.Add(new Metodos_Desarrollo
                            {
                                Id_metodo = Convert.ToInt32(reader["Id_Metodo"]),
                                Nombre_metodo = reader["Nombre_metodo"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Habilidades_desarrolla = reader["Habilidades_desarrolla"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el metodo de desarrollo: {ex.Message}");
            }
            return metodos_Desarrollos;
        }
    }
}