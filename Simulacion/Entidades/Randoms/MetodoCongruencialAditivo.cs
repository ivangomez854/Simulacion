using Simulacion.Entidades.Randoms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    internal class MetodoCongruencialAditivo : IGeneradorRandom
    {
        private double a;
        private double c;
        private double m;
        private double semilla;

        private List<FilaVectorEstadoRnd> vectorEstado;
        public MetodoCongruencialAditivo(double a, double c, double m, double semilla)
        {
            this.a = a;
            this.c = c;
            this.m = m;
            this.semilla = semilla;
            inicializarVectorEstado();
        }

        private void inicializarVectorEstado()
        {
            vectorEstado = new List<FilaVectorEstadoRnd>();
            vectorEstado.Add(new FilaVectorEstadoRnd());
            vectorEstado.Add(new FilaVectorEstadoRnd());
            vectorEstado[0].xi = semilla;
            vectorEstado[0].xiMenosUno = 0;
            vectorEstado[0].rnd = 0;
            vectorEstado[0].orden = 0;
        }

        public void generarRandoms(int cantidad)
        {
            for (int i = 0; i < cantidad; i++)
            {
                this.vectorEstado[1].xi = (this.vectorEstado[0].xi + this.vectorEstado[0].xiMenosUno) % m;
                this.vectorEstado[1].rnd = this.vectorEstado[1].xi / m;
                this.vectorEstado[1].orden = this.vectorEstado[0].orden + 1;

                this.vectorEstado[0].xiMenosUno = this.vectorEstado[0].xi;
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
                this.vectorEstado[1].xi = (this.vectorEstado[0].xi + this.vectorEstado[0].xiMenosUno) % m;
                this.vectorEstado[1].rnd = this.vectorEstado[1].xi / m;
                this.vectorEstado[1].orden = this.vectorEstado[0].orden + 1;

                this.vectorEstado[0].xiMenosUno = this.vectorEstado[0].xi;
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

        public FilaVectorEstadoRnd getVectorEstado()
        {
            return this.vectorEstado[0];
        }
    }
}

