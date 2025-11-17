namespace ProyectoP1
{
    partial class fmrGema
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
            this.lblfigura = new System.Windows.Forms.Label();
            this.grbGafico = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grbEntrada = new System.Windows.Forms.GroupBox();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.lblLado = new System.Windows.Forms.Label();
            this.grbEscala = new System.Windows.Forms.GroupBox();
            this.hScrollEscala = new System.Windows.Forms.TrackBar();
            this.grbRotacion = new System.Windows.Forms.GroupBox();
            this.btnRotarIzquierda = new System.Windows.Forms.Button();
            this.btnRotarDerecha = new System.Windows.Forms.Button();
            this.grbTraslacion = new System.Windows.Forms.GroupBox();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.grbSalida = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnResetear = new System.Windows.Forms.Button();
            this.btnGraficar = new System.Windows.Forms.Button();
            this.lbltitulo = new System.Windows.Forms.Label();
            this.grbGafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbEntrada.SuspendLayout();
            this.grbEscala.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hScrollEscala)).BeginInit();
            this.grbRotacion.SuspendLayout();
            this.grbTraslacion.SuspendLayout();
            this.grbSalida.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblfigura
            // 
            this.lblfigura.AutoSize = true;
            this.lblfigura.Font = new System.Drawing.Font("Times New Roman", 16F);
            this.lblfigura.Location = new System.Drawing.Point(169, 144);
            this.lblfigura.Name = "lblfigura";
            this.lblfigura.Size = new System.Drawing.Size(121, 36);
            this.lblfigura.TabIndex = 28;
            this.lblfigura.Text = "Figura 3";
            // 
            // grbGafico
            // 
            this.grbGafico.Controls.Add(this.picCanvas);
            this.grbGafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbGafico.Location = new System.Drawing.Point(475, 14);
            this.grbGafico.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbGafico.Name = "grbGafico";
            this.grbGafico.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbGafico.Size = new System.Drawing.Size(847, 872);
            this.grbGafico.TabIndex = 24;
            this.grbGafico.TabStop = false;
            this.grbGafico.Text = "Grafico";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(8, 27);
            this.picCanvas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(831, 831);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // grbEntrada
            // 
            this.grbEntrada.Controls.Add(this.txtSide);
            this.grbEntrada.Controls.Add(this.lblLado);
            this.grbEntrada.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbEntrada.Location = new System.Drawing.Point(59, 190);
            this.grbEntrada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbEntrada.Name = "grbEntrada";
            this.grbEntrada.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbEntrada.Size = new System.Drawing.Size(384, 98);
            this.grbEntrada.TabIndex = 22;
            this.grbEntrada.TabStop = false;
            this.grbEntrada.Text = "Entrada";
            // 
            // txtSide
            // 
            this.txtSide.Location = new System.Drawing.Point(185, 43);
            this.txtSide.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(148, 30);
            this.txtSide.TabIndex = 1;
            // 
            // lblLado
            // 
            this.lblLado.AutoSize = true;
            this.lblLado.Location = new System.Drawing.Point(38, 43);
            this.lblLado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLado.Name = "lblLado";
            this.lblLado.Size = new System.Drawing.Size(139, 25);
            this.lblLado.TabIndex = 0;
            this.lblLado.Text = "Ingrese Altura:";
            // 
            // grbEscala
            // 
            this.grbEscala.Controls.Add(this.hScrollEscala);
            this.grbEscala.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbEscala.Location = new System.Drawing.Point(61, 739);
            this.grbEscala.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbEscala.Name = "grbEscala";
            this.grbEscala.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbEscala.Size = new System.Drawing.Size(382, 145);
            this.grbEscala.TabIndex = 27;
            this.grbEscala.TabStop = false;
            this.grbEscala.Text = "Escala";
            this.grbEscala.UseWaitCursor = true;
            // 
            // hScrollEscala
            // 
            this.hScrollEscala.Location = new System.Drawing.Point(15, 52);
            this.hScrollEscala.Name = "hScrollEscala";
            this.hScrollEscala.Size = new System.Drawing.Size(348, 69);
            this.hScrollEscala.TabIndex = 1;
            this.hScrollEscala.UseWaitCursor = true;
            this.hScrollEscala.Scroll += new System.EventHandler(this.hScrollEscala_Scroll);
            // 
            // grbRotacion
            // 
            this.grbRotacion.Controls.Add(this.btnRotarIzquierda);
            this.grbRotacion.Controls.Add(this.btnRotarDerecha);
            this.grbRotacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbRotacion.Location = new System.Drawing.Point(61, 554);
            this.grbRotacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbRotacion.Name = "grbRotacion";
            this.grbRotacion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbRotacion.Size = new System.Drawing.Size(384, 147);
            this.grbRotacion.TabIndex = 26;
            this.grbRotacion.TabStop = false;
            this.grbRotacion.Text = "Rotación";
            // 
            // btnRotarIzquierda
            // 
            this.btnRotarIzquierda.Location = new System.Drawing.Point(33, 47);
            this.btnRotarIzquierda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRotarIzquierda.Name = "btnRotarIzquierda";
            this.btnRotarIzquierda.Size = new System.Drawing.Size(136, 70);
            this.btnRotarIzquierda.TabIndex = 2;
            this.btnRotarIzquierda.Text = "Rotar Izquierda";
            this.btnRotarIzquierda.UseVisualStyleBackColor = true;
            this.btnRotarIzquierda.Click += new System.EventHandler(this.btnRotarIzquierda_Click);
            // 
            // btnRotarDerecha
            // 
            this.btnRotarDerecha.Location = new System.Drawing.Point(199, 47);
            this.btnRotarDerecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRotarDerecha.Name = "btnRotarDerecha";
            this.btnRotarDerecha.Size = new System.Drawing.Size(135, 70);
            this.btnRotarDerecha.TabIndex = 1;
            this.btnRotarDerecha.Text = "Rotar derecha";
            this.btnRotarDerecha.UseVisualStyleBackColor = true;
            this.btnRotarDerecha.Click += new System.EventHandler(this.btnRotarDerecha_Click);
            // 
            // grbTraslacion
            // 
            this.grbTraslacion.Controls.Add(this.btnTrasladar);
            this.grbTraslacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbTraslacion.Location = new System.Drawing.Point(59, 440);
            this.grbTraslacion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbTraslacion.Name = "grbTraslacion";
            this.grbTraslacion.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbTraslacion.Size = new System.Drawing.Size(384, 86);
            this.grbTraslacion.TabIndex = 25;
            this.grbTraslacion.TabStop = false;
            this.grbTraslacion.Text = "Traslación";
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Location = new System.Drawing.Point(132, 25);
            this.btnTrasladar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(129, 45);
            this.btnTrasladar.TabIndex = 0;
            this.btnTrasladar.Text = "Trasladar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            this.btnTrasladar.Click += new System.EventHandler(this.btnTrasladar_Click);
            // 
            // grbSalida
            // 
            this.grbSalida.Controls.Add(this.btnSalir);
            this.grbSalida.Controls.Add(this.btnResetear);
            this.grbSalida.Controls.Add(this.btnGraficar);
            this.grbSalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbSalida.Location = new System.Drawing.Point(61, 315);
            this.grbSalida.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbSalida.Name = "grbSalida";
            this.grbSalida.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grbSalida.Size = new System.Drawing.Size(384, 102);
            this.grbSalida.TabIndex = 23;
            this.grbSalida.TabStop = false;
            this.grbSalida.Text = "Salida";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(263, 40);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(112, 41);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnResetear
            // 
            this.btnResetear.Location = new System.Drawing.Point(138, 41);
            this.btnResetear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetear.Name = "btnResetear";
            this.btnResetear.Size = new System.Drawing.Size(119, 42);
            this.btnResetear.TabIndex = 1;
            this.btnResetear.Text = "Resetear";
            this.btnResetear.UseVisualStyleBackColor = true;
            this.btnResetear.Click += new System.EventHandler(this.btnResetear_Click);
            // 
            // btnGraficar
            // 
            this.btnGraficar.Location = new System.Drawing.Point(14, 42);
            this.btnGraficar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGraficar.Name = "btnGraficar";
            this.btnGraficar.Size = new System.Drawing.Size(114, 42);
            this.btnGraficar.TabIndex = 0;
            this.btnGraficar.Text = "Graficar";
            this.btnGraficar.UseVisualStyleBackColor = true;
            this.btnGraficar.Click += new System.EventHandler(this.btnGraficar_Click);
            // 
            // lbltitulo
            // 
            this.lbltitulo.AutoSize = true;
            this.lbltitulo.Font = new System.Drawing.Font("Times New Roman", 22F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitulo.Location = new System.Drawing.Point(60, 23);
            this.lbltitulo.Name = "lbltitulo";
            this.lbltitulo.Size = new System.Drawing.Size(360, 51);
            this.lbltitulo.TabIndex = 21;
            this.lbltitulo.Text = "Gema de 10 Lados";
            // 
            // fmrGema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1469, 898);
            this.Controls.Add(this.lblfigura);
            this.Controls.Add(this.grbGafico);
            this.Controls.Add(this.grbEntrada);
            this.Controls.Add(this.grbEscala);
            this.Controls.Add(this.grbRotacion);
            this.Controls.Add(this.grbTraslacion);
            this.Controls.Add(this.grbSalida);
            this.Controls.Add(this.lbltitulo);
            this.Name = "fmrGema";
            this.Text = "Gema de 10 Lados";
            this.Load += new System.EventHandler(this.fmrGema_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fmrGema_KeyDown);
            this.grbGafico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbEntrada.ResumeLayout(false);
            this.grbEntrada.PerformLayout();
            this.grbEscala.ResumeLayout(false);
            this.grbEscala.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hScrollEscala)).EndInit();
            this.grbRotacion.ResumeLayout(false);
            this.grbTraslacion.ResumeLayout(false);
            this.grbSalida.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblfigura;
        private System.Windows.Forms.GroupBox grbGafico;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox grbEntrada;
        private System.Windows.Forms.TextBox txtSide;
        private System.Windows.Forms.Label lblLado;
        private System.Windows.Forms.GroupBox grbEscala;
        private System.Windows.Forms.TrackBar hScrollEscala;
        private System.Windows.Forms.GroupBox grbRotacion;
        private System.Windows.Forms.Button btnRotarIzquierda;
        private System.Windows.Forms.Button btnRotarDerecha;
        private System.Windows.Forms.GroupBox grbTraslacion;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.GroupBox grbSalida;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnResetear;
        private System.Windows.Forms.Button btnGraficar;
        private System.Windows.Forms.Label lbltitulo;
    }
}