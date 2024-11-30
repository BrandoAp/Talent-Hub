using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Talent_Hub.Models;

namespace Talent_Hub.Client
{
    public class UsuarioClient
    {
        private readonly HttpClient _httpClient;
        private readonly string baseUri = "https://localhost:44374/api/usuario";

        public UsuarioClient()
        {
            _httpClient = new HttpClient();
        }

        //Registrar un nuevo usuario
        public async Task<string> RegistrarUsuario(Usuario usuario)
        {
            var jsonContent = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUri}/registrar", content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
        //Login
        public async Task<string> Login(Usuario usuario)
        {
            var jsonContent = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{baseUri}/login", content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";

        }

        //Verificar si un usuario existe
        public async Task<bool> ExisteUsuario(string username)
        {
            var response = await _httpClient.GetAsync($"{baseUri}/existe/{username}");

            return response.IsSuccessStatusCode;
        }
    }
}