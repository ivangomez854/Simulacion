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
            this.gbRandom = new System.Windows.Forms.GroupBox();
            this.gbDistribucion = new System.Windows.Forms.GroupBox();
            this.cboMetodoRandom = new System.Windows.Forms.ComboBox();
            this.cboDistribuciones = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menu = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.gbRandom.SuspendLayout();
            this.gbDistribucion.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRandom
            // 
            this.gbRandom.Controls.Add(this.cboMetodoRandom);
            this.gbRandom.Location = new System.Drawing.Point(10, 27);
            this.gbRandom.Name = "gbRandom";
            this.gbRandom.Size = new System.Drawing.Size(605, 100);
            this.gbRandom.TabIndex = 0;
            this.gbRandom.TabStop = false;
            this.gbRandom.Text = "Random";
            // 
            // gbDistribucion
            // 
            this.gbDistribucion.Controls.Add(this.cboDistribuciones);
            this.gbDistribucion.Location = new System.Drawing.Point(629, 27);
            this.gbDistribucion.Name = "gbDistribucion";
            this.gbDistribucion.Size = new System.Drawing.Size(486, 100);
            this.gbDistribucion.TabIndex = 0;
            this.gbDistribucion.TabStop = false;
            this.gbDistribucion.Text = "Distribución estadística";
            // 
            // cboMetodoRandom
            // 
            this.cboMetodoRandom.FormattingEnabled = true;
            this.cboMetodoRandom.Location = new System.Drawing.Point(6, 19);
            this.cboMetodoRandom.Name = "cboMetodoRandom";
            this.cboMetodoRandom.Size = new System.Drawing.Size(160, 21);
            this.cboMetodoRandom.TabIndex = 0;
            // 
            // cboDistribuciones
            // 
            this.cboDistribuciones.FormattingEnabled = true;
            this.cboDistribuciones.Location = new System.Drawing.Point(6, 19);
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
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
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
            this.salirToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.salirToolStripMenuItem2.Text = "Salir";
            // 
            // FormTablero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbDistribucion);
            this.Controls.Add(this.gbRandom);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormTablero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormTablero";
            this.gbRandom.ResumeLayout(false);
            this.gbDistribucion.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}