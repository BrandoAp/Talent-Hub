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
    public class EmpleadoService : EmpleadoRepository
    {
        private readonly string connectionString;

        public EmpleadoService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TalentHubConnection"].ConnectionString;
        }

        public void añadirEmpleado(Empleado empleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Empleados (Nombre_empleado, Email_empleado, Posicion_actual, Habilidades) " +
                        "VALUES (@Nombre, @Email, @Posicion, @Habilidades)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", empleado.Nombre_empleado);
                        command.Parameters.AddWithValue("@Email", empleado.Email_empleado);
                        command.Parameters.AddWithValue("@Posicion", empleado.Posicion_actual);
                        command.Parameters.AddWithValue("@Habilidades", empleado.Habilidades);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar un nuevo empleado: {ex.Message}");
            }
        }

        public List<Empleado> listarEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Empleados";
                    using(SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empleados.Add(new Empleado
                                {
                                    Id_empleado = Convert.ToInt32(reader["Id_empleado"]),
                                    Nombre_empleado = reader["Nombre_empleado"].ToString(),
                                    Email_empleado = reader["Email_empleado"].ToString(),
                                    Posicion_actual = reader["Posicion_actual"].ToString(),
                                    Habilidades = reader["Habilidades"].ToString()
                                });
                            }
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            return empleados;
        }

        public List<Empleado> buscarPorNombre(string Nombre_empleado)
        {
            List<Empleado> empleados = new List<Empleado>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Empleados WHERE Nombre_empleado LIKE @Nombre";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", $"%{Nombre_empleado}%");
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                empleados.Add(new Empleado
                                {
                                    Id_empleado = Convert.ToInt32(reader["Id_empleado"]),
                                    Nombre_empleado = reader["Nombre_empleado"].ToString(),
                                    Email_empleado = reader["Email_empleado"].ToString(),
                                    Posicion_actual = reader["Posicion_actual"].ToString(),
                                    Habilidades = reader["Habilidades"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al buscar el empleado: {ex.Message}");
            }
            return empleados;
        }

        public void UpdateEmpleado(Empleado empleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Empleados " +
                                   "SET Nombre_empleado = @Nombre, Email_empleado = @Email, Posicion_actual = @Posicion, Habilidades = @Habilidades " +
                                   "WHERE Id_empleado = @Id";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre_empleado);
                    command.Parameters.AddWithValue("@Email", empleado.Email_empleado);
                    command.Parameters.AddWithValue("@Posicion", empleado.Posicion_actual);
                    command.Parameters.AddWithValue("@Habilidades", empleado.Habilidades ?? string.Empty);
                    command.Parameters.AddWithValue("@Id", empleado.Id_empleado);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar empleado: " + ex.Message);
            }
        }

        public void AsignarMetodo(int Id_empleado, int Id_metodo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string storedProcedure = "AsignarMetodoDesarrollo";

                    using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id_empleado", Id_empleado);
                        command.Parameters.AddWithValue("@Id_metodo", Id_metodo);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asignar el metodo de desarrollo: {ex.Message}");
            }
        }

        public void AsignarMetodoCompletado(int Id_completado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "CompletarMetodosDesarrollo";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id_completado", Id_completado);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine("El metodo completado se ha registrado");
                        else
                            Console.WriteLine("No se pudo registrar el metodo completado");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al asignar el metodo como completado {ex.Message}");
            }
        }
    }
}