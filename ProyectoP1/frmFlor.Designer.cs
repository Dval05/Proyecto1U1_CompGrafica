namespace ProyectoP1
{
    partial class frmFlor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRotarDerecha = new System.Windows.Forms.Button();
            this.btnRotarIzquierda = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnTrasladar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.hScrollEscala = new System.Windows.Forms.TrackBar();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hScrollEscala)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picCanvas);
            this.groupBox1.Location = new System.Drawing.Point(309, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 516);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grafico";
            // 
            // picCanvas
            // 
            this.picCanvas.Location = new System.Drawing.Point(6, 22);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(565, 488);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRotarDerecha);
            this.groupBox2.Controls.Add(this.btnRotarIzquierda);
            this.groupBox2.Location = new System.Drawing.Point(19, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(258, 104);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotación";
            // 
            // btnRotarDerecha
            // 
            this.btnRotarDerecha.Location = new System.Drawing.Point(128, 32);
            this.btnRotarDerecha.Name = "btnRotarDerecha";
            this.btnRotarDerecha.Size = new System.Drawing.Size(75, 57);
            this.btnRotarDerecha.TabIndex = 1;
            this.btnRotarDerecha.Text = "Rotar Derecha";
            this.btnRotarDerecha.UseVisualStyleBackColor = true;
            // 
            // btnRotarIzquierda
            // 
            this.btnRotarIzquierda.Location = new System.Drawing.Point(47, 32);
            this.btnRotarIzquierda.Name = "btnRotarIzquierda";
            this.btnRotarIzquierda.Size = new System.Drawing.Size(75, 57);
            this.btnRotarIzquierda.TabIndex = 0;
            this.btnRotarIzquierda.Text = "Rotar Izquierda";
            this.btnRotarIzquierda.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnTrasladar);
            this.groupBox3.Location = new System.Drawing.Point(19, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 100);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Traslación";
            // 
            // btnTrasladar
            // 
            this.btnTrasladar.Location = new System.Drawing.Point(91, 43);
            this.btnTrasladar.Name = "btnTrasladar";
            this.btnTrasladar.Size = new System.Drawing.Size(84, 36);
            this.btnTrasladar.TabIndex = 5;
            this.btnTrasladar.Text = "Trasladar";
            this.btnTrasladar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Flor Geométrica";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 21F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 41);
            this.label2.TabIndex = 3;
            this.label2.Text = "Figura 2";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.hScrollEscala);
            this.groupBox4.Location = new System.Drawing.Point(19, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(258, 100);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Escala";
            // 
            // hScrollEscala
            // 
            this.hScrollEscala.Location = new System.Drawing.Point(10, 30);
            this.hScrollEscala.Name = "hScrollEscala";
            this.hScrollEscala.Size = new System.Drawing.Size(242, 56);
            this.hScrollEscala.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(100, 475);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(94, 34);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // frmFlor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 550);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFlor";
            this.Text = "frmFlor";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hScrollEscala)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRotarIzquierda;
        private System.Windows.Forms.Button btnRotarDerecha;
        private System.Windows.Forms.Button btnTrasladar;
        private System.Windows.Forms.TrackBar hScrollEscala;
        private System.Windows.Forms.PictureBox picCanvas;
    }
}