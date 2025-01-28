using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace BlocDeNotas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Función para crear un nuevo archivo (limpiar el contenido)
        private void LimpiarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear(); // Limpia el contenido del TextBox
        }

        // Función para abrir un archivo de texto
        private void AbrirMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    string contenido = File.ReadAllText(openFileDialog.FileName);
                    textBox.Text = contenido; // Carga el contenido del archivo en el TextBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al abrir el archivo: " + ex.Message);
                }
            }
        }

        // Función para guardar un archivo de texto
        private void GuardarMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, textBox.Text); // Guarda el contenido del TextBox en el archivo
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }
    }
}