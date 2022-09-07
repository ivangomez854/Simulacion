using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulacion.Entidades.Interfaces;
using MathNet.Numerics.Distributions;
using MathNet.Numerics;

namespace Simulacion.Entidades
{
    class GeneradorIntervaloPoisson : GeneradorIntervalo
    {
        public double lambda { get; }

        public GeneradorIntervaloPoisson(BindingList<VariableAleatoria> variablesAleatorias, int cantidadIntervalos, double lambda) : base(variablesAleatorias, cantidadIntervalos)
        {
            this.lambda = lambda;
        }

        public override List<Intervalo> getIntervalos()
        {
            List<Intervalo> intervalos = new List<Intervalo>();

            List<IGrouping<double, VariableAleatoria>> variablesAleatoriasAgrupadas = variablesAleatorias.GroupBy(va => va.ValorAleatorio).ToList();

            List<IGrouping<double, VariableAleatoria>> variablesAleatoriasAgrupadasOrdenadas = variablesAleatoriasAgrupadas.AsParallel().OrderBy(grupo => grupo.Key).ToList();

            int orden = 1;
            foreach (var grupo in variablesAleatoriasAgrupadasOrdenadas)
            {
                double probabilidad = Math.Pow(this.lambda, grupo.Key) * Math.Pow(Math.E, -this.lambda) / SpecialFunctions.Factorial((int)grupo.Key);

                double frecuenciaObservada = grupo.Count();
                double frecuenciaEsperada = probabilidad * this.variablesAleatorias.Count();

                double chiCuadradoCalculado = Math.Round(Math.Pow(frecuenciaEsperada - frecuenciaObservada, 2) / frecuenciaEsperada, 4);

                Intervalo intervalo = new Intervalo();
                intervalo.frecuenciaObservada = frecuenciaObservada;
                intervalo.frecuenciaEsperada = frecuenciaEsperada;
                intervalo.chiCuadradoCalculado = chiCuadradoCalculado;
                intervalo.orden = orden;

                intervalos.Add(intervalo);
                orden++;
            }

            return intervalos;
        }
        protected override double getFrecuenciaEsperada(double limiteInferior, double limiteSuperior)
        {
            return 0d;
        }

    }
}
