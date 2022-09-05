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
    class GeneradorIntervaloNormal : GeneradorIntervalo
    {
        public double media { get; }
        public double desviacionEstandar { get; }

        public GeneradorIntervaloNormal(BindingList<VariableAleatoria> variablesAleatorias, int cantidadIntervalos, double media, double desviacionEstandar) : base(variablesAleatorias, cantidadIntervalos)
        {
            this.media = media;
            this.desviacionEstandar = desviacionEstandar;
        }
        protected override double getFrecuenciaEsperada(double limiteInferior, double limiteSuperior)
        {
            return (this.getProbabilidadAcumulada(limiteSuperior) - this.getProbabilidadAcumulada(limiteInferior)) * this.variablesAleatorias.Count;
        }

        private double getProbabilidadAcumulada(double valorAleatorio)
        {
            return Normal.CDF(this.media, this.desviacionEstandar, valorAleatorio);
        }

    }
}
