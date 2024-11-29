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
    public class EmpleadoMetodoService : EmpleadosMetodosRepository
    {
        private readonly string connectionString;

        public EmpleadoMetodoService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TalentHubConnection"].ConnectionString;
        }

        public List<Empleados_Metodos> ObtenerEmpleadosConMetodosAsignados()
        {
            List<Empleados_Metodos> empleados_Metodos = new List<Empleados_Metodos>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Vista_EmpleadosConMetodosAsignados";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        empleados_Metodos.Add(new Empleados_Metodos
                        {
                            Id_empleado = Convert.ToInt32(reader["Id_empleado"]),
                            Nombre_empleado = reader["Nombre_empleado"].ToString(),
                            Email_empleado = reader["Email_empleado"].ToString(),
                            Posicion_actual = reader["Posicion_actual"].ToString(),
                            Id_metodo = Convert.ToInt32(reader["Id_metodo"]),
                            Nombre_metodo = reader["Nombre_metodo"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Fecha_asignado = Convert.ToDateTime(reader["Fecha_asignado"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return empleados_Metodos;
        }

        public List<Empleados_Metodos> ObtenerEmpleadosConMetodosCompletados()
        {
            List<Empleados_Metodos> empleadosMetodos = new List<Empleados_Metodos>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Vista_EmpleadosConMetodosCompletados";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        empleadosMetodos.Add(new Empleados_Metodos
                        {
                            Id_empleado = Convert.ToInt32(reader["Id_empleado"]),
                            Nombre_empleado = reader["Nombre_empleado"].ToString(),
                            Email_empleado = reader["Email_empleado"].ToString(),
                            Posicion_actual = reader["Posicion_actual"].ToString(),
                            Id_metodo = Convert.ToInt32(reader["Id_metodo"]),
                            Nombre_metodo = reader["Nombre_metodo"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Fecha_asignado = reader["Fecha_completado"] != DBNull.Value
                                             ? Convert.ToDateTime(reader["Fecha_completado"])
                                             : DateTime.MinValue
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener empleados con métodos completados: " + ex.Message);
            }

            return empleadosMetodos;
        }
    }
}