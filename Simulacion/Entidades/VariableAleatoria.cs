using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    internal class VariableAleatoria
    {
        public double Rnd1 { get; set; }
        public double Rnd2 { get; set; } // Solo lo usamos en VANormal
        public double Orden { get; set; }
        public double ValorAleatorio { get; set; }
    }
}
