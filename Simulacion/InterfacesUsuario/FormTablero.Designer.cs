namespace Simulacion.InterfacesUsuario
{
    partial class FormTablero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTablero));
            this.gbRandom = new System.Windows.Forms.GroupBox();
            this.txtSemilla = new System.Windows.Forms.NumericUpDown();
            this.txtModulo = new System.Windows.Forms.NumericUpDown();
            this.txtC = new System.Windows.Forms.NumericUpDown();
            this.txtA = new System.Windows.Forms.NumericUpDown();
            this.lblSemilla = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.lblC = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.cboMetodoRandom = new System.Windows.Forms.ComboBox();
            this.gbDistribucion = new System.Windows.Forms.GroupBox();
            this.txtLamda = new System.Windows.Forms.NumericUpDown();
            this.lblLamda = new System.Windows.Forms.Label();
            this.txtDesvEst = new System.Windows.Forms.NumericUpDown();
            this.txtMedia = new System.Windows.Forms.NumericUpDown();
            this.txtLimB = new System.Windows.Forms.NumericUpDown();
            this.txtLimA = new System.Windows.Forms.NumericUpDown();
            this.lblDesv = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.lblLimB = new System.Windows.Forms.Label();
            this.lblLimA = new System.Windows.Forms.Label();
            this.cboDistribuciones = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.orden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variable_aleatoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbRandom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemilla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA)).BeginInit();
            this.gbDistribucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLamda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesvEst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimA)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbRandom
            // 
            this.gbRandom.Controls.Add(this.txtSemilla);
            this.gbRandom.Controls.Add(this.txtModulo);
            this.gbRandom.Controls.Add(this.txtC);
            this.gbRandom.Controls.Add(this.txtA);
            this.gbRandom.Controls.Add(this.lblSemilla);
            this.gbRandom.Controls.Add(this.lblModulo);
            this.gbRandom.Controls.Add(this.lblC);
            this.gbRandom.Controls.Add(this.lblA);
            this.gbRandom.Controls.Add(this.cboMetodoRandom);
            this.gbRandom.Location = new System.Drawing.Point(10, 27);
            this.gbRandom.Name = "gbRandom";
            this.gbRandom.Size = new System.Drawing.Size(561, 106);
            this.gbRandom.TabIndex = 0;
            this.gbRandom.TabStop = false;
            this.gbRandom.Text = "Random";
            // 
            // txtSemilla
            // 
            this.txtSemilla.Location = new System.Drawing.Point(434, 76);
            this.txtSemilla.Name = "txtSemilla";
            this.txtSemilla.Size = new System.Drawing.Size(120, 20);
            this.txtSemilla.TabIndex = 9;
            // 
            // txtModulo
            // 
            this.txtModulo.Location = new System.Drawing.Point(287, 76);
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(120, 20);
            this.txtModulo.TabIndex = 8;
            // 
            // txtC
            // 
            this.txtC.Location = new System.Drawing.Point(146, 76);
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(120, 20);
            this.txtC.TabIndex = 7;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(6, 76);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(120, 20);
            this.txtA.TabIndex = 6;
            // 
            // lblSemilla
            // 
            this.lblSemilla.AutoSize = true;
            this.lblSemilla.Location = new System.Drawing.Point(431, 60);
            this.lblSemilla.Name = "lblSemilla";
            this.lblSemilla.Size = new System.Drawing.Size(65, 13);
            this.lblSemilla.TabIndex = 4;
            this.lblSemilla.Text = "Valor semilla";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Location = new System.Drawing.Point(284, 60);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(63, 13);
            this.lblModulo.TabIndex = 3;
            this.lblModulo.Text = "Cte. módulo";
            // 
            // lblC
            // 
            this.lblC.AutoSize = true;
            this.lblC.Location = new System.Drawing.Point(143, 60);
            this.lblC.Name = "lblC";
            this.lblC.Size = new System.Drawing.Size(106, 13);
            this.lblC.TabIndex = 2;
            this.lblC.Text = "Cte. independiente C";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(6, 60);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(101, 13);
            this.lblA.TabIndex = 1;
            this.lblA.Text = "Cte. multiiplicativa A";
            // 
            // cboMetodoRandom
            // 
            this.cboMetodoRandom.FormattingEnabled = true;
            this.cboMetodoRandom.Location = new System.Drawing.Point(6, 31);
            this.cboMetodoRandom.Name = "cboMetodoRandom";
            this.cboMetodoRandom.Size = new System.Drawing.Size(160, 21);
            this.cboMetodoRandom.TabIndex = 0;
            // 
            // gbDistribucion
            // 
            this.gbDistribucion.Controls.Add(this.txtLamda);
            this.gbDistribucion.Controls.Add(this.lblLamda);
            this.gbDistribucion.Controls.Add(this.txtDesvEst);
            this.gbDistribucion.Controls.Add(this.txtMedia);
            this.gbDistribucion.Controls.Add(this.txtLimB);
            this.gbDistribucion.Controls.Add(this.txtLimA);
            this.gbDistribucion.Controls.Add(this.lblDesv);
            this.gbDistribucion.Controls.Add(this.lblMedia);
            this.gbDistribucion.Controls.Add(this.lblLimB);
            this.gbDistribucion.Controls.Add(this.lblLimA);
            this.gbDistribucion.Controls.Add(this.cboDistribuciones);
            this.gbDistribucion.Location = new System.Drawing.Point(577, 27);
            this.gbDistribucion.Name = "gbDistribucion";
            this.gbDistribucion.Size = new System.Drawing.Size(548, 106);
            this.gbDistribucion.TabIndex = 0;
            this.gbDistribucion.TabStop = false;
            this.gbDistribucion.Text = "Distribución estadística";
            // 
            // txtLamda
            // 
            this.txtLamda.Location = new System.Drawing.Point(448, 76);
            this.txtLamda.Name = "txtLamda";
            this.txtLamda.Size = new System.Drawing.Size(90, 20);
            this.txtLamda.TabIndex = 20;
            // 
            // lblLamda
            // 
            this.lblLamda.AutoSize = true;
            this.lblLamda.Location = new System.Drawing.Point(445, 60);
            this.lblLamda.Name = "lblLamda";
            this.lblLamda.Size = new System.Drawing.Size(39, 13);
            this.lblLamda.TabIndex = 19;
            this.lblLamda.Text = "Lamda";
            // 
            // txtDesvEst
            // 
            this.txtDesvEst.Location = new System.Drawing.Point(337, 76);
            this.txtDesvEst.Name = "txtDesvEst";
            this.txtDesvEst.Size = new System.Drawing.Size(90, 20);
            this.txtDesvEst.TabIndex = 17;
            // 
            // txtMedia
            // 
            this.txtMedia.Location = new System.Drawing.Point(227, 76);
            this.txtMedia.Name = "txtMedia";
            this.txtMedia.Size = new System.Drawing.Size(90, 20);
            this.txtMedia.TabIndex = 16;
            // 
            // txtLimB
            // 
            this.txtLimB.Location = new System.Drawing.Point(114, 76);
            this.txtLimB.Name = "txtLimB";
            this.txtLimB.Size = new System.Drawing.Size(90, 20);
            this.txtLimB.TabIndex = 15;
            // 
            // txtLimA
            // 
            this.txtLimA.Location = new System.Drawing.Point(4, 76);
            this.txtLimA.Name = "txtLimA";
            this.txtLimA.Size = new System.Drawing.Size(90, 20);
            this.txtLimA.TabIndex = 14;
            // 
            // lblDesv
            // 
            this.lblDesv.AutoSize = true;
            this.lblDesv.Location = new System.Drawing.Point(334, 60);
            this.lblDesv.Name = "lblDesv";
            this.lblDesv.Size = new System.Drawing.Size(79, 13);
            this.lblDesv.TabIndex = 13;
            this.lblDesv.Text = "Desv. estandar";
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(224, 60);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(36, 13);
            this.lblMedia.TabIndex = 12;
            this.lblMedia.Text = "Media";
            // 
            // lblLimB
            // 
            this.lblLimB.AutoSize = true;
            this.lblLimB.Location = new System.Drawing.Point(111, 60);
            this.lblLimB.Name = "lblLimB";
            this.lblLimB.Size = new System.Drawing.Size(69, 13);
            this.lblLimB.TabIndex = 11;
            this.lblLimB.Text = "Límite sup. B";
            // 
            // lblLimA
            // 
            this.lblLimA.AutoSize = true;
            this.lblLimA.Location = new System.Drawing.Point(4, 60);
            this.lblLimA.Name = "lblLimA";
            this.lblLimA.Size = new System.Drawing.Size(63, 13);
            this.lblLimA.TabIndex = 10;
            this.lblLimA.Text = "Límite inf. A";
            // 
            // cboDistribuciones
            // 
            this.cboDistribuciones.FormattingEnabled = true;
            this.cboDistribuciones.Location = new System.Drawing.Point(4, 31);
            this.cboDistribuciones.Name = "cboDistribuciones";
            this.cboDistribuciones.Size = new System.Drawing.Size(160, 21);
            this.cboDistribuciones.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1401, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menu
            // 
            this.menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem2});
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(60, 20);
            this.menu.Text = "Archivo";
            // 
            // salirToolStripMenuItem2
            // 
            this.salirToolStripMenuItem2.Name = "salirToolStripMenuItem2";
            this.salirToolStripMenuItem2.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem2.Text = "Salir";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(1140, 87);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(49, 13);
            this.lblCantidad.TabIndex = 18;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(1143, 103);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(118, 20);
            this.txtCantidad.TabIndex = 21;
            // 
            // btnGenerar
            // 
            this.btnGenerar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnGenerar.Enabled = false;
            this.btnGenerar.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerar.Image")));
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerar.Location = new System.Drawing.Point(1272, 35);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnGenerar.Size = new System.Drawing.Size(107, 44);
            this.btnGenerar.TabIndex = 22;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.UseVisualStyleBackColor = false;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Enabled = false;
            this.btnReiniciar.Image = ((System.Drawing.Image)(resources.GetObject("btnReiniciar.Image")));
            this.btnReiniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReiniciar.Location = new System.Drawing.Point(1272, 89);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Padding = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnReiniciar.Size = new System.Drawing.Size(107, 44);
            this.btnReiniciar.TabIndex = 23;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReiniciar.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 663);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1401, 22);
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1124, 410);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(10, 12);
            this.flowLayoutPanel1.TabIndex = 25;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(10, 139);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1369, 518);
            this.tabControl.TabIndex = 27;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1361, 492);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Números generados";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1361, 492);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Prueba de bondad";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orden,
            this.variable_aleatoria});
            this.dataGridView1.Location = new System.Drawing.Point(3, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(300, 480);
            this.dataGridView1.TabIndex = 0;
            // 
            // orden
            // 
            this.orden.Frozen = true;
            this.orden.HeaderText = "Nro. de orden";
            this.orden.Name = "orden";
            this.orden.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // variable_aleatoria
            // 
            this.variable_aleatoria.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.variable_aleatoria.Frozen = true;
            this.variable_aleatoria.HeaderText = "Variable aleatoria";
            this.variable_aleatoria.Name = "variable_aleatoria";
            this.variable_aleatoria.Width = 104;
            // 
            // FormTablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 685);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbDistribucion);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.gbRandom);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTablero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormTablero";
            this.gbRandom.ResumeLayout(false);
            this.gbRandom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSemilla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtA)).EndInit();
            this.gbDistribucion.ResumeLayout(false);
            this.gbDistribucion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLamda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesvEst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLimA)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCantidad)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRandom;
        private System.Windows.Forms.ComboBox cboMetodoRandom;
        private System.Windows.Forms.GroupBox gbDistribucion;
        private System.Windows.Forms.ComboBox cboDistribuciones;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menu;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem2;
        private System.Windows.Forms.NumericUpDown txtSemilla;
        private System.Windows.Forms.NumericUpDown txtModulo;
        private System.Windows.Forms.NumericUpDown txtC;
        private System.Windows.Forms.NumericUpDown txtA;
        private System.Windows.Forms.Label lblSemilla;
        private System.Windows.Forms.Label lblModulo;
        private System.Windows.Forms.Label lblC;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.NumericUpDown txtCantidad;
        private System.Windows.Forms.NumericUpDown txtLamda;
        private System.Windows.Forms.Label lblLamda;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.NumericUpDown txtDesvEst;
        private System.Windows.Forms.NumericUpDown txtMedia;
        private System.Windows.Forms.NumericUpDown txtLimB;
        private System.Windows.Forms.NumericUpDown txtLimA;
        private System.Windows.Forms.Label lblDesv;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.Label lblLimB;
        private System.Windows.Forms.Label lblLimA;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn orden;
        private System.Windows.Forms.DataGridViewTextBoxColumn variable_aleatoria;
    }
}