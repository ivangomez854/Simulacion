using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulacion.InterfacesUsuario
{
    public partial class FormTablero : Form
    {

        public FormTablero()
        {
            InitializeComponent();
            this.inicializarComponentes();
        }

        private void inicializarComponentes()
        {
            cargarCombos();
        }

        private void cargarCombos()
        {   
            IList<KeyValuePair<int, string>> metodosRnd = new List<KeyValuePair<int, string>>();
            metodosRnd.Add(new KeyValuePair<int, string> (0, "Provisto por lenguaje"));
            metodosRnd.Add(new KeyValuePair<int, string> (1, "Congruencial mixto"));
            metodosRnd.Add(new KeyValuePair<int, string> (2, "Congruencial multiplicativo"));
            metodosRnd.Add(new KeyValuePair<int, string> (3, "Congruencial aditivo"));

            this.cboMetodoRandom.DataSource = metodosRnd;
            this.cboMetodoRandom.ValueMember = "Key";
            this.cboMetodoRandom.DisplayMember = "Value";

            IList<KeyValuePair<int, string>> distribuciones = new List<KeyValuePair<int, string>>();
            distribuciones.Add(new KeyValuePair<int, string> (0, "Uniforme"));
            distribuciones.Add(new KeyValuePair<int, string> (1, "Exponencial"));
            distribuciones.Add(new KeyValuePair<int, string> (2, "Normal"));
            distribuciones.Add(new KeyValuePair<int, string> (3, "Poisson"));

            this.cboDistribuciones.DataSource = distribuciones;
            this.cboDistribuciones.ValueMember = "Key";
            this.cboDistribuciones.DisplayMember = "Value";
        }
    }
}
