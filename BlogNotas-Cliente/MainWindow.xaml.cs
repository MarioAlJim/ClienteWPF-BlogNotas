using BlogNotas_Cliente.model.api;
using BlogNotas_Cliente.model.objetos;
using BlogNotas_Cliente.Utileria;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace BlogNotas_Cliente
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.bt_Confirmar.Visibility = Visibility.Hidden;
            this.lbl_Codigo.Visibility = Visibility.Hidden;
            this.tb_Codigo.Visibility = Visibility.Hidden;
        }


        private async void IniciarSesion(object sender, RoutedEventArgs e)
        {
            if (tb_Usuario.Text.Length > 8 && tb_Contrasenia.Password.Length > 0)
            {
                String celular = tb_Usuario.Text.Trim();
                String contrasena = tb_Contrasenia.Password.Trim();
                RespuestaAcceso respuestaAcceso = await ServicioAcceso.IniciarSesion(celular, contrasena);
                if (!respuestaAcceso.error)
                {
                    MessageBox.Show(("Bienvenido: " + respuestaAcceso.usuario.nombres), "Bienvenido", MessageBoxButton.OK);
                    UsuarioActivo.ObtenerUsuarioActivo().SesionToken = respuestaAcceso.sesionToken.tokenacceso;
                    UsuarioActivo.ObtenerUsuarioActivo().Usuario = respuestaAcceso.usuario;
                    MenuPrincipal mainMenu = new();
                    mainMenu.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(respuestaAcceso.mensaje);
                }
            }
            else
            {
                MessageBox.Show("Se necesitan el telefono y la contraseña para iniciar sesion", "Atencion", MessageBoxButton.OK);
            }
        }

        private async void Registrar(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("El registro no se podrá cancelar", "¿Confirmar registro?", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (FormularioLleno())
                {
                    ActivarFormularioRegistro(false);
                    Usuario nuevoUsuario = new Usuario();
                    string nombre = Regex.Replace(tb_Nombres.Text, @"\s+", " ");
                    nombre = nombre.Trim();
                    string apellidos = Regex.Replace(tb_Apellidos.Text, @"\s+", " ");
                    apellidos = apellidos.Trim();
                    string celular = Regex.Replace(tb_Telefono.Text, @"\s+", "");
                    string contrasena = Regex.Replace(tb_Apellidos.Text, @"\s+", "");

                    nuevoUsuario.nombres = nombre;
                    nuevoUsuario.contrasena = contrasena;
                    nuevoUsuario.celular = celular;
                    nuevoUsuario.apellidos = apellidos;

                    RespuestaGenerica respuesta = await ServicioAcceso.Registrar(nuevoUsuario);

                    if (!respuesta.error)
                    {
                        MessageBox.Show(respuesta.mensaje, "Exito");
                        ActivarFormularioRegistro(false);
                    } else
                    {
                        MessageBox.Show((respuesta.mensaje + ", Compruebe que no se ha registrado antes el celular"), "Fallido");
                    }
                }
            }
        }

        private async void Activar(object sender, RoutedEventArgs e)
        {
            if (tb_Codigo.Password.Length == 6)
            {
                string celular = Regex.Replace(tb_Apellidos.Text, @"\s+", "");
                RespuestaGenerica respuesta = await ServicioAcceso.ActivarCuenta(celular, tb_Codigo.Password);
                if (!respuesta.error)
                {
                    MessageBox.Show(respuesta.mensaje, "Exito");
                }
                else
                {
                    MessageBox.Show((respuesta.mensaje + ", Compruebe su codigo de activacion"), "Fallido");
                }
            }
        }
        private void ValidarTexto(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122) || character == 32)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void ValidarNumeros(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if (character >= 48 && character <= 57)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private bool FormularioLleno()
        {
            if (tb_Apellidos.Text.Length > 0 && tb_Contrasena.Password.ToString().Length > 0 && tb_Nombres.Text.Length > 0 && tb_Telefono.Text.Length > 0)
            {
                return true;
            }
            MessageBox.Show("Atencion", "Todos los campos deben estar llenos", MessageBoxButton.OK);
            return false;
        }

        private void ActivarFormularioRegistro (Boolean activar)
        {
            if (activar)
            {
                bt_Registrarse.IsEnabled = true;
                tb_Apellidos.IsEnabled = true;
                tb_Nombres.IsEnabled = true;
                tb_Contrasena.IsEnabled = true;
                tb_Telefono.IsEnabled = true;
                tb_Codigo.IsEnabled = false;
                bt_Confirmar.IsEnabled = false;
                tb_Codigo.Visibility = Visibility.Hidden;
                bt_Confirmar.Visibility = Visibility.Hidden;
                lbl_Codigo.Visibility = Visibility.Hidden;
            }
            else
            {
                bt_Registrarse.IsEnabled = false;
                tb_Apellidos.IsEnabled = false;
                tb_Nombres.IsEnabled = false;
                tb_Contrasena.IsEnabled = false;
                tb_Telefono.IsEnabled = false;
                tb_Codigo.IsEnabled = true;
                bt_Confirmar.IsEnabled = true;
                tb_Codigo.Visibility = Visibility.Visible;
                bt_Confirmar.Visibility = Visibility.Visible;
                lbl_Codigo.Visibility = Visibility.Visible;
            }
        }
    }
}
