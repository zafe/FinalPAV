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
        MetroWindow conductorABMView = null;

        public void ShowDialog()
        {
            conductorABMView = new ABMConductor();
            conductorABMView.ShowDialog();
        }

        public void CloseDialog()
        {
            if (conductorABMView != null) conductorABMView.Close();
        }

    }
}
