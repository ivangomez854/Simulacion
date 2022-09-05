using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Entidades.Interfaces;
using MathNet.Numerics.Distributions;

namespace Simulacion.Entidades
{
    class GeneradorIntervaloExponencial : GeneradorIntervalo
    {
        public double lambda { get; }

        public GeneradorIntervaloExponencial(BindingList<VariableAleatoria> variablesAleatorias, int cantidadIntervalos, double lambda) : base(variablesAleatorias, cantidadIntervalos)
        {
            this.lambda = lambda;
        }
        protected override double getFrecuenciaEsperada(double limiteInferior, double limiteSuperior)
        {
            return (this.getProbabilidadAcumulada(limiteSuperior) - this.getProbabilidadAcumulada(limiteInferior)) * this.variablesAleatorias.Count;
        }

        private double getProbabilidadAcumulada(double valorAleatorio)
        {
            return Exponential.CDF(this.lambda, valorAleatorio);
        }

    }
}
