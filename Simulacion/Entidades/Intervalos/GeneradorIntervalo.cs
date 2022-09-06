using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades.Interfaces
{
    abstract class GeneradorIntervalo
    {

        public BindingList<VariableAleatoria> variablesAleatorias { get; }
        public int cantidadIntervalos { get; }

        protected GeneradorIntervalo(BindingList<VariableAleatoria> variablesAleatorias, int cantidadIntervalos)
        {
            this.variablesAleatorias = variablesAleatorias;
            this.cantidadIntervalos = cantidadIntervalos;
        }
        public virtual List<Intervalo> getIntervalos()
        {
            List<Intervalo> intervalos = new List<Intervalo>();

            List<double> variablesAleatoriasOrdenadas = variablesAleatorias.Select(va => va.ValorAleatorio).OrderBy(va => va).ToList();

            double minimo = variablesAleatoriasOrdenadas.First();
            double maximo = variablesAleatoriasOrdenadas.Last();
            double rango = maximo - minimo;
            double amplitud = Math.Round(rango / cantidadIntervalos, 4);

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                int orden = i + 1;

                double limiteInferior = minimo + (amplitud * i);
                double limiteSuperior = limiteInferior + amplitud;

                double frecuenciaEsperada = this.getFrecuenciaEsperada(limiteInferior, limiteSuperior);

                int frecuenciaObservada;

                if (i == cantidadIntervalos - 1)
                {
                    frecuenciaObservada = variablesAleatoriasOrdenadas.Count();
                }
                else
                {
                    frecuenciaObservada = variablesAleatoriasOrdenadas.FindIndex(r => r >= limiteSuperior) - 1;
                }

                if (frecuenciaObservada < 0)
                {
                    frecuenciaObservada = 0;
                }

                variablesAleatoriasOrdenadas.RemoveRange(0, frecuenciaObservada);

                double chiCuadradoCalculado = Math.Round(Math.Pow(frecuenciaEsperada - frecuenciaObservada, 2) / frecuenciaEsperada, 4);

                Intervalo intervalo = new Intervalo();
                intervalo.frecuenciaObservada = frecuenciaObservada;
                intervalo.frecuenciaEsperada = frecuenciaEsperada;
                intervalo.chiCuadradoCalculado = chiCuadradoCalculado;
                intervalo.orden = orden;

                intervalos.Add(intervalo);
            }

            return intervalos;
        }

        protected abstract double getFrecuenciaEsperada(double limiteInferior, double limiteSuperior);
    }
}
