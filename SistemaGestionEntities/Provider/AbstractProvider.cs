using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities.Provider
{
    public abstract class AbstractProvider
    {
        private readonly HttpClient _httpClient;
        protected readonly string _host;

        protected AbstractProvider()
        {
            _httpClient = new HttpClient();
            _host = @"https://localhost:7168";
        }

        protected virtual T GetJson<T>(string recurso) where T : class
        {
            string url = $"{_host}/{recurso}";
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            try
            {
                HttpResponseMessage? response = _httpClient.Send(httpRequestMessage);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"La respuesta no fue exitosa, se obtuvo un estado {response.StatusCode}");
                }
                Task<T?> resultado = response.Content.ReadFromJsonAsync<T>();
                resultado.Wait();
                return resultado.Result!;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al procesar la solicitud get de json", ex);
            }
        }
    }
}
