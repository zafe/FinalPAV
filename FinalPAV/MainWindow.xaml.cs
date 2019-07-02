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
using Modelo;

namespace FinalPAV
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonSalir_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            UsuarioService usuarioService = new UsuarioService();
            AdministradorService administradorService = new AdministradorService();
            UsuarioSet usuario = usuarioService.getEntity(int.Parse(textBoxUsuario.Text));

            if (usuario.Id == int.Parse(textBoxUsuario.Text) && usuario.Clave == passwordBox.Password)
            {
                AdministradorSet administrador = administradorService.getEntity(usuario.Administrador_Id);
                MessageBox.Show("Sesion iniciada");
                labelError.Content = "Bienvenido " + administrador.Nombre + " " + administrador.Apellido;
                labelError.Visibility = Visibility.Visible;
            }
            else
            {
                labelError.Content = "El usuario y/o contraseña son incorrectos";
                labelError.Visibility = Visibility.Visible;
            }
        }
    }
}
