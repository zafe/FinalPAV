using DAL;
using FinalPAV.Extensions;
using FinalPAV.Messages;
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
    public class ConductorABMViewModel : INotifyPropertyChanged, IConductorABM
    {
        public ICommand SaveCommand { get; set; }//TODO MODIFICAR 
        public ICommand CancelCommand { get; set; }
        private String errorMessage = "";
        public String ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                this.errorMessage = value;
                RaisePropertyChanged("ErrorMessage");
            }
        }
        private PAVContext context = new PAVContext();
        private Persona selectedPersona = new Persona();
        public Persona SelectedPersona
        {
            get
            {
                return selectedPersona;
            }
            set
            {
                this.selectedPersona = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ConductorABMViewModel()
        {

            SaveCommand = new CustomCommand(SaveConductor, CanSaveConductor);
            CancelCommand = new CustomCommand(Cancel, CanCancel);

            Messenger.Default.Register<Persona>(this, OnPersonaReceived);

            //Messenger.Default.Register<PAVContext>(this, onContextReceived);

        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        private void Cancel(object obj)
        {
            //SelectedPersona = context.Personas.Where(p => p.PersonaId == SelectedPersona.PersonaId).FirstOrDefault();
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private void OnPersonaReceived(Persona personaReceived)
        {
            SelectedPersona = personaReceived;
           /* SelectedPersona.PersonaId = personaReceived.PersonaId;
            SelectedPersona.Nombre = personaReceived.Nombre;
            SelectedPersona.Apellido = personaReceived.Apellido;
            SelectedPersona.CUIT = personaReceived.CUIT;
            SelectedPersona.FechaIngreso = personaReceived.FechaIngreso;
            SelectedPersona.FechaNacimiento = personaReceived.FechaNacimiento;
            SelectedPersona.FechaBaja = personaReceived.FechaBaja;*/
        }

        private bool CanSaveConductor(object obj)
        {
            return true;
           /* bool flag = true;

            if (SelectedPersona?.Nombre.Length == 0
                || SelectedPersona?.Apellido.Length == 0
                || SelectedPersona?.CUIT.Length == 0) flag = false;

            return flag;
            */
        }

        private bool CheckFillErrors()
        {
          ErrorMessage = "";
          if (!PersonaUtils.VerificarCUIT(SelectedPersona.CUIT))
                ErrorMessage += "Ingresar CUIT correctamente usando '-'";

           
            Console.WriteLine(ErrorMessage + ErrorMessage.Length);

            return ErrorMessage.Length == 0;
        }

        private void SaveConductor(object obj)
        { 

            if (selectedPersona.PersonaId == 0)
                context.Add(selectedPersona);
            else
                context.Update(selectedPersona);

            context.SaveChanges();
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
            
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }


    }
}
