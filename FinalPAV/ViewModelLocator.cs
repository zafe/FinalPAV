using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using FinalPAV.Services;
using FinalPAV.ViewModel;

namespace FinalPAV
{
    public class ViewModelLocator
    {
        // private static IDialogService dialogService = new DialogService();
        private static IPersonaDataService personaDataService = new PersonaDataService(new PersonaRepository());

        private static ConductoresViewModel conductoresOverviewViewModel = new ConductoresViewModel(personaDataService);
        //private static CoffeeDetailViewModel coffeeDetailViewModel = new CoffeeDetailViewModel(personaDataService, dialogService);

        /*public static CoffeeDetailViewModel CoffeeDetailViewModel
        {
            get
            {
                return coffeeDetailViewModel;
            }
        }*/

        public static ConductoresViewModel ConductoresViewModel
        {
            get
            {
                return conductoresOverviewViewModel;
            }
        }
    }
}
