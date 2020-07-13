using FinalPAV.Messages;
using FinalPAV.Utility;
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
        public ICommand SaveCommand 
        {
            get; 
            set;  
        }//TODO MODIFICAR 

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
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }
    }
}
