using BlogNotas_Cliente.model.api;
using BlogNotas_Cliente.model.objetos;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace BlogNotas_Cliente
{
    public partial class MenuPrincipal : Window
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            CargarPrioridades();
            CargarLibretas();
            bloquearCrudNotas(false);
            BloquerarModificacionLibreta(false);
            cb_Prioridad.IsEnabled = false;
        }

        private List<Libreta> listaLibretas = new List<Libreta>();

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


        private async void CargarLibretas()
        {
            RespuestaLibreta respuestaLibreta = await ServicioLibretas.ObtenerLibretas();
            if (respuestaLibreta.libretas != null)
            {
                listaLibretas = respuestaLibreta.libretas;
                foreach (Libreta lib in respuestaLibreta.libretas)
                { 
                    ListBoxItem item = new ListBoxItem();
                    item.Content = lib.nombre;

                    // Convertir el color hexadecimal a un objeto SolidColorBrush
                    Color color = (Color)ColorConverter.ConvertFromString(lib.color);
                    SolidColorBrush brush = new SolidColorBrush(color);

                    item.Background = brush;
                    lb_Libretas.Items.Add(item);
                }
            } else
            {
                MessageBox.Show(respuestaLibreta.mensaje);
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
            bloquearCrudNotas(true);
            MessageBoxResult result = MessageBox.Show("Eliminacion de libreta", "¿Confirmar Eliminacion?", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {

            }
        }

        private async void MostrarNotas(object sender, SelectionChangedEventArgs e)
        {
            lb_Notas.ItemsSource = null;
            BloquerarModificacionLibreta(true);
            ListBoxItem listBoxItem = (ListBoxItem)lb_Libretas.SelectedItem;
            string libretaSeleccionada = listBoxItem.Content.ToString();
            if (libretaSeleccionada != null)
            {
                int libreta_id = 0;
                foreach (Libreta libreta in listaLibretas)
                {
                    if(libretaSeleccionada.Equals(libreta.nombre))
                    {
                        libreta_id = libreta.libreta_id;
                    }
                }
                if (libreta_id != 0)
                {
                    RespuestaNota respuestaNota = await ServicioNotas.ObtenerNotas(libreta_id);
                    cb_Prioridad.IsEnabled = true;
                    lb_Notas.DisplayMemberPath = "titulo";
                    if (respuestaNota != null)
                    {
                        lb_Notas.ItemsSource = respuestaNota.notas;
                    } else
                    {
                        MessageBox.Show(respuestaNota.mensaje);
                    }
                }
            }
        }

        private async void MostrarNotasPrioridad(object sender, SelectionChangedEventArgs e)
        {
            lb_Notas.ItemsSource = null;
            if (cb_Prioridad.SelectedIndex == 0)
            {
                MostrarNotas(sender, e);
            }
            else
            {
                BloquerarModificacionLibreta(false);
                ListBoxItem listBoxItem = (ListBoxItem)lb_Libretas.SelectedItem;
                Prioridad prioridadSeleccionada = (Prioridad)cb_Prioridad.SelectedItem;
                string libretaSeleccionada = listBoxItem.Content.ToString();
                if (libretaSeleccionada != null && prioridadSeleccionada != null)
                {
                    int libreta_id = 0;
                    foreach (Libreta libreta in listaLibretas)
                    {
                        if (libretaSeleccionada.Equals(libreta.nombre))
                        {
                            libreta_id = libreta.libreta_id;
                        }
                    }
                    RespuestaNota respuestaNota = await ServicioNotas.ObtenerNotas(libreta_id, prioridadSeleccionada.prioridad_id);

                    if (respuestaNota != null)
                    {
                        lb_Notas.ItemsSource = respuestaNota.notas;
                    }
                    else
                    {
                        MessageBox.Show(respuestaNota.mensaje);
                    }
                }
            }
        }

        private void MostrarContenidoNotas(object sender, SelectionChangedEventArgs e)
        {
            bloquearCrudNotas(true);
            Nota notaSeleccionada = (Nota)lb_Notas.SelectedItem;
            if (notaSeleccionada != null)
            {
                tb_Contenido.Text = notaSeleccionada.contenido;
            }
        }

        private void CrearNota(object sender, RoutedEventArgs e)
        {
            
        }

        private void ModificarNota(object sender, RoutedEventArgs e)
        {
            
        }

        private void EliminarNota(object sender, RoutedEventArgs e)
        {
            bloquearCrudNotas(true);
        }

        private void bloquearCrudNotas(bool bloquear)
        {
            bt_CrearNota.IsEnabled = bloquear;
            bt_EliminarNota.IsEnabled = bloquear;
            bt_ModificarNota.IsEnabled = bloquear;
        }

        private void BloquerarModificacionLibreta(bool bloquear)
        {
            bt_ModificarLibreta.IsEnabled = bloquear;
            bt_EliminarLibreta .IsEnabled = bloquear;
        }
        

        private void Salir(object sender, RoutedEventArgs e)
        {
            MainWindow main = new();
            main.Show();
            this.Close();
        }
    }
}
