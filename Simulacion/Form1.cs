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
            var test = new MetodoCongruencialMixto(15, 654, 1024, 16);

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

            salida = test.getVectorEstado();
            Console.WriteLine("RND: " + Math.Round(salida.rnd, 4));
            Console.WriteLine("XI: " + salida.xi);
            Console.WriteLine("ORDEN: " + salida.orden);
        }
    }
}
