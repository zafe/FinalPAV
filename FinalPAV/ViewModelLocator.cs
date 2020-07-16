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

        private static ConductoresViewModel conductoresViewModel = new ConductoresViewModel();
        private static ViajeABMViewModel viajesViewModel = new ViajeABMViewModel();
        private static ConductorABMViewModel conductorABMViewModel = new ConductorABMViewModel();

        public static ViajeABMViewModel ViajesViewModel
        {
            get
            {
                return viajesViewModel;
            }
        }

        public static ConductoresViewModel ConductoresViewModel
        {
            get
            {
                return conductoresViewModel;
            }
        }

        public static ConductorABMViewModel ConductorABMViewModel
        {

            get
            {
                return conductorABMViewModel;
            }

        }
    }
}
