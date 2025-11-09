using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoP1
{
    public partial class frmPoligonoEstrellado : Form
    {
        // --- 1. VARIABLES DE ESTADO ---
        private CPoligonoEstrellado objPoligono = new CPoligonoEstrellado();
        private CTransformation obTransformation = new CTransformation();

        private enum TransformMode { None, Translate }
        private TransformMode currentMode = TransformMode.None;

        // --- 2. CONSTRUCTOR ---
        public frmPoligonoEstrellado()
        {
            InitializeComponent();
            this.picCanvas.MouseWheel += new MouseEventHandler(this.picCanvas_MouseWheel);
            this.KeyPreview = true;
        }

        // --- 3. BOTÓN PRINCIPAL ---
        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!objPoligono.ReadData(txtSide))
                return;

            // (1) Resetear el estado
            obTransformation.Reset();

            // (2) Establecer el pivote en el centro del PictureBox
            obTransformation.Pivot = new PointF(picCanvas.Width / 2.0f, picCanvas.Height / 2.0f);

            currentMode = TransformMode.None;
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;
            RedrawFigure();
        }

        // --- 4. MÉTODO DE DIBUJO CENTRAL ---
        private void RedrawFigure()
        {
            // Delegamos el dibujo al objeto y le pasamos la transformación actual.
            // CPoligonoEstrellado ahora dibuja sobre picCanvas.Image para que el resultado sea persistente.
            objPoligono.DibujarPoligono(picCanvas, obTransformation);
        }

        // --- 5. BOTONES DE MODO Y ACCIÓN ---
        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            currentMode = TransformMode.Translate;
            picCanvas.Focus();
        }

        private void btnRotarIzquierda_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(-5);
            RedrawFigure();
        }

        private void btnRotarDerecha_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(5);
            RedrawFigure();
        }

        // --- 6. MANEJADORES DE INPUT ---
        private void frmPoligonoEstrellado_KeyDown(object sender, KeyEventArgs e)
        {
            if (currentMode != TransformMode.Translate) return;

            bool needsRedraw = false;
            switch (currentMode)
            {
                case TransformMode.Translate:
                    if (e.KeyCode == Keys.Left) { obTransformation.Translate(-5, 0); needsRedraw = true; }
                    else if (e.KeyCode == Keys.Right) { obTransformation.Translate(5, 0); needsRedraw = true; }
                    else if (e.KeyCode == Keys.Up) { obTransformation.Translate(0, -5); needsRedraw = true; }
                    else if (e.KeyCode == Keys.Down) { obTransformation.Translate(0, 5); needsRedraw = true; }
                    break;
            }
            if (needsRedraw)
            {
                RedrawFigure();
                e.Handled = true;
            }
        }

        private void picCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                obTransformation.AdjustScale(1.1f);
            else if (e.Delta < 0)
                obTransformation.AdjustScale(1 / 1.1f);

            int newScrollValue = (int)(obTransformation.Scale * 100);
            if (newScrollValue < hScrollEscala.Minimum) newScrollValue = hScrollEscala.Minimum;
            if (newScrollValue > hScrollEscala.Maximum) newScrollValue = hScrollEscala.Maximum;

            obTransformation.SetScale(newScrollValue / 100.0f);
            hScrollEscala.Value = newScrollValue;

            RedrawFigure();
        }

        private void hScrollEscala_Scroll(object sender, EventArgs e)
        {
            float newScale = hScrollEscala.Value / 100.0f;
            obTransformation.SetScale(newScale);
            RedrawFigure();
        }

        // --- 7. BOTONES DE UTILIDAD ---
        private void btnResetear_Click(object sender, EventArgs e)
        {
            txtSide.Text = string.Empty;
            obTransformation.Reset();
            currentMode = TransformMode.None;
            hScrollEscala.Value = 100;

            if (this.picCanvas != null)
            {
                this.picCanvas.Image?.Dispose();
                var bmp = new Bitmap(Math.Max(1, this.picCanvas.Width), Math.Max(1, this.picCanvas.Height));
                using (var g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                }
                this.picCanvas.Image = bmp;
            }
            objPoligono.InitializeData(txtSide,picCanvas);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            objPoligono.CloseForm(this);
        }

        private void frmPoligonoEstrellado_Load(object sender, EventArgs e)
        {
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200; // or any value >= 100
            hScrollEscala.Value = 100;
        }


    }
}
