using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalPAV.Extensions
{
    public static class ViajeUtils
    {
        
        public static float CalcularMonto(ReglasNegocio reglas, float distancia){

            return 500.0f;//TODO Cambiar logica

        }

        public static Viaje LiquidarViaje(Viaje v)
        {
            v.EstadoLiquidacion = true;
            return v;
        }

        public static void CalcularMonto(Viaje v)
        {
            v.Monto = v.Peso * (v.Distancia.DistanciaKM * v.Reglas.PrecioKM + v.Reglas.Tarifa);
        }

        public static void LiquidarViaje(object sender, LiquidarViajesEventArgs e)
        {
            e.Viaje.EstadoLiquidacion = true;
            e.Viaje.Monto = 750;

            Console.WriteLine("******** LIQUIDAR VIAJE EJECUTADO ********");
            
        }

        public static List<Viaje> LiquidarViajes(List<Viaje> ViajesSinLiquidar)
        {
            List<Viaje> ViajesLiquidados = new List<Viaje>();

            foreach (Viaje v in ViajesSinLiquidar)
            { 
                
                v.EstadoLiquidacion = true;
                ViajesLiquidados.Add(v);
            }

            return ViajesLiquidados;
        }
    }
}
