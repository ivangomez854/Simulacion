using Simulacion.Entidades.Interfaces;
using Simulacion.Entidades.Randoms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    internal class GeneradorVAExponencialNegativa : IGeneradorVA
    {

        private IGeneradorRandom generadorRnd;

        /// <summary>
        /// Esta clase trabaja con el parametro Lamda.
        /// En caso de contar con el parametro Media, inicializar con Lamda = 1/Media
        /// </summary>
        public double lamda { get; } // Limite Real inferior

        private VariableAleatoria estadoActual;


        public GeneradorVAExponencialNegativa(IGeneradorRandom generadorRnd, double lamda)
        {
            this.generadorRnd = generadorRnd;
            this.lamda = lamda;
            this.estadoActual = null;
        }

        public BindingList<VariableAleatoria> generarListaVA(double cantidad, [Optional] BindingList<VariableAleatoria> listaCompletar)
        {
            BindingList<VariableAleatoria> lista = listaCompletar is null ? new BindingList<VariableAleatoria>() : listaCompletar;

            // Inicio la generacion de variables aleatorias

            for (int i = 1; i <= cantidad; i++)
            {
                // Pido un random
                var rnd = this.generadorRnd.obtenerProximoRandom();
                //Calculo la proxima variable aleatoria
                VariableAleatoria va = new VariableAleatoria();
                va.Rnd1 = rnd.Item2;
                va.Orden = rnd.Item1;
                va.ValorAleatorio = (-1 / lamda) * Math.Log(1 - rnd.Item2);
                // Cargo la variable aleatoria en la lista
                lista.Add(va);
            }
            // Antes de retornar actualizo el estado actual
            this.estadoActual = lista.Last();
            return lista;
        }

        public VariableAleatoria ObtenerEstadoActual()
        {
            return this.estadoActual;
        }
    }
}
