using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Model;

namespace FinalPAV.ViewModel
{
    public class ConductoresViewModel : INotifyPropertyChanged, IConductoresViewModel
    {
        private Persona selectedPersona;

        private ObservableCollection<Persona> personas;
        public ObservableCollection<Persona> Personas
        {
            get
            {
                return personas;
            }
            set
            {
                personas = value;
                RaisePropertyChanged("Personas");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
