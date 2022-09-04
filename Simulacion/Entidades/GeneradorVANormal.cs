using Simulacion.Entidades.Randoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    internal class GeneradorVANormal
    {
        private IGeneradorRandom generadorRnd;
        public double media { get; }
        public double desviacion { get; }

        private VariableAleatoriaNormal vaSinUsar; //Me avisa que tengo una variable aleatoria sin usar
        private VariableAleatoriaNormal estadoActual;


        public GeneradorVANormal(IGeneradorRandom generadorRnd, double media, double desviacion)
        {
            this.generadorRnd = generadorRnd;
            this.media = media;
            this.desviacion = desviacion;
            this.estadoActual = null;
            this.vaSinUsar = null;
        }

        public LinkedList<VariableAleatoriaNormal> generarListaRndNormal(int cantidad)
        {
            LinkedList<VariableAleatoriaNormal> lista = new LinkedList<VariableAleatoriaNormal>();
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
                VariableAleatoriaNormal n1 = new VariableAleatoriaNormal();
                VariableAleatoriaNormal n2 = new VariableAleatoriaNormal();
                n1.rnd1 = rnd1.Item2;
                n1.rnd2 = rnd2.Item2;
                n1.orden = rnd1.Item1;
                n1.vaNormal = Math.Sqrt(-2 * Math.Log(rnd1.Item2)) * Math.Cos(2 * Math.PI * rnd2.Item2) * this.desviacion + this.media;
                n2.rnd1 = rnd1.Item2;
                n2.rnd2 = rnd2.Item2;
                n2.orden = rnd2.Item1;
                n2.vaNormal = Math.Sqrt(-2 * Math.Log(rnd1.Item2)) * Math.Sin(2 * Math.PI * rnd2.Item2) * this.desviacion + this.media;
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

        public VariableAleatoriaNormal ObtenerEstadoActual()
        {
            return this.estadoActual;
        }
    }
}
