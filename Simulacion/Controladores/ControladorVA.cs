using Simulacion.Entidades;
using Simulacion.Entidades.Interfaces;
using Simulacion.Entidades.Randoms;
using Simulacion.InterfacesUsuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.Controladores
{
    internal class ControladorVA
    {
        private IGeneradorVA generadorVA;

        public ControladorVA(IGeneradorVA generadorVA)
        {
            this.generadorVA = generadorVA;
        }

        /// <summary>
        /// Metodo que retorna un listado de variables aleatorias.
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="progressBar"></param>
        /// <returns></returns>
        public BindingList<VariableAleatoria> generarListadoVA(double cantidad, ToolStripProgressBar progressBar)
        {
            BindingList<VariableAleatoria> lista = new BindingList<VariableAleatoria>();


            int cantidadSegmentosBusqueda = this.CalcularSegmentosBusqueda(cantidad);
            double cantidadPendienteBuscar = cantidad;
            double amplitudSegmentoBusqueda = Math.Truncate(cantidad / cantidadSegmentosBusqueda);

            // Configuro la progressBar
            progressBar.Value = 0;
            progressBar.Step = (int)amplitudSegmentoBusqueda;
            progressBar.Maximum = (int)cantidad;

            for (var i = 1; i <= cantidadSegmentosBusqueda; i++)
            {
                this.generadorVA.generarListaVA(amplitudSegmentoBusqueda, lista);
                cantidadPendienteBuscar -= amplitudSegmentoBusqueda;
                progressBar.PerformStep();
            }

            if(cantidadPendienteBuscar > 0)
            {
                this.generadorVA.generarListaVA(cantidadPendienteBuscar, lista);
            }
            progressBar.Value = (int)cantidad;

            return lista;
        }


        /// <summary>
        /// Metodo auxiliar que permite calcular en cuantos segmentos dividir la generacion de un listado de gran cantidad de variables aleatorias.
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        private int CalcularSegmentosBusqueda(double cantidad)
        {
            int cantidadSegmentosBusqueda = 1;
            if (cantidad > 10000000)
            {
                cantidadSegmentosBusqueda = 500;
            }
            else if (cantidad > 5000000)
            {
                cantidadSegmentosBusqueda = 400;
            }
            else if (cantidad > 1000000)
            {
                cantidadSegmentosBusqueda = 300;
            }
            else if (cantidad > 100000)
            {
                cantidadSegmentosBusqueda = 200;
            }
            else if (cantidad > 10000)
            {
                cantidadSegmentosBusqueda = 100;
            }
            return cantidadSegmentosBusqueda;
        }
    }
}
