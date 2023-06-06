using BlogNotas_Cliente.model.api;
using BlogNotas_Cliente.model.objetos;
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
using System.Windows.Shapes;

namespace BlogNotas_Cliente
{
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            CargarPrioridades();
        }

        private async void CargarPrioridades()
        {
            RespuestaPrioridades respuestaPrioridades = await ServicioPrioridades.ConsultarPrioridades();
            if (!respuestaPrioridades.error)
            {
                Prioridad prioridad = new Prioridad();
                prioridad.prioridad_id = 2;
                prioridad.nombre = "Todas";
                cb_Prioridad.DisplayMemberPath = "nombre";
                cb_Prioridad.Items.Add(prioridad);
                foreach (Prioridad priori in respuestaPrioridades.Prioridades)
                {
                    cb_Prioridad.Items.Add(priori);
                }
                
            } else
            {
                MessageBox.Show(respuestaPrioridades.mensaje);
            }
        }

        private void CrearLibreta(object sender, RoutedEventArgs e)
        {

        }

        private void ModificarLibreta(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarLibreta(object sender, RoutedEventArgs e)
        {

        }

        private void CrearNota(object sender, RoutedEventArgs e)
        {

        }

        private void ModificarNota(object sender, RoutedEventArgs e)
        {

        }

        private void EliminarNota(object sender, RoutedEventArgs e)
        {

        }
    }
}
