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
    public class PosicionesDisponiblesService : PosicionesDisponiblesRepository
    {
        private readonly string connectionString;

        public PosicionesDisponiblesService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TalentHubConnection"].ConnectionString;
        }

        public void agregarPosicion(Posiciones_Disponibles posiciones_Disponibles)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Posiciones_Disponibles (Nombre_puesto, Departamento)" +
                        "VALUES (@Nombre_puesto, @Departamento)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_puesto", posiciones_Disponibles.Nombre_puesto);
                        command.Parameters.AddWithValue("@Departamento", posiciones_Disponibles.Departamento);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Posicion agregada correctamente");
                        else
                            Console.WriteLine("No se pudo agregar la posicion");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar la posicion: {ex.Message}");
            }
        }
        public void updatePosicion(Posiciones_Disponibles posiciones_Disponibles)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Posiciones_Disponibles" +
                        "SET Nombre_puesto = @Nombre_puesto, Departamento = @Departamento" +
                        "WHERE Id_puesto = @Id_puesto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_puesto", posiciones_Disponibles.Nombre_puesto);
                        command.Parameters.AddWithValue("@Departamento", posiciones_Disponibles.Departamento);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            Console.WriteLine("Posicion actualizada correctamente");
                        else
                            Console.WriteLine("No se pudo actualizar la posicion");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar actualizar la posicion: {ex.Message}");
            }
        }
        public List<Posiciones_Disponibles> buscarPorNombrePosicion(string nombre_posicion)
        {
            List<Posiciones_Disponibles> posiciones_Disponibles = new List<Posiciones_Disponibles>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Posiciones_Disponibles WHERE Nombre_pues = @Nombre_puesto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_puesto", "%" + nombre_posicion + "%");
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            posiciones_Disponibles.Add(new Posiciones_Disponibles
                            {
                                Id_puesto = Convert.ToInt32(reader["Id_puesto"]),
                                Nombre_puesto = reader["Nombre_puesto"].ToString(),
                                Departamento = reader["Departamento"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al encontrar la posicion {ex.Message}");
            }
            return posiciones_Disponibles;
        }
    }
}