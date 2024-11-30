using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Talent_Hub.Models;

namespace Talent_Hub.Client
{
    public class PosicionesDisponiblesClient
    {
        private HttpClient _httpClient;
        private readonly string _url = "https://localhost:44374/api/posicionesDisponibles";

        public PosicionesDisponiblesClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> AgregarPosicion(Posiciones_Disponibles posicion)
        {
            var jsonContent = JsonConvert.SerializeObject(posicion);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_url}/agregar", content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> ActualizarPosicion(Posiciones_Disponibles posicion)
        {
            var jsonContent = JsonConvert.SerializeObject(posicion);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_url}/update", content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> BuscarPosicionPorNombre(string nombre)
        {
            var response = await _httpClient.GetAsync($"{_url}/buscar/{nombre}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
    }
}