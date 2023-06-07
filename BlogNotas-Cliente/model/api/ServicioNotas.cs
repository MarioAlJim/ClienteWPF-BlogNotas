using BlogNotas_Cliente.Utileria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace BlogNotas_Cliente.model.api
{
    public class ServicioNotas
    {
        private static readonly string origin = "https://TeamWolfApi.com";
        private static readonly String authorization = ("Bearer " + UsuarioActivo.ObtenerUsuarioActivo().SesionToken);

        public static async Task<RespuestaNota> ObtenerNotas(int libreta_id)
        {
            string url = "http://localhost:8084/WebServiceBlogNotas/api/auth/nota/consultar?usuario_id=" + UsuarioActivo.ObtenerUsuarioActivo().Usuario.usuario_id + "&libreta_id=" + libreta_id + "&prioridad_id=";
            RespuestaNota resultado = new();
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
                        resultado = await response.Content.ReadFromJsonAsync<RespuestaNota>();
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

        public static async Task<RespuestaNota> ObtenerNotas(int libreta_id, int prioridad_id)
        {
            string url = "http://localhost:8084/WebServiceBlogNotas/api/auth/nota/consultar?usuario_id=" + UsuarioActivo.ObtenerUsuarioActivo().Usuario.usuario_id + "&libreta_id=" + libreta_id + "&prioridad_id=" + prioridad_id;
            RespuestaNota resultado = new();
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
                        resultado = await response.Content.ReadFromJsonAsync<RespuestaNota>();
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
