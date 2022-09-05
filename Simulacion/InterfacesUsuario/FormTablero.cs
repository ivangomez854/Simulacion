using Simulacion.Controladores;
using Simulacion.Entidades;
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
            Reiniciar();
        }

        private void cargarCombos()
        {   
            IList<KeyValuePair<int, string>> metodosRnd = new List<KeyValuePair<int, string>>();
            metodosRnd.Add(new KeyValuePair<int, string> (3, "Provisto por lenguaje"));
            metodosRnd.Add(new KeyValuePair<int, string> (2, "Congruencial mixto"));
            metodosRnd.Add(new KeyValuePair<int, string> (1, "Congruencial multiplicativo"));
            metodosRnd.Add(new KeyValuePair<int, string> (0, "Congruencial aditivo"));

            this.cboMetodoRandom.DataSource = metodosRnd;
            this.cboMetodoRandom.ValueMember = "Key";
            this.cboMetodoRandom.DisplayMember = "Value";
            this.cboMetodoRandom.SelectedValue = 2;

            IList<KeyValuePair<int, string>> distribuciones = new List<KeyValuePair<int, string>>();
            distribuciones.Add(new KeyValuePair<int, string> (3, "Uniforme"));
            distribuciones.Add(new KeyValuePair<int, string> (2, "Exponencial"));
            distribuciones.Add(new KeyValuePair<int, string> (1, "Normal"));
            distribuciones.Add(new KeyValuePair<int, string> (0, "Poisson"));

            this.cboDistribuciones.DataSource = distribuciones;
            this.cboDistribuciones.ValueMember = "Key";
            this.cboDistribuciones.DisplayMember = "Value";
            this.cboMetodoRandom.SelectedValue = 1;
        }

        private void Reiniciar()
        {
            txtA.Value = DEFAULT_CONSTANTE_MULTIPLICATIVA;
            txtC.Value = DEFAULT_CONSTANTE_INDEPENDIENTE;
            txtModulo.Value = DEFAULT_MODULO;
            txtSemilla.Value = DEFAULT_SEMILLA;

            this.cargarCombos();
            this.HabilitarDeshabilitarControlesRandom(true);
        }

        private void HabilitarDeshabilitarControlesRandom(bool habilitar)
        {
            txtA.Value = 0;
            txtA.Enabled = habilitar;

            txtC.Value = 0;
            txtC.Enabled = habilitar;

            txtModulo.Value = 0;
            txtModulo.Enabled = habilitar;

            txtSemilla.Value = 0;
            txtSemilla.Enabled = habilitar;
        }

        private void DeshabilitarControlesDistribuciones()
        {
            txtLimA.Value = 0;
            txtLimA.Enabled = false;
            txtLimB.Value = 0;
            txtLimB.Enabled = false;

            txtMedia.Value = 0;
            txtMedia.Enabled = false;

            txtDesvEst.Value = 0;
            txtDesvEst.Enabled = false;

            txtLamda.Value = 0;
            txtLamda.Enabled = false;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            var rnd = new MetodoCongruencialMixto(15, 0, 1024, 16);

            var generadorNormal = new GeneradorVANormal(rnd, 12, 2);

            var controller = new ControladorVA(generadorNormal);

            var listita = controller.generarListadoVA(10000000d, this.progressBar);

            Console.WriteLine(listita.Last.Value.ValorAleatorio + " VA/ORDEN " + listita.Last.Value.Orden);

            this.progressBar.Value = 0;
        }
    }
}
