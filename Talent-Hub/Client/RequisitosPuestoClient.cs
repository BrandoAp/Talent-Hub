using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Talent_Hub.Models;
using Newtonsoft.Json;
using System.Text;

namespace Talent_Hub.Client
{
    public class RequisitosPuestoClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUri = "https://localhost:44374/api/registroPuesto";

        public RequisitosPuestoClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> AgregarRequisito (Requisitos_Puesto requisitos)
        {
            var jsonContent = JsonConvert.SerializeObject(requisitos);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUri}/agregar", content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }
    }
}