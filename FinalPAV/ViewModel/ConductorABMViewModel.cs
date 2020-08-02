using DAL;
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
    public class ConductorABMViewModel : IConductoreABM
    {
        public ICommand SaveCommand { get; set; }//TODO MODIFICAR 

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

        public ConductorABMViewModel() {

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
            return true;//modificar esto o refactorear clase CustomCommand
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
    }
}
