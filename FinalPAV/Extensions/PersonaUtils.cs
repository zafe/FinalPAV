using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace FinalPAV.Extensions
{
    public static class PersonaUtils
    {
        public static bool VerificarCUIT(string Cuit)
        {
            var cuit = Cuit;
            var pattern = new Regex("(20|23|24|27|30|33|34)-[0-9]{8}-[0-9]");

            return pattern.IsMatch(cuit);
          
        }
    }
}
