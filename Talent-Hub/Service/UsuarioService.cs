using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Talent_Hub.Models;
using Talent_Hub.Repository;

namespace Talent_Hub.Service
{
    public class UsuarioService : UsuarioRepository
    {
        private readonly string connectionString;
        public UsuarioService()
        {
            connectionString = ConfigurationManager.ConnectionStrings["TalentHubConnection"].ConnectionString;
        }

        public bool RegistrarUsuario(Usuario usuario)
        {
            try
            {
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =
                        "INSERT INTO Usuario (Nombre_usuario, Contraseña) VALUES (@Nombre_usuario, @Contraseña)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_usuario", usuario.Nombre_usuario);
                        command.Parameters.AddWithValue("@Contraseña", hashedPassword);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al registrar el usuario: {ex.Message}");
                return false;
            }
        }

        public bool login(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT Contraseña FROM Usuario WHERE Nombre_usuario = @Nombre_usuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_usuario", username);
                        connection.Open();

                        string hashedPassword = command.ExecuteScalar()?.ToString();
                        if (!string.IsNullOrEmpty(hashedPassword))
                            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                    }
                }
                return false;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error al validar el usuario: {ex.Message}");
                return false;
            }
        }

        public bool ExisteUsuario(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query =
                        "SELECT COUNT(*) FROM Usuario WHERE Nombre_usuario = @Nombre_usuario";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre_usuario", username);
                        connection.Open();
                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar usuario: {ex.Message}");
                return false;
            }
        }
    }
}