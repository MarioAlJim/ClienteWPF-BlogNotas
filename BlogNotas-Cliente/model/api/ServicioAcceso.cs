using BlogNotas_Cliente.model.objetos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text.Json;
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
                    { "contraseña", usuario.contrasena }
                };

                request.Content = new FormUrlEncodedContent(parametros);

                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            resultado.Estado = false;
                            resultado.Mensaje = "Registro exitoso";
                        }
                        else
                        {
                            resultado.Estado = true;
                            resultado.Mensaje = "Error en la solicitud: " + response.StatusCode;
                        }
                    }
                    Console.WriteLine("Código de estado: " + resultado.Estado);
                    Console.WriteLine("Mensaje: " + resultado.Mensaje);
                }
                catch (HttpRequestException ex)
                {
                    resultado.Estado = true;
                    resultado.Mensaje = "Error en la solicitud: " + ex.Message;
                }
                catch (Exception ex)
                {
                    resultado.Estado = true;
                    resultado.Mensaje = "Error en la solicitud: " + ex.Message;
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
                    { "contraseña", contrasena }
                };

                request.Content = new FormUrlEncodedContent(parametros);

                try
                {
                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            var respuestaApi = JsonSerializer.Deserialize<RespuestaAcceso>(jsonResponse);

                            resultado.Estado = respuestaApi.Estado;
                            resultado.Mensaje = respuestaApi.Mensaje;
                            resultado.SesionToken = respuestaApi.SesionToken;
                            resultado.UsuarioActual = respuestaApi.UsuarioActual;
                        }
                        else
                        {
                            resultado.Estado = true;
                            resultado.Mensaje = "Error en la solicitud: " + response.StatusCode;
                        }
                    }

                    Console.WriteLine("Código de estado: " + resultado.Estado);
                    Console.WriteLine("Mensaje: " + resultado.Mensaje);
                }
                catch (HttpRequestException ex)
                {
                    resultado.Estado = true;
                    resultado.Mensaje = "Error en la solicitud: " + ex.Message;
                }
                catch (Exception ex)
                {
                    resultado.Estado = true;
                    resultado.Mensaje = "Error en la solicitud: " + ex.Message;
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
                        if (response.IsSuccessStatusCode)
                        {
                            resultado.Estado = false;
                            resultado.Mensaje = await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            resultado.Estado = true;
                            resultado.Mensaje = "Error en la solicitud: " + response.StatusCode;
                        }
                    }

                    Console.WriteLine("Código de estado: " + resultado.Estado);
                    Console.WriteLine("Mensaje: " + resultado.Mensaje);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine("Error en la solicitud HTTP: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error general: " + ex.Message);
                }
            }

            return resultado;
        }
    }
}
