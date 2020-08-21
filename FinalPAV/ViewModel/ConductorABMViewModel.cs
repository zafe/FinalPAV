using DAL;
using FinalPAV.Extensions;
using FinalPAV.Messages;
using FinalPAV.Utility;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalPAV.ViewModel
{
    public class ConductorABMViewModel : INotifyPropertyChanged, IConductoreABM
    {
        public ICommand SaveCommand { get; set; }//TODO MODIFICAR 
        private String errorMessage;
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
        private Persona selectedPersona;
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

            Messenger.Default.Register<Persona>(this, OnPersonaReceived);

            //Messenger.Default.Register<PAVContext>(this, onContextReceived);

        }
        private void OnPersonaReceived(Persona personaReceived)
        {
            SelectedPersona = personaReceived;
        }

        private bool CanSaveConductor(object obj)
        {
            //devolver true cuando todos los campos esten llenos
            return true;
        }

        private void ShowErrorMessage()
        {
            ErrorMessage = "";
            if (!PersonaUtils.VerificarCUIT(SelectedPersona.CUIT))
                ErrorMessage += "Ingresar CUIT correctamente usando '-'";

            Console.WriteLine(ErrorMessage);
        }

        private void SaveConductor(object obj)
        {
            ShowErrorMessage();
            if (selectedPersona.PersonaId == 0)
                context.Add(selectedPersona);
            else
                context.Update(selectedPersona);

            context.SaveChanges();
            //  Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }


    }
}
