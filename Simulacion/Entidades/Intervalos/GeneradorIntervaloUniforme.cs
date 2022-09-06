using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Entidades.Interfaces;

namespace Simulacion.Entidades
{
    class GeneradorIntervaloUniforme : GeneradorIntervalo
    {
        public GeneradorIntervaloUniforme(BindingList<VariableAleatoria> variablesAleatorias, int cantidadIntervalos) : base(variablesAleatorias, cantidadIntervalos)
        {
            
        }

        protected override double getFrecuenciaEsperada(double limiteInferior, double limiteSuperior)
        {
            return this.variablesAleatorias.Count / this.cantidadIntervalos;
        }
    }
}
