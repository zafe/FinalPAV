using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using DAL;
using FinalPAV.Extensions;
using FinalPAV.Messages;
using FinalPAV.Services;
using FinalPAV.Utility;
using Microsoft.EntityFrameworkCore;
using Model;

namespace FinalPAV.ViewModel
{
    public class ConductoresViewModel : INotifyPropertyChanged, IConductoresViewModel
    {
        private Persona selectedPersona;
        private Viaje selectedViaje;
        private static PAVContext context = new PAVContext();
        private DialogService dialogService;

        private event EventHandler<LiquidarViajesEventArgs> LiquidarViajesOrden;

        protected virtual void OnLiquidarViajes()
        {
            LiquidarViajesOrden = ViajeUtils.LiquidarViaje;

            if(LiquidarViajesOrden != null)
            {
                //LiquidarViajesOrden = (o, e) => e.Viaje.EstadoLiquidacion = true;
                EventHandler<LiquidarViajesEventArgs> del = LiquidarViajesOrden as EventHandler<LiquidarViajesEventArgs>;
                foreach (Viaje v in Viajes)
                {
                    //LiquidarViajesOrden(this, new LiquidarViajesEventArgs(v));
                    del(this, new LiquidarViajesEventArgs(v));
                    v.Monto = 399;
                    context.Update(v);
                }

                RaisePropertyChanged("Viajes");
                context.SaveChanges();
            }
        } 

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
        public ICommand AddCommand { get; set; }
        public ICommand AddViajesCommand { get; set; }
        public ICommand ViewViajesCommand { get; set; }
        public ICommand EditViajeCommand { get; set; }
        public ICommand LiquidarViajesCommand { get; set; }


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

        public Viaje SelectedViaje
        {
            get
            {
                return selectedViaje;
            }

            set
            {
                this.selectedViaje = value;
                RaisePropertyChanged("SelectedViaje");
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
            AddCommand = new CustomCommand(AddPersona, CanAddPersona);
            ViewViajesCommand = new CustomCommand(PopulateViajes, CanPopulateViajes);
            AddViajesCommand = new CustomCommand(AddViaje, CanAddViaje);
            EditViajeCommand = new CustomCommand(EditViaje, CanEditViaje);
            LiquidarViajesCommand = new CustomCommand(LiquidarViajes, CanLiquidarViajes);
        }

        private bool CanLiquidarViajes(object obj)
        {
            

            return true;
        }

        private void LiquidarViajes(object obj)
        {
            OnLiquidarViajes();
        }

        private bool CanAddViaje(object obj)
        {
            return true;
        }

        private void AddViaje(object obj)
        {
            SelectedViaje = new Viaje {

            Conductor = SelectedPersona,
            Reglas = context.ReglasNegocio.OrderByDescending(x=>x.FechaActualizacion.Date).FirstOrDefault(),
            FechaHora = System.DateTime.Now,
            EstadoLiquidacion = false

        };

           Messenger.Default.Send<Viaje>(SelectedViaje);
           dialogService.ShowDialog("Viajes");
        }

        private bool CanEditViaje(object obj)
        {
            return SelectedViaje != null;
        }

        private void EditViaje(object obj)
        {
            //SelectedViaje.Distancia = context.Distancia.Where(x => x.DistanciaId == SelectedViaje.DistanciaId).FirstOrDefault();
            Messenger.Default.Send<Viaje>(SelectedViaje);
            dialogService.ShowDialog("Viajes");
        }

        private bool CanAddPersona(object obj)
        {
            return true; //TODO Agregar logica para que solo el superusuario pueda agregar persona
        }

        private void AddPersona(object obj)
        {

            selectedPersona = new Persona {

                FechaNacimiento = System.DateTime.Parse("1/12/1990"),
                FechaIngreso = System.DateTime.Now,
                CUIT = ""
                
            };

            Messenger.Default.Send<Persona>(selectedPersona);
            dialogService.ShowDialog("Personas");
        }

        private bool CanPopulateViajes(object obj)
        {

            Viajes = null;
                return (context.Viajes
                    .Where(x => x.ConductorId == SelectedPersona.PersonaId).FirstOrDefault() != null);
           // return SelectedPersona != null ? true : false;
        }

        private void PopulateViajes(object obj)
        {
            UpdateViajesList();
        }

        private void UpdateViajesList() 
        {
            Viajes = context.Viajes
                   .Where(x => x.ConductorId == SelectedPersona.PersonaId)
                   .Include(x => x.Distancia.Ingenio)
                   .Include(x => x.Distancia.Finca)
                   .Include(x => x.Reglas)
                   .ToObservableCollection();
        }

        private void EditPersona(object obj)
        {
            Messenger.Default.Send<Persona>(selectedPersona);
            Messenger.Default.Send<PAVContext>(context);
            dialogService.ShowDialog("Personas");
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
            Console.WriteLine("lISTA PERSONA ACTUALIZADAS");
            Personas = context.Personas.ToList().ToObservableCollection();
           // Personas = ListExtensions.ToObservableCollection(context.Personas.ToList());
            //Personas = personaDataService.GetAllPersonas().ToObservableCollection();
        }

        public ConductoresViewModel()
        {
            // this.dialogService = dialogService;

            dialogService = new DialogService();
            LoadCommands();
            LoadData();

            Messenger.Default.Register<UpdateListMessage>(this, OnUpdateListMessageReceived);

        }

        private void OnUpdateListMessageReceived(UpdateListMessage obj)
        {
            LoadData();
            UpdateViajesList();
            dialogService.CloseDialog();
        }
       

        public event PropertyChangedEventHandler PropertyChanged;
    }
}