using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simulacion.Entidades;

namespace Simulacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var test = new MetodoCongruencialMixto(15, 0, 1024, 16);

            Console.WriteLine("Primer RND");
            test.obtenerProximoRandom();
            var primero = test.getVectorEstado();

            Console.WriteLine("RND: " + Math.Round(primero.rnd, 4));
            Console.WriteLine("XI: " + primero.xi);
            Console.WriteLine("ORDEN: " + primero.orden);

            Console.WriteLine("..................................");

            test.generarRandoms(30);

            var salida = test.getVectorEstado();

            Console.WriteLine("RND: " + Math.Round(salida.rnd, 4));
            Console.WriteLine("XI: " + salida.xi);
            Console.WriteLine("ORDEN: " + salida.orden);


            Console.WriteLine("..................................");


            var lista = test.generarListaRandoms(25);
            foreach(var item in lista)
            {
                Console.WriteLine("RND: " + Math.Round(item.Value, 4));
                Console.WriteLine("ORDEN: " + item.Key);
                Console.WriteLine("..................................");
            }

            Console.WriteLine("..................................");


            test.generarRandoms(30000000);
            salida = test.getVectorEstado();
            Console.WriteLine("RND: " + Math.Round(salida.rnd, 4));
            Console.WriteLine("XI: " + salida.xi);
            Console.WriteLine("ORDEN: " + salida.orden);
        }

        private void btnVANormal_Click(object sender, EventArgs e)
        {
            var rnd = new MetodoCongruencialMixto(15, 0, 1024, 16);

            var generador = new GeneradorVANormal(rnd, 12, 2);

            var lista = generador.generarListaVA(31);

            foreach(var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido generar 3 mas");
            lista = generador.generarListaVA(3);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido el estado actual");
            var estado = generador.ObtenerEstadoActual();
            Console.WriteLine("VA: " + Math.Round(estado.ValorAleatorio, 4));
            Console.WriteLine("Orden: " + estado.Orden);
            Console.WriteLine("......................");



            Console.WriteLine("Le pido generar 1 mas");
            lista = generador.generarListaVA(1);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido generar 1 mas");
            lista = generador.generarListaVA(1);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }
        }

        private void btnUniforme_Click(object sender, EventArgs e)
        {
            var rnd = new MetodoCongruencialMixto(15, 0, 1024, 16);

            var generador = new GeneradorVAUniforme(rnd, 2, 12);

            var lista = generador.generarListaVA(31);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido generar 3 mas");
            lista = generador.generarListaVA(3);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido el estado actual");
            var estado = generador.ObtenerEstadoActual();
            Console.WriteLine("VA: " + Math.Round(estado.ValorAleatorio, 4));
            Console.WriteLine("Orden: " + estado.Orden);
            Console.WriteLine("......................");



            Console.WriteLine("Le pido generar 1 mas");
            lista = generador.generarListaVA(1);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido generar 1 mas");
            lista = generador.generarListaVA(1);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var rnd = new MetodoCongruencialMixto(23, 601, 1024, 16);

            var generador = new GeneradorVAPoisson(rnd, 12);

            var lista = generador.generarListaVA(31);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido generar 3 mas");
            lista = generador.generarListaVA(3);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido el estado actual");
            var estado = generador.ObtenerEstadoActual();
            Console.WriteLine("VA: " + Math.Round(estado.ValorAleatorio, 4));
            Console.WriteLine("Orden: " + estado.Orden);
            Console.WriteLine("......................");



            Console.WriteLine("Le pido generar 1 mas");
            lista = generador.generarListaVA(1);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }

            Console.WriteLine("Le pido generar 1 mas");
            lista = generador.generarListaVA(1);

            foreach (var item in lista)
            {
                Console.WriteLine("VA: " + Math.Round(item.ValorAleatorio, 4));
                Console.WriteLine("Orden: " + item.Orden);
                Console.WriteLine("......................");
            }
        }
    }
}
