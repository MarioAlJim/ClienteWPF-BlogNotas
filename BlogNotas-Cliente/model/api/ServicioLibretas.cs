using BlogNotas_Cliente.Utileria;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace BlogNotas_Cliente.model.api
{
    public class ServicioLibretas
    {
        private static readonly string origin = "https://TeamWolfApi.com";
        private static readonly String authorization = ("Bearer " + UsuarioActivo.ObtenerUsuarioActivo().SesionToken);


        public static async Task<RespuestaLibreta> ObtenerLibretas()
        {
            string url = "http://localhost:8084/WebServiceBlogNotas/api/auth/libreta/consultar/" + UsuarioActivo.ObtenerUsuarioActivo().Usuario.usuario_id;
            RespuestaLibreta resultado = new();
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("Origin", origin);
                request.Headers.Add("Authorization", authorization);
                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response != null)
                    {
                        resultado = await response.Content.ReadFromJsonAsync<RespuestaLibreta>();
                    }
                }
                catch (HttpRequestException ex)
                {
                    resultado.error = true;
                    resultado.mensaje = "No se pudo conectar con el servidor error http";
                }
                catch (Exception ex)
                {
                    resultado.error = true;
                    resultado.mensaje = "No se pudo conectar con el servidor error json";
                }
            }
            return resultado;
        }
    }
}
