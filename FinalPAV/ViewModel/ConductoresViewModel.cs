using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DAL;
using FinalPAV.Extensions;
using FinalPAV.Messages;
using FinalPAV.Services;
using FinalPAV.Utility;
using Model;

namespace FinalPAV.ViewModel
{
    public class ConductoresViewModel : INotifyPropertyChanged, IConductoresViewModel
    {
        private Persona selectedPersona;
        private static PAVContext context = new PAVContext();

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

        private ObservableCollection<Viaje> viajes;
        public ObservableCollection<Viaje> Viajes
        {
            get
            {
                return viajes;
            }
            set
            {
                viajes = value;
                RaisePropertyChanged("Viajes");//TODO No se que hace esta linea bien
            }
        }

        public ICommand EditCommand { get; set; }
        public ICommand ViewViajesCommand { get; set; }
        public Persona SelectedPersona
        { 
            get 
            {
                return selectedPersona;
            }
            set
            {
                this.selectedPersona = value;
                RaisePropertyChanged("SelectedPersona");
            }
                
                }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LoadCommands()
        {
            EditCommand = new CustomCommand(EditPersona, CanEditPersona);
            ViewViajesCommand = new CustomCommand(PopulateViajes, CanPopulateViajes);
        }

        private bool CanPopulateViajes(object obj)
        {
            return (context.Viajes
                .Where(x => x.ConductorId == SelectedPersona.PersonaId).FirstOrDefault() != null);
           // return SelectedPersona != null ? true : false;
        }

        private void PopulateViajes(object obj)
        {
            Viajes = context.Viajes
                .Where(x => x.ConductorId == SelectedPersona.PersonaId)
                .ToObservableCollection();
        }

        private void EditPersona(object obj)
        {
            Messenger.Default.Send<Persona>(selectedPersona);
           //dialogService.ShowDetailDialog();
        }

        private bool CanEditPersona(object obj)
        {
            if (SelectedPersona != null)
                return true;
            return false;
        }

        private void LoadData()
        {
            context.Database.EnsureCreated();
            Personas = ListExtensions.ToObservableCollection(context.Personas.ToList());
            //Personas = personaDataService.GetAllPersonas().ToObservableCollection();
        }

        public ConductoresViewModel()
        {
           // this.dialogService = dialogService;

            LoadCommands();
            LoadData();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);

        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            //dialogService.CloseDetailDialog();
        }
       

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
