using BlogNotas_Cliente.model.objetos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogNotas_Cliente.model.api
{
    public class ServicioAcceso
    {
         
        private static readonly string origin = "https://TeamWolfApi.com";
        private static readonly string authorization = "Basic QXBpQmxvZ05vdGFzV1M6NmFCeTJZMUFWNlVBdDdNMm1DOEk=";

        public static async Task<RespuestaGenerica> Registrar(Usuario usuario)
        {
            string url = "http://localhost:8084/WebServiceBlogNotas/api/bsc/acceso/registro";
            RespuestaGenerica resultado = new RespuestaGenerica();
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Origin", origin);
                request.Headers.Add("Authorization", authorization);

                var parametros = new Dictionary<string, string>
                {
                    { "nombre", usuario.nombres },
                    { "apellidos", usuario.apellidos },
                    { "celular", usuario.celular },
                    { "contrasena", usuario.contrasena }
                };

                request.Content = new FormUrlEncodedContent(parametros);

                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response != null)
                    {
                        resultado = await response.Content.ReadFromJsonAsync<RespuestaGenerica>();
                    }
                }
                catch (HttpRequestException ex)
                {
                    resultado.error = true;
                    resultado.mensaje = "No se pudo conectar con el servidor";
                }
                catch (Exception ex)
                {
                    resultado.error = true;
                    resultado.mensaje = "No se pudo conectar con el servidor";
                }
            }
            return resultado;
        }


        public static async Task<RespuestaAcceso> IniciarSesion(String celular, String contrasena)
        {
            string url = "http://localhost:8084/WebServiceBlogNotas/api/bsc/acceso/login";
            RespuestaAcceso resultado = new RespuestaAcceso();
            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Origin", origin);
                request.Headers.Add("Authorization", authorization);

                var parametros = new Dictionary<string, string>
                {
                    { "celular", celular },
                    { "contrasena", contrasena }
                };

                request.Content = new FormUrlEncodedContent(parametros);
                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response != null)
                    {
                        resultado = await response.Content.ReadFromJsonAsync<RespuestaAcceso>();
                    }
                }
                catch (HttpRequestException ex)
                {
                    resultado.error = true;
                    resultado.mensaje = "No se pudo conectar con el servidor";
                }
                catch (Exception ex)
                {
                    resultado.error = true;
                    resultado.mensaje = "No se pudo conectar con el servidor";
                }
            }
            return resultado;
        }

        public static async Task<RespuestaGenerica> ActivarCuenta(string celular, string otp)
        {
            string url = "http://localhost:8084/WebServiceBlogNotas/api/bsc/acceso/activar";

            RespuestaGenerica resultado = new RespuestaGenerica();

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("Origin", origin);
                request.Headers.Add("Authorization", authorization);

                var parametros = new Dictionary<string, string>
                {
                    { "celular", celular },
                    { "otp", otp }
                };

                request.Content = new FormUrlEncodedContent(parametros);

                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response != null)
                    {
                        resultado = await response.Content.ReadFromJsonAsync<RespuestaGenerica>();
                    }
                }
                catch (HttpRequestException ex)
                {
                    resultado.error = false;
                    resultado.mensaje = "No se pudo conectar con el servidor";
                }
                catch (Exception ex)
                {
                    resultado.error = false;
                    resultado.mensaje = "No se pudo conectar con el servidor";
                }
            }
            return resultado;
        }
    }
}
