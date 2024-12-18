﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Talent_Hub.Models;
using System.Security.Policy;

namespace Talent_Hub.Client
{
    public class PosicionesDisponiblesClient
    {
        private HttpClient _httpClient;
        private readonly string _url = "https://localhost:44374/api/posiciones";

        public PosicionesDisponiblesClient()
        {
            _httpClient = new HttpClient();
        }

        //public async Task<string> listarPosiciones()
        //{
        //    var response = await _httpClient.GetAsync($"{_url}/listarPosiciones");
        //    if (response.IsSuccessStatusCode)
        //        return await response.Content.ReadAsStringAsync();

        //    return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        //}

        public async Task<string> AgregarPosicion(Posiciones_Disponibles posicion)
        {
            var jsonContent = JsonConvert.SerializeObject(posicion);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_url}/agregar", content);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsStringAsync();

            return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
        }


        public async Task<List<Posiciones_Disponibles>> BuscarPosicionPorNombre(string nombre)
        {
            try
            {
                var encodedName = Uri.EscapeDataString(nombre);
                var respone = await _httpClient.GetAsync($"{_url}/buscar/{encodedName}");
                respone.EnsureSuccessStatusCode();

                var jsonResult = await respone.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Posiciones_Disponibles>>(jsonResult);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error al buscar la posicion: {ex.Message}");
            }
        }
    }
}