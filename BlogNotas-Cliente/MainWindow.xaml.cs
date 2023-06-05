using BlogNotas_Cliente.model.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            }
            else
            {
                MessageBox.Show("Se necesitan el telefono y la contraseña para iniciar sesion", "Atencion", MessageBoxButton.OK);
            }
        }

        private void Registrar(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = System.Windows.MessageBox.Show("El registro no se podrá cancelar", "¿Confirmar registro?", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                if (FormularioLleno())
                {

                }
            }
        }

        private void ValidarTexto(object sender, TextCompositionEventArgs e)
        {
            int character = Convert.ToInt32(Convert.ToChar(e.Text));
            if ((character >= 65 && character <= 90) || (character >= 97 && character <= 122))
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
    }
}
