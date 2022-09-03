using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulacion.Entidades
{
    internal class MetodoCongruencialMixto
    {
        private double a;
        private double c;
        private double m;
        private double semilla;

        private List<FilaVectorEstado> vectorEstado;
        public MetodoCongruencialMixto(double a, double c, double m, double semilla)
        {
            this.a = a;
            this.c = c;
            this.m = m;
            this.semilla = semilla;
            inicializarVectorEstado();
        }

        private void inicializarVectorEstado()
        {
            vectorEstado = new List<FilaVectorEstado>();
            vectorEstado.Add(new FilaVectorEstado());
            vectorEstado.Add(new FilaVectorEstado());
            vectorEstado[0].xi = semilla;
            vectorEstado[0].rnd = 0;
            vectorEstado[0].orden = 0;
        }

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

        public FilaVectorEstado getVectorEstado()
        {
            return this.vectorEstado[0];
        }
    }
}
