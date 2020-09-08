using DAL;
using FinalPAV.Extensions;
using FinalPAV.Messages;
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
    public class ViajeABMViewModel : INotifyPropertyChanged, IViajeABM
    {
        public ICommand SaveCommand { get ; set; }

        private static PAVContext context = new PAVContext();

        public event PropertyChangedEventHandler PropertyChanged;

        private Ingenio selectedIngenio;
        public Ingenio SelectedIngenio
        {
            get
            {
                return selectedIngenio;
            }
            set
            {
                this.selectedIngenio = value;
                RaisePropertyChanged("SelectedIngenio");
            }
        }

        private Finca selectedFinca;
        public Finca SelectedFinca
        {
            get
            {
                return selectedFinca;
            }
            set
            {
                this.selectedFinca = value;
                RaisePropertyChanged("SelectedFinca");
            }
        }

        private ObservableCollection<Ingenio> ingenios;

        public ICommand UpdateDistanciaCommand { get; set; }
        public ICommand SaveViajeCommand { get; set; }
        public ObservableCollection<Ingenio> Ingenios
        {
            get
            {
                return ingenios;
            }
            set
            {
                this.ingenios = value;
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
                this.fincas = value;
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
            get 
            { 
                return viaje; 
            }
            set 
            {
                this.viaje = value;
                RaisePropertyChanged("Viaje");
            }
        }

        public ViajeABMViewModel()
        {
            UpdateDistanciaCommand = new CustomCommand(UpdateDistancia, CanUpdateDistancia);
            SaveViajeCommand = new CustomCommand(SaveViaje, CanSaveViaje);
            Messenger.Default.Register<Viaje>(this, OnViajeReceived);
            LoadData();
        }

        private bool CanSaveViaje(object obj)
        {
            return true;//TODO Realizar logica para guardar el viaje
        }

        private void SaveViaje(object obj)
        {
            if (Viaje.ViajeId == 0) context.Update(Viaje);

            Console.WriteLine("ViajeID: " + Viaje.ViajeId);
            //context.Database.OpenConnection();
            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Personas ON");
            context.SaveChanges();
            //context.Database.CloseConnection();
            Messenger.Default.Send<UpdateListMessage>(new UpdateListMessage());
        }

        private bool CanUpdateDistancia(object obj)
        {
            return (SelectedIngenio != null) && (SelectedFinca != null);
        }

        private void UpdateDistancia(object obj)
        {

          Viaje.Distancia = ListExtensions.ToObservableCollection(context.Distancia
                .Where(x => x.IngenioId == SelectedIngenio.IngenioId && x.FincaId == SelectedFinca.FincaId)).FirstOrDefault();

          ViajeUtils.CalcularMonto(Viaje);
          RaisePropertyChanged("Viaje");
          Console.WriteLine("Distancia: " + Viaje.Distancia.DistanciaKM);
        }

        private void OnViajeReceived(Viaje viajeReceived)
        {
            Viaje = viajeReceived;
            //Distancia = viajeReceived.Distancia.DistanciaKM;
            RaisePropertyChanged("Viaje");
        }

        private void LoadData()
        {
            Fincas = ListExtensions.ToObservableCollection(context.Finca.ToList());
           // SelectedFinca = Fincas.FirstOrDefault(x => x.FincaId == Viaje.Distancia.FincaId);
            Ingenios = ListExtensions.ToObservableCollection(context.Ingenio.ToList());
        }
    }
}
