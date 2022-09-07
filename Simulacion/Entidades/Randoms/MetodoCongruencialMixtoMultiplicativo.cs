using Simulacion.Entidades.Randoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    internal class MetodoCongruencialMixtoMultiplicativo : IGeneradorRandom
    {
        private double a;
        private double c;
        private double m;
        private double semilla;

        private List<FilaVectorEstadoRnd> vectorEstado;

        /// <summary>
        /// Este constructor inicializa el generador como Congruencial Mixto,
        /// inicializando la constante independiente c en cero.
        /// </summary>
        /// <param name="a">Constante multiplicativa</param>
        /// <param name="c">Constante independiente</param>
        /// <param name="m">Modulo</param>
        /// <param name="semilla">Valor semilla</param>
        public MetodoCongruencialMixtoMultiplicativo(double a, double c, double m, double semilla)
        {
            this.a = a;
            this.c = c;
            this.m = m;
            this.semilla = semilla;
            inicializarVectorEstado();
        }
        
        /// <summary>
        /// Este constructor inicializa el generador como Congruencial Multiplicativo,
        /// inicializando la constante independiente c en cero.
        /// </summary>
        /// <param name="a">Constante multiplicativa</param>
        /// <param name="m">Modulo</param>
        /// <param name="semilla">Valor semilla</param>
        public MetodoCongruencialMixtoMultiplicativo(double a, double m, double semilla)
        {
            this.a = a;
            this.c = 0;
            this.m = m;
            this.semilla = semilla;
            inicializarVectorEstado();
        }
        /// <summary>
        /// Metodo interno que inicializa el vector de estado antes de que se puedan utilizar los
        /// metodos de generacion de randoms
        /// </summary>
        private void inicializarVectorEstado()
        {
            vectorEstado = new List<FilaVectorEstadoRnd>();
            vectorEstado.Add(new FilaVectorEstadoRnd());
            vectorEstado.Add(new FilaVectorEstadoRnd());
            vectorEstado[0].xi = semilla;
            vectorEstado[0].rnd = 0;
            vectorEstado[0].orden = 0;
        }

        /// <summary>
        /// Metodo que permite generar una determinada cantidad de randoms desde el vector de estado actual
        /// conservando el estado del ultimo random generado en el vector de estado.
        /// De esta forma el vector de estado quedará en el estado cuyo orden sea ordenActual + cantidad. 
        /// </summary>
        /// <param name="cantidad">Cantidad de randoms a generar</param>
        public void generarRandoms(int cantidad)
        {
            for(int i = 0; i < cantidad; i++)
            {
                this.vectorEstado[1].xi = (a * this.vectorEstado[0].xi + c) % m;
                this.vectorEstado[1].rnd = this.vectorEstado[1].xi / m;
                this.vectorEstado[1].orden = this.vectorEstado[0].orden + 1;
                
                this.vectorEstado[0].xi = this.vectorEstado[1].xi;
                this.vectorEstado[0].rnd = this.vectorEstado[1].rnd;
                this.vectorEstado[0].orden = this.vectorEstado[1].orden;
            }
        }

        public Dictionary<double, double> generarListaRandoms(int cantidad)
        {
            var dictionary = new Dictionary<double, double>();

            for (int i = 0; i < cantidad; i++)
            {
                this.vectorEstado[1].xi = (a * this.vectorEstado[0].xi + c) % m;
                this.vectorEstado[1].rnd = this.vectorEstado[1].xi / m;
                this.vectorEstado[1].orden = this.vectorEstado[0].orden + 1;
                
                this.vectorEstado[0].xi = this.vectorEstado[1].xi;
                this.vectorEstado[0].rnd = this.vectorEstado[1].rnd;
                this.vectorEstado[0].orden = this.vectorEstado[1].orden;

                dictionary.Add(this.vectorEstado[0].orden, this.vectorEstado[0].rnd);
            }
            return dictionary;
        }

        public Tuple<double, double> obtenerProximoRandom()
        {
            generarRandoms(1);
            return new Tuple<double, double>(this.vectorEstado[0].orden, this.vectorEstado[0].rnd);
        }

        /// <summary>
        /// Metodo que permite obtener el estado actual del generador
        /// </summary>
        /// <returns>Fila de vector de estado actual</returns>
        public FilaVectorEstadoRnd getVectorEstado()
        {
            return this.vectorEstado[0];
        }
    }
}
