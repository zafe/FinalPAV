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
    interface IConductoresViewModel
    {

        ObservableCollection<Persona> Personas { get; set; }
        ICommand EditCommand { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
        Persona SelectedPersona { get; set; }
    }
}
