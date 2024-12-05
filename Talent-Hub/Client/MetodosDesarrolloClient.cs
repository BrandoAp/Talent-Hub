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
    public class MetodosDesarrolloClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:44374/api/metodosDesarrollo";

        public MetodosDesarrolloClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> AgregarMetodo(Metodos_Desarrollo metodo)
        {
            var content = new StringContent(JsonConvert.SerializeObject(metodo), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_url}/agregar", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> ActualizarMetodo(Metodos_Desarrollo metodo)
        {
            var jsonContent = JsonConvert.SerializeObject(metodo);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_url}/update", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        // Método para buscar métodos de desarrollo por nombre
        public async Task<string> BuscarMetodoPorNombre(string nombre)
        {
            var response = await _httpClient.GetAsync($"{_url}/buscar/{nombre}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
    }
}