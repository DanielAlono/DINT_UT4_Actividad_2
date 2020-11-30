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

namespace UT4_Actividad_2
{
    public partial class MainWindow : Window
    {
        List<Superheroe> superheroes;
        Superheroe superVariable;
        int numeroLista;
        public MainWindow()
        {
            InitializeComponent();
            numeroLista = 0; //Inicializamos el número de la lista
            superheroes = Superheroe.GetSamples(); //Inicializamos nuestra lista de superhéroes
            heroeRadioButton.IsChecked = true; //Inicializamos el radiobutton de heroe a true

            actualizarDatos();

        }
        void construirSuperheroe(Superheroe superheroe)
        {
            establecerFondo(superheroe);
            establecerIconos(superheroe);

        }
        private void actualizarDatos()
        {
            verSuperheroeGrid.DataContext = superheroes[numeroLista];
            avanzarTextBlock.Text = superheroes.Count.ToString();
            retrocederTextBlock.Text = (numeroLista + 1).ToString();
            construirSuperheroe(superheroes[numeroLista]);
        }
        private void establecerFondo(Superheroe superheroe)
        {
            if (superheroe.Heroe)
            {
                verSuperheroeGrid.Background = Brushes.PaleGreen;
            }
            else
            {
                verSuperheroeGrid.Background = Brushes.IndianRed;
            }
        }
        private void establecerIconos(Superheroe superheroe)
        {
            iconosStackPanel.Children.Clear();
            Image iconoAvengers = new Image()
            {
                Source = new BitmapImage(new Uri("avengers.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            Image iconoXmen = new Image()
            {
                Source = new BitmapImage(new Uri("xmen.png", UriKind.Relative)),
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(5)
            };

            if (superheroe.Vengador) iconosStackPanel.Children.Add(iconoAvengers);
            if (superheroe.Xmen) iconosStackPanel.Children.Add(iconoXmen);
        }

        private void retrocederButton_Click(object sender, RoutedEventArgs e)
        {
            if (numeroLista > 0)
            {
                numeroLista -= 1;
                actualizarDatos();
            }
        }

        private void avanzarButton_Click(object sender, RoutedEventArgs e)
        {
            if (numeroLista < superheroes.Count)
            {
                numeroLista += 1;
                actualizarDatos();
            }
        }

        private void villanoRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            tipoHeroeStackPanel.IsEnabled = false;
        }

        private void villanoRadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            tipoHeroeStackPanel.IsEnabled = true;
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            guardar();
            MessageBox.Show("Superhéroe insertado con éxito", "aceptar", MessageBoxButton.OK, MessageBoxImage.Information);
            limpiar();
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
        private void guardar()
        {
            superVariable = new Superheroe();
            superVariable.Nombre = nombreTextBox.Text;
            superVariable.Imagen = imagenTextBox.Text;
            if (heroeRadioButton.IsChecked == true)
            {
                superVariable.Heroe = true;
                superVariable.Villano = false;
                if (vengadoresCheckBox.IsChecked == true) superVariable.Vengador = true;
                else superVariable.Vengador = false;

                if (xmenCheckBox.IsChecked == true) superVariable.Xmen = true;
                else superVariable.Xmen = false;
            }
            else
            {
                superVariable.Heroe = false;
                superVariable.Villano = true;
                superVariable.Vengador = false;
                superVariable.Xmen = false;
            }

            superheroes.Add(superVariable);
            actualizarDatos();
        }
        private void limpiar()
        {
            nombreTextBox.Text = "";
            imagenTextBox.Text = "";
            heroeRadioButton.IsChecked = true;
            villanoRadioButton.IsChecked = false;
            vengadoresCheckBox.IsChecked = false;
            xmenCheckBox.IsChecked = false;
        }
    }
}
