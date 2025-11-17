using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoP1
{
    public partial class frmEstrellaGeometrica : Form
    {

        private CEstrellaGeometrica objEstrella = new CEstrellaGeometrica();
        private CTransformation obTransformation = new CTransformation();

        private enum TransformMode { None, Translate }
        private TransformMode currentMode = TransformMode.None;

        public frmEstrellaGeometrica()
        {
            InitializeComponent();
            this.picCanvas.MouseWheel += new MouseEventHandler(this.picCanvas_MouseWheel);
            this.KeyPreview = true;
        }      

        private void btnGraficar_Click(object sender, EventArgs e)
        {
            if (!objEstrella.ReadData(txtSide))
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

        private void RedrawFigure()
        {
            // Delegamos el dibujo al objeto y le pasamos la transformación actual.
            // CPoligonoEstrellado ahora dibuja sobre picCanvas.Image para que el resultado sea persistente.
            objEstrella.DibujarEstrella(picCanvas, obTransformation);
        }

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

        private void frmEstrellaGeometrica_KeyDown(object sender, KeyEventArgs e)
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
            objEstrella.InitializeData(txtSide, picCanvas);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            objEstrella.CloseForm(this);
        }

        private void frmEstrellaGeometrica_Load(object sender, EventArgs e)
        {
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200; // or any value >= 100
            hScrollEscala.Value = 100;
        }

        
    }
}
