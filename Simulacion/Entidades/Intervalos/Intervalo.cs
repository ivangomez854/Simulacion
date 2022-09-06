using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    class Intervalo
    {
        public double frecuenciaObservada { get; set; }
        public double frecuenciaEsperada { get; set; }
        public int orden { get; set; }
        public double chiCuadradoCalculado { get; set; }
    }
}
