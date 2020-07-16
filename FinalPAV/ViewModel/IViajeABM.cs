using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalPAV.ViewModel
{
    public interface IViajeABM
    {
        ICommand SaveCommand { get; set; }
        Viaje Viaje { get; set; }
    }
}
