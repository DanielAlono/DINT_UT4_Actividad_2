using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            actualizarDatos(superheroes[0]);
        }
        private void actualizarDatos(Superheroe superheroe)
        {
            verSuperheroeGrid.DataContext = superheroe;//Asignamos el superheroe a la ventana
            avanzarTextBlock.Text = superheroes.Count.ToString();
            retrocederTextBlock.Text = (numeroLista + 1).ToString();
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            superVariable = (Superheroe)this.Resources["superVariable"];
            superheroes.Add(superVariable);
            this.Resources.Remove("superVariable");
            this.Resources.Add("superVariable", new Superheroe { Heroe = true });
            MessageBox.Show("Superhéroe insertado con éxito", "aceptar", MessageBoxButton.OK, MessageBoxImage.Information);
            actualizarDatos(superheroes[0]);
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }
        //Limpiaremos todos los cuadros y dejaremos todo como al inicio
        private void limpiar()
        {
            nombreTextBox.Text = "";
            imagenTextBox.Text = "";
            heroeRadioButton.IsChecked = true;
            villanoRadioButton.IsChecked = false;
            vengadoresCheckBox.IsChecked = false;
            xmenCheckBox.IsChecked = false;
        }

        private void avanzarrImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (numeroLista < superheroes.Count - 1)
            {
                numeroLista += 1;
                actualizarDatos(superheroes[numeroLista]);
            }
        }

        private void retrocederImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (numeroLista > 0)
            {
                numeroLista -= 1;
                actualizarDatos(superheroes[numeroLista]);
            }
        }
    }
}
