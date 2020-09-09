using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FinalPAV.ViewModel
{
    public interface ILoginViewModel
    {
        ICommand LoginCommand { get; set; }
        String Usuario { get; set; }
        String Clave { get; set; }
    }
}
