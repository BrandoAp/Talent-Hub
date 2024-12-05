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
    public class EmpleadosClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:44374/api/empleados";

        public EmpleadosClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> AddEmpleado(Empleado empleado)
        {
            var content = new StringContent(JsonConvert.SerializeObject(empleado), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_url}/añadir", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> listarEmpleados()
        {
            var response = await _httpClient.GetAsync($"{_url}/listarEmpleados");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> BuscarPorNombre(string nombre)
        {
            var response = await _httpClient.GetAsync($"{_url}/buscar/{nombre}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> UpdateEmpleado(Empleado empleado)
        {
            var content = new StringContent(JsonConvert.SerializeObject(empleado), Encoding.UTF8, "apllication/json");
            var response = await _httpClient.PutAsync($"{_url}/update", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} -  {response.ReasonPhrase}";
        }

        public async Task<string> AsignarMetodo(int idEmpleado, int idMetodo)
        {
            var content = new StringContent(JsonConvert.SerializeObject(new { idEmpleado, idMetodo }), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_url}/asignarMetodo", content);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> CompletarMetodo(int idCompletado)
        {
            var response = await _httpClient.PostAsync($"{_url}/completarMetodo?idCompletado={idCompletado}", null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
    }
}