using DAL;
using FinalPAV.Services;
using FinalPAV.Utility;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FinalPAV.ViewModel
{
    class LoginViewModel : ILoginViewModel, INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; set; }

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; RaisePropertyChange("Usuario"); }
        }

        private string clave;
        public string Clave 
        { 
            get { return clave; }
            set { clave = value; RaisePropertyChange("Clave"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChange(string PropertyName)
        {
            if(PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

        LoginViewModel()
        {
            LoadCommands();
        }

        private void LoadCommands()
        {
            LoginCommand = new CustomCommand(o => 
            {
                PAVContext context = new PAVContext();
                var usuario = context.Usuarios.Where(u => u.NombreUsuario == Usuario && u.Clave == Clave)
                                                     .Include(u => u.Persona)
                                                     .FirstOrDefault();

                if (usuario != null)
                    MessageBox.Show($"Bienvenido {usuario.Persona.Nombre} {usuario.Persona.Apellido}");
                else
                    MessageBox.Show("Credenciales incorrectas");


            }, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object o)
        {
            return ( Usuario.Length > 0 && Clave.Length > 0 );
        }

       
    }
}
