using DAL;
using FinalPAV.Utility;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalPAV.ViewModel
{
    public class ViajeABMViewModel : IViajeABM
    {
        public ICommand SaveCommand { get ; set; }
        DbContext context = new PAVContext();

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Ingenio> ingenios;
        public ObservableCollection<Ingenio> Ingenios
        {
            get
            {
                return ingenios;
            }
            set
            {
                ingenios = value;
                RaisePropertyChanged("Ingenios");
            }
        }

        private ObservableCollection<Finca> fincas;
        public ObservableCollection<Finca> Fincas
        {
            get
            {
                return fincas;
            }
            set
            {
                fincas = value;
                RaisePropertyChanged("Fincas");
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private Viaje viaje;
        public Viaje Viaje {
            get { return viaje; }
            set { viaje = value; } 
        }

        public ViajeABMViewModel()
        {
            Messenger.Default.Register<Viaje>(this, OnViajeReceived);
        }

        private void OnViajeReceived(Viaje viajeReceived)
        {
            Viaje = viajeReceived;
        }
    }
}
