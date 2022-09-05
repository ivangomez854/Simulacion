using MathNet.Numerics.Distributions;
using Simulacion.Controladores;
using Simulacion.Entidades;
using Simulacion.Entidades.Interfaces;
using Simulacion.Entidades.Randoms;
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

        private BindingList<VariableAleatoria> listita = new BindingList<VariableAleatoria>();

        public FormTablero()
        {
            InitializeComponent();
            this.inicializarComponentes();
        }

        private void inicializarComponentes()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            Reiniciar();
        }

        private void cargarCombos()
        {
            IList<KeyValuePair<int, string>> metodosRnd = new List<KeyValuePair<int, string>>();
            metodosRnd.Add(new KeyValuePair<int, string>(3, "Provisto por lenguaje"));
            metodosRnd.Add(new KeyValuePair<int, string>(2, "Congruencial mixto"));
            metodosRnd.Add(new KeyValuePair<int, string>(1, "Congruencial multiplicativo"));
            metodosRnd.Add(new KeyValuePair<int, string>(0, "Congruencial aditivo"));

            this.cboMetodoRandom.DataSource = metodosRnd;
            this.cboMetodoRandom.ValueMember = "Key";
            this.cboMetodoRandom.DisplayMember = "Value";
            this.cboMetodoRandom.SelectedValue = 3;

            IList<KeyValuePair<int, string>> distribuciones = new List<KeyValuePair<int, string>>();
            distribuciones.Add(new KeyValuePair<int, string>(3, "Uniforme"));
            distribuciones.Add(new KeyValuePair<int, string>(2, "Exponencial"));
            distribuciones.Add(new KeyValuePair<int, string>(1, "Normal"));
            distribuciones.Add(new KeyValuePair<int, string>(0, "Poisson"));

            this.cboDistribuciones.DataSource = distribuciones;
            this.cboDistribuciones.ValueMember = "Key";
            this.cboDistribuciones.DisplayMember = "Value";
            this.cboDistribuciones.SelectedValue = 1;
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
            this.reiniciar();

            var controller = new ControladorVA(this.getGeneradorVA());

            this.listita = controller.generarListadoVA((double)this.txtCantidad.Value, this.progressBar);

            this.dataGridView1.DataSource = this.listita;
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 1;

            this.gbIntervalos.Visible = true;

            if ((int)this.cboDistribuciones.SelectedValue == 0)
            {
                this.txtCantidadIntervalos.Enabled = false;
                this.btnAutocalcular.Enabled = false;
                this.txtCantidadIntervalos.Value = this.listita.Select(va => va.ValorAleatorio).Distinct().Count();
            } else
            {
                this.txtCantidadIntervalos.Enabled = true;
                this.btnAutocalcular.Enabled = true;
            }

            this.progressBar.Value = 0;
        }

        private IGeneradorRandom getGeneradorRandom()
        {
            switch (this.cboMetodoRandom.SelectedValue)
            {
                case 3:
                    return new MetodoLenguaje();
                case 2:
                    return new MetodoCongruencialMixto((double)this.txtA.Value, (double)this.txtC.Value, (double)this.txtModulo.Value, (double)this.txtSemilla.Value);
                case 1:
                    return new MetodoCongruencialMixto((double)this.txtA.Value, (double)this.txtModulo.Value, (double)this.txtSemilla.Value);
                case 0:
                    return new MetodoCongruencialAditivo((double)this.txtA.Value, (double)this.txtC.Value, (double)this.txtModulo.Value, (double)this.txtSemilla.Value);
                default:
                    return null;
            }
        }

        private IGeneradorVA getGeneradorVA()
        {
            IGeneradorRandom rnd = this.getGeneradorRandom();

            switch (this.cboDistribuciones.SelectedValue)
            {
                case 3:
                    return new GeneradorVAUniforme(rnd, (double)this.txtLimA.Value, (double)this.txtLimB.Value);
                case 2:
                    return new GeneradorVAExponencialNegativa(rnd, (double)this.txtLamda.Value);
                case 1:
                    return new GeneradorVANormal(rnd, (double)this.txtMedia.Value, (double)this.txtDesvEst.Value);
                case 0:
                    return new GeneradorVAPoisson(rnd, (double)this.txtLamda.Value);
                default:
                    return null;
            }
        }

        private GeneradorIntervalo getGeneradorIntervalo()
        {
            switch (this.cboDistribuciones.SelectedValue)
            {
                case 3:
                    return new GeneradorIntervaloUniforme(this.listita, (int)this.txtCantidadIntervalos.Value);
                case 2:
                    return new GeneradorIntervaloExponencial(this.listita, (int)this.txtCantidadIntervalos.Value, (double)this.txtLamda.Value);
                case 1:
                    return new GeneradorIntervaloNormal(this.listita, (int)this.txtCantidadIntervalos.Value, (double)this.txtMedia.Value, (double)this.txtDesvEst.Value);
                case 0:
                    return new GeneradorIntervaloPoisson(this.listita, (int)this.txtCantidadIntervalos.Value, (double)this.txtLamda.Value); ;
                default:
                    return null;
            }
        }

        private void btnGenerarIntervalos_Click(object sender, EventArgs e)
        {
            this.reiniciarGrafico();


            GeneradorIntervalo generadorIntervalo = this.getGeneradorIntervalo();

            List<Intervalo> intervalos = generadorIntervalo.getIntervalos();

            int cantidadIntervalos = intervalos.Count;

            this.chartIntervalos.Width = 31 * cantidadIntervalos;

            double chiCuadradoCalculado = 0;

            foreach (var intervalo in intervalos)
            {
                this.chartIntervalos.Series["serieFrecuenciaObservada"].Points.AddXY(intervalo.orden, intervalo.frecuenciaObservada);
                this.chartIntervalos.Series["serieFrecuenciaEsperada"].Points.AddXY(intervalo.orden, intervalo.frecuenciaEsperada);
                chiCuadradoCalculado += intervalo.chiCuadradoCalculado;
            }

            this.txtChiCuadradoCalculado.Value = (decimal)chiCuadradoCalculado;

            ChiSquared ch = new ChiSquared(cantidadIntervalos - 1);
            double chiCuadradoTabulado = ch.InverseCumulativeDistribution(0.95);
            this.txtChiCuadradoTabulado.Value = (decimal)chiCuadradoTabulado;

            string mensaje;
            if (chiCuadradoCalculado <= chiCuadradoTabulado)
            {
                mensaje = "Dado que el chi calculado es menor o igual al chi por tabla NO se puede rechazar la hipótesis"
                    + " de que la muestra proviene de la distribución de probabilidad seleccionada";
            }
            else
            {
                mensaje = "Dado que el chi calculado es mayor al chi por tabla se puede rechazar la hipótesis"
                   + " de que la muestra proviene de la distribución de probabilidad seleccionada";
            }
            this.tbxResultadoChiCuadrado.Text = mensaje;

            this.lblFrecuenciaEsperada.Visible = true;
            this.pnlFrecuenciaEsperada.Visible = true;
            this.lblFrecuenciaObservada.Visible = true;
            this.pnlFrecuenciaObservada.Visible = true;

            this.pnlGrafico.Visible = true;

            this.gbChiCuadrado.Visible = true;
        }

        private void btnAutocalcular_Click(object sender, EventArgs e)
        {
            this.txtCantidadIntervalos.Value = this.getCantidadIntervalos(this.listita.Count);
        }

        private int getCantidadIntervalos(int cantidadNumeros)
        {
            int cantidadIntervalos = Convert.ToInt32(Math.Ceiling(Math.Sqrt(cantidadNumeros)));
            if (cantidadIntervalos % 2 == 0)
            {
                cantidadIntervalos++;
            }
            return cantidadIntervalos;
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            this.reiniciar();
        }

        private void reiniciar()
        {
            this.reiniciarGrafico();
            this.reiniciarAleatorios();
        }

        private void reiniciarGrafico()
        {
            this.chartIntervalos.Series["serieFrecuenciaObservada"].Points.Clear();
            this.chartIntervalos.Series["serieFrecuenciaEsperada"].Points.Clear();

            this.pnlGrafico.Visible = false;

            this.lblFrecuenciaEsperada.Visible = false;
            this.pnlFrecuenciaEsperada.Visible = false;
            this.lblFrecuenciaObservada.Visible = false;
            this.pnlFrecuenciaObservada.Visible = false;

            this.gbChiCuadrado.Visible = false;

            System.GC.Collect();
        }

        private void reiniciarAleatorios()
        {
            this.listita.Clear();

            System.GC.Collect();
        }

        private void cboDistribuciones_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (this.cboDistribuciones.SelectedValue)
            {
                case 3:
                    this.txtLimA.Enabled = true;
                    this.txtLimB.Enabled = true;
                    this.txtLamda.Enabled = false;
                    this.txtMedia.Enabled = false;
                    this.txtDesvEst.Enabled = false;
                    break;
                case 2:
                    this.txtLimA.Enabled = false;
                    this.txtLimB.Enabled = false;
                    this.txtLamda.Enabled = true;
                    this.txtMedia.Enabled = false;
                    this.txtDesvEst.Enabled = false;
                    break;
                case 1:
                    this.txtLimA.Enabled = false;
                    this.txtLimB.Enabled = false;
                    this.txtLamda.Enabled = false;
                    this.txtMedia.Enabled = true;
                    this.txtDesvEst.Enabled = true;
                    break;
                case 0:
                    this.txtLimA.Enabled = false;
                    this.txtLimB.Enabled = false;
                    this.txtLamda.Enabled = true;
                    this.txtMedia.Enabled = false;
                    this.txtDesvEst.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void cboMetodoRandom_SelectedValueChanged(object sender, EventArgs e)
        {

            switch (this.cboMetodoRandom.SelectedValue)
            {
                case 3:
                    this.txtA.Enabled = false;
                    this.txtC.Enabled = false;
                    this.txtModulo.Enabled = false;
                    this.txtSemilla.Enabled = false;
                    break;
                default:
                    this.txtA.Enabled = true;
                    this.txtC.Enabled = true;
                    this.txtModulo.Enabled = true;
                    this.txtSemilla.Enabled = true;
                    break;
            }
        }
    }
}
