using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Talent_Hub.Client
{
    public class EmpleadosMetodosClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://localhost:44374/api/empleadosMetodos";

        public EmpleadosMetodosClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> ObtenerEmpleadosConMetodosAsignados()
        {
            var response = await _httpClient.GetAsync($"{_url}/asignados");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }

        public async Task<string> ObtenerEmpleadosConMetodosCompletados()
        {
            var response = await _httpClient.GetAsync($"{_url}/completados");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
    }
}