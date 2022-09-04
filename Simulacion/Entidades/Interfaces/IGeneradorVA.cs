using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades.Interfaces
{
    internal interface IGeneradorVA
    {
     LinkedList<VariableAleatoria> generarListaVA(int cantidad);
     VariableAleatoria ObtenerEstadoActual();
    }
}
