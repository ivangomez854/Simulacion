using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades.Randoms
{
    internal interface IGeneradorRandom
    {
        void generarRandoms(int cantidad);
        Dictionary<double, double> generarListaRandoms(int cantidad);
        Tuple<double, double> obtenerProximoRandom();
        FilaVectorEstadoRnd getVectorEstado();
    }
}
