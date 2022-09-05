using Simulacion.Entidades.Randoms;
using Simulacion.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Simulacion.Entidades
{
    internal class GeneradorVANormal : IGeneradorVA
    {
        private IGeneradorRandom generadorRnd;
        public double media { get; }
        public double desviacion { get; }

        private VariableAleatoria vaSinUsar; //Me avisa que tengo una variable aleatoria sin usar
        private VariableAleatoria estadoActual;


        public GeneradorVANormal(IGeneradorRandom generadorRnd, double media, double desviacion)
        {
            this.generadorRnd = generadorRnd;
            this.media = media;
            this.desviacion = desviacion;
            this.estadoActual = null;
            this.vaSinUsar = null;
        }

        public LinkedList<VariableAleatoria> generarListaVA(double cantidad, [Optional] LinkedList<VariableAleatoria> listaCompletar)
        {
            LinkedList<VariableAleatoria> lista = listaCompletar is null ? new LinkedList<VariableAleatoria>() : listaCompletar;
            var laUltimaNoVa = false;
            var cantidadGenerar = cantidad;

            //Chequeo si hay random pendiente de usar
            if (this.vaSinUsar != null && (cantidad - 1) == 0 ) {
                lista.AddLast(this.vaSinUsar);
                this.estadoActual = this.vaSinUsar; // Actualizo el estado actual
                this.vaSinUsar = null;
                return lista;
            } else if (this.vaSinUsar != null && (cantidad - 1) > 0)
            {
                lista.AddLast(this.vaSinUsar);
                this.vaSinUsar = null;
                cantidadGenerar--;
                // Aca no actualizo el estado actual porque con la validacion ya se que falta generar mas variables
            }

            // Si paso el chequeo me fijo que la cantidad a generar sea par
            if (cantidadGenerar % 2 != 0) {
                cantidadGenerar = cantidadGenerar + 1;
                laUltimaNoVa = true;
            }
            // Inicio la generacion de variables aleatorias
            for (int i = 1; i <= cantidadGenerar; i+=2)
            {
                // Pido dos randoms
                var rnd1 = this.generadorRnd.obtenerProximoRandom();
                var rnd2 = this.generadorRnd.obtenerProximoRandom();
                //Calculo las proximas dos variables aleatorias
                VariableAleatoria n1 = new VariableAleatoria();
                VariableAleatoria n2 = new VariableAleatoria();
                n1.Rnd1 = rnd1.Item2;
                n1.Rnd2 = rnd2.Item2;
                n1.Orden = rnd1.Item1;
                n1.ValorAleatorio = Math.Sqrt(-2 * Math.Log(rnd1.Item2)) * Math.Cos(2 * Math.PI * rnd2.Item2) * this.desviacion + this.media;
                n2.Rnd1 = rnd1.Item2;
                n2.Rnd2 = rnd2.Item2;
                n2.Orden = rnd2.Item1;
                n2.ValorAleatorio = Math.Sqrt(-2 * Math.Log(rnd1.Item2)) * Math.Sin(2 * Math.PI * rnd2.Item2) * this.desviacion + this.media;
                // Cargo las variables aleatorias en la lista
                lista.AddLast(n1);
                lista.AddLast(n2);
            }
            // Si la ultima no va la saco
            if(laUltimaNoVa)
            {
                vaSinUsar = lista.Last();
                lista.RemoveLast();
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
