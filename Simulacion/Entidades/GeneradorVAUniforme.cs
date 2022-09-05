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
    internal class GeneradorVAUniforme : IGeneradorVA
    {
        private IGeneradorRandom generadorRnd;
        public double a { get; } // Limite Real inferior
        public double b { get; } // Limite Real superior

        private VariableAleatoria estadoActual;


        public GeneradorVAUniforme(IGeneradorRandom generadorRnd, double a, double b)
        {
            this.generadorRnd = generadorRnd;
            this.a = a;
            this.b = b;
            this.estadoActual = null;
        }

        public BindingList<VariableAleatoria> generarListaVA(double cantidad, [Optional] BindingList<VariableAleatoria> listaCompletar)
        {
            BindingList<VariableAleatoria> lista = listaCompletar is null ? new BindingList<VariableAleatoria>() : listaCompletar;

            // Inicio la generacion de variables aleatorias

            for (int i = 1; i <= cantidad; i ++)
            {
                // Pido un random
                var rnd = this.generadorRnd.obtenerProximoRandom();
                //Calculo la proxima variable aleatoria
                VariableAleatoria n1 = new VariableAleatoria();
                n1.Rnd1 = rnd.Item2;
                n1.Orden = rnd.Item1;
                n1.ValorAleatorio = this.a + rnd.Item2 * (this.b - this.a); 
                // Cargo las variables aleatorias en la lista
                lista.Add(n1);
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
