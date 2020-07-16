using FinalPAV.View;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FinalPAV.Services
{
    public class DialogService
    {
        MetroWindow windowDialog = null;

        public void ShowDialog(string window)
        {
            switch(window)
            {
                case "Personas":
                    windowDialog = new ABMConductor();
                    break;
                case "Viajes":
                    windowDialog = new ViajeABM();
                    break;
            }

            windowDialog.ShowDialog();
                
            
        }

        public void CloseDialog()
        {
            if (windowDialog != null) windowDialog.Close();
        }

    }
}
