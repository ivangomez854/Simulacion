using MathNet.Numerics.Distributions;
using Simulacion.Controladores;
using Simulacion.Entidades;
using Simulacion.Entidades.Interfaces;
using Simulacion.Entidades.Randoms;
using Simulacion.Entidades.Utiles;
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

        private Paginador paginador;

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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (!validarControlesRandom())
            {
                MessageBox.Show("Parametros de generador de randoms incorrectos");
                return;
            } else if (!validarControlesDistribuciones())
            {
                MessageBox.Show("Parametros de distribucion incorrectos");
                return;
            }

            this.reiniciar();

            this.gbIntervalos.Visible = false;

            var controller = new ControladorVA(this.getGeneradorVA());
            
            this.listita = controller.generarListadoVA((double)this.txtCantidad.Value, this.progressBar);

            this.paginador = new Paginador(this.listita, 20);

            this.dataGridView1.DataSource = this.paginador.ObtenerUltimaPagina();
            this.dataGridView1.FirstDisplayedScrollingRowIndex = this.dataGridView1.Rows.Count - 1;

            this.gbIntervalos.Visible = true;

            if ((int)this.cboDistribuciones.SelectedValue == 0)
            {
                this.txtCantidadIntervalos.Enabled = false;
                this.btnAutocalcular.Enabled = false;
                this.txtCantidadIntervalos.Value = this.listita.Select(va => va.ValorAleatorio).Distinct().Count();
            }
            else
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
                    return new MetodoCongruencialMixtoMultiplicativo((double)this.txtA.Value, (double)this.txtC.Value, (double)this.txtModulo.Value, (double)this.txtSemilla.Value);
                case 1:
                    return new MetodoCongruencialMixtoMultiplicativo((double)this.txtA.Value, (double)this.txtModulo.Value, (double)this.txtSemilla.Value);
                case 0:
                    return new MetodoCongruencialAditivo((double)this.txtA.Value, (double)this.txtC.Value, (double)this.txtModulo.Value, (double)this.txtSemilla.Value);
                default:
                    return null;
            }
        }

        private bool validarControlesRandom()
        {
            if ((int)cboMetodoRandom.SelectedValue < 3)
                return (txtA.Value != 0 && txtModulo.Value != 0);
            return true;
        }

        private bool validarControlesDistribuciones()
        {
            if ((int)cboDistribuciones.SelectedValue == 3)
                return (txtLimA.Value < txtLimB.Value);
            if ((int)cboDistribuciones.SelectedValue == 2)
                return (txtLamda.Value > 0);
            if ((int)cboDistribuciones.SelectedValue == 0)
                return (txtLamda.Value > 0);
            return true;
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

            this.btnAutocalcular.Enabled = false;
            this.btnGenerarIntervalos.Enabled = false;
            this.btnGenerarIntervalos.Text = "Generando";

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

            var gradosDeLibertad = cantidadIntervalos - 1;

            switch (this.cboDistribuciones.SelectedValue)
            {
                case 2:
                    gradosDeLibertad-= 1;
                    break;
                case 1:
                    gradosDeLibertad -= 2;
                    break;
                case 0:
                    gradosDeLibertad -= 1;
                    break;
                default:
                    break;
            }

            ChiSquared ch = new ChiSquared(gradosDeLibertad);
            double chiCuadradoTabulado = ch.InverseCumulativeDistribution(0.95);
            this.txtChiCuadradoTabulado.Value = (decimal)chiCuadradoTabulado;

            string mensaje;
            if (chiCuadradoCalculado <= chiCuadradoTabulado)
            {
                mensaje = "Dado que el chi calculado es menor o igual al chi por tabla NO se puede rechazar la hip??tesis"
                    + " de que la muestra proviene de la distribuci??n de probabilidad seleccionada";
            }
            else
            {
                mensaje = "Dado que el chi calculado es mayor al chi por tabla se puede rechazar la hip??tesis"
                   + " de que la muestra proviene de la distribuci??n de probabilidad seleccionada";
            }
            this.tbxResultadoChiCuadrado.Text = mensaje;

            this.lblFrecuenciaEsperada.Visible = true;
            this.pnlFrecuenciaEsperada.Visible = true;
            this.lblFrecuenciaObservada.Visible = true;
            this.pnlFrecuenciaObservada.Visible = true;

            this.pnlGrafico.Visible = true;

            this.gbChiCuadrado.Visible = true;

            this.btnAutocalcular.Enabled = true;
            this.btnGenerarIntervalos.Enabled = true;
            this.btnGenerarIntervalos.Text = "Generar";
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
            this.paginador = null;
            this.dataGridView1.DataSource = null;
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

        private void btnPrimeraPagina_Click(object sender, EventArgs e)
        {
            if (this.paginador != null)
            {
                this.dataGridView1.DataSource = this.paginador.ObtenerPrimerPagina();
                this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void btnPaginaAnterior_Click(object sender, EventArgs e)
        {
            if (this.paginador != null)
            {
                BindingList<VariableAleatoria> aux = this.paginador.ObtenerPaginaAnterior();

                this.dataGridView1.DataSource = aux is null ? this.dataGridView1.DataSource : aux;
                this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void btnPaginaSiguiente_Click(object sender, EventArgs e)
        {
            if (this.paginador != null)
            {
                BindingList<VariableAleatoria> aux = this.paginador.ObtenerPaginaSiguiente();

                this.dataGridView1.DataSource = aux is null ? this.dataGridView1.DataSource : aux;
                this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void btnUltimaPagina_Click(object sender, EventArgs e)
        {
            if (this.paginador != null)
            {
                this.dataGridView1.DataSource = this.paginador.ObtenerUltimaPagina();
                this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void btnBuscarPagina_Click(object sender, EventArgs e)
        {
            if (this.paginador != null)
            {
                BindingList<VariableAleatoria> aux = this.paginador.BuscarPaginaXIndice(Convert.ToInt32(txtBuscarPagina.Value.ToString()) - 1);

                if (aux is null)
                {
                    MessageBox.Show("Fuera de rango. Total items: " + this.listita.Count);
                    return;
                }

                this.dataGridView1.DataSource = aux;
                this.dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }
    }
}
