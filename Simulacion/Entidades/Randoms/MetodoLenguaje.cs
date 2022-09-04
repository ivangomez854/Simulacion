using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades.Randoms
{
    internal class MetodoLenguaje : IGeneradorRandom
    {
        private Random generador;
        private FilaVectorEstadoRnd vectorEstado;

        public MetodoLenguaje()
        {
            this.generador = new Random();
            inicializarVectorEstado();
        }
        public Dictionary<double, double> generarListaRandoms(int cantidad)
        {
            var dictionary = new Dictionary<double, double>();

            for (int i = 0; i < cantidad; i++)
            {
                this.vectorEstado.rnd = generador.NextDouble();
                this.vectorEstado.orden++;

                dictionary.Add(this.vectorEstado.orden, this.vectorEstado.rnd);
            }
            return dictionary;
        }
        private void inicializarVectorEstado()
        {
            vectorEstado = new FilaVectorEstadoRnd();
            vectorEstado.orden = 0;
        }
        public void generarRandoms(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                this.vectorEstado.rnd = generador.NextDouble();
                this.vectorEstado.orden++;
            }
        }

        public FilaVectorEstadoRnd getVectorEstado()
        {
            return this.vectorEstado;
        }

        public Tuple<double, double> obtenerProximoRandom()
        {
            generarRandoms(1);
            return new Tuple<double, double>(this.vectorEstado.orden, this.vectorEstado.rnd);
        }
    }
}
