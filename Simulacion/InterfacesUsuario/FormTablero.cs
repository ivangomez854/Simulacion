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
        /// <summary>
        /// Valor por defecto del input 'Semilla'
        /// </summary>
        private static readonly int DEFAULT_SEMILLA = 37;

        /// <summary>
        /// Valor por defecto del input 'Constante Multiplicativa'
        /// </summary>
        private static readonly int DEFAULT_CONSTANTE_MULTIPLICATIVA = 19;

        /// <summary>
        /// Valor por defecto del input 'Constante Independiente'
        /// </summary>
        private static readonly int DEFAULT_CONSTANTE_INDEPENDIENTE = 7;

        /// <summary>
        /// Valor por defecto del input 'Modulo'
        /// </summary>
        private static readonly int DEFAULT_MODULO = 53;
        
        /// <summary>
        /// Valor por defecto del input 'Modulo'
        /// </summary>
        private static readonly int DEFAULT_DESV_EST = 1;
        
        /// <summary>
        /// Valor por defecto del input 'Modulo'
        /// </summary>
        private static readonly int DEFAULT_MEDIA = 0;

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
            this.cboMetodoRandom.SelectedIndex = 1;

            IList<KeyValuePair<int, string>> distribuciones = new List<KeyValuePair<int, string>>();
            distribuciones.Add(new KeyValuePair<int, string> (0, "Uniforme"));
            distribuciones.Add(new KeyValuePair<int, string> (1, "Exponencial"));
            distribuciones.Add(new KeyValuePair<int, string> (2, "Normal"));
            distribuciones.Add(new KeyValuePair<int, string> (3, "Poisson"));

            this.cboDistribuciones.DataSource = distribuciones;
            this.cboDistribuciones.ValueMember = "Key";
            this.cboDistribuciones.DisplayMember = "Value";
            this.cboMetodoRandom.SelectedIndex = 2;
        }

        private void Reiniciar()
        {
            txtA.Value = DEFAULT_CONSTANTE_MULTIPLICATIVA;
            txtC.Value = DEFAULT_CONSTANTE_INDEPENDIENTE;
            txtModulo.Value = DEFAULT_MODULO;
            txtSemilla.Value = DEFAULT_SEMILLA;
           
        }

        private void DeshabilitarControlesRandom()
        {
            txtA.Value = 0;
            txtA.Enabled = false;

            txtC.Value = 0;
            txtC.Enabled = false;

            txtModulo.Value = 0;
            txtModulo.Enabled = false;

            txtSemilla.Value = 0;
            txtSemilla.Enabled = false;
        }
    }
}
