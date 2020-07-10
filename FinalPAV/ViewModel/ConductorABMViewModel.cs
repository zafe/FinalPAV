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
    class ConductorABMViewModel : IConductoreABM
    {
        public ICommand SaveCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Persona SelectedPersona { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            throw new NotImplementedException();
        }

        private void SaveConductor(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
