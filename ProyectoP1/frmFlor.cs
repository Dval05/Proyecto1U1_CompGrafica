using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoP1
{
    public partial class frmFlor : Form
    {
        private CFlor cFigura6 = new CFlor();
        private CTransformation obTransformation = new CTransformation();

        // Constantes para interacción simple
        private const float INCREMENTO_TRASLACION = 5.0f; // píxeles por pulsación de flecha
        private const float ANGULO_ROTACION = 15.0f;    // grados por pulsación

        // Modo para habilitar movimiento con flechas tras pulsar btnTrasladar
        private bool modoTraslacion = false;

        public frmFlor()
        {
            InitializeComponent();

            // Asegurar que el formulario reciba teclas antes que los controles
            this.KeyPreview = true;
            this.KeyDown += FrmFlor_KeyDown;

            // Eventos mínimos solicitados
            if (picCanvas != null)
            {
                // Permitir que picCanvas reciba foco en tiempo de ejecución
                picCanvas.TabStop = true;
                picCanvas.Paint += picCanvas_Paint;

                // IMPORTANTE: permitir que las flechas sean tratadas como input keys
                picCanvas.PreviewKeyDown += Control_PreviewKeyDown;
            }

            if (hScrollEscala != null)
            {
                // Configuración TrackBar (100 = 1.0)
                hScrollEscala.Minimum = 10;
                hScrollEscala.Maximum = 200;
                hScrollEscala.Value = 100;
                hScrollEscala.TickFrequency = 10;
                hScrollEscala.SmallChange = 5;
                hScrollEscala.LargeChange = 10;
                hScrollEscala.ValueChanged += hScrollEscala_ValueChanged;

                // IMPORTANTE: evitar que el TrackBar consuma las flechas
                hScrollEscala.PreviewKeyDown += Control_PreviewKeyDown;
            }

            if (btnTrasladar != null) btnTrasladar.Click += btnTrasladar_Click;
            if (btnRotarDerecha != null) btnRotarDerecha.Click += btnRotarDerecha_Click;
            if (btnRotarIzquierda != null) btnRotarIzquierda.Click += btnRotarIzquierda_Click;
            if (btnSalir != null) btnSalir.Click += btnSalir_Click;

            // Inicializar transformaciones
            obTransformation.SetScale((hScrollEscala != null) ? (hScrollEscala.Value / 100f) : 1f);
        }

        // Marca las flechas como teclas de entrada para que lleguen a KeyDown del formulario
        private void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.IsInputKey = true;
            }
        }

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (picCanvas == null) return;

            int w = Math.Max(1, picCanvas.Width);
            int h = Math.Max(1, picCanvas.Height);

            // Crear bitmap off-screen y dibujar la figura en coordenadas centradas (0,0)
            using (Bitmap bmp = new Bitmap(w, h))
            using (Graphics gOff = Graphics.FromImage(bmp))
            {
                gOff.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Centrar el sistema de coordenadas en el centro del PictureBox
                gOff.TranslateTransform(w / 2f, h / 2f);

                // Aplicar pivot relativo al centro y luego transformaciones del usuario
                obTransformation.Pivot = new PointF(0f, 0f);
                obTransformation.ApplyTransforms(gOff);

                // Dibujar la figura con coordenadas centradas
                CFlor.DibujarCirculo(gOff, w, h);

                // Preparar el contexto visible y dibujar el bitmap completo
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.DrawImage(bmp, 0, 0, w, h);
            }
        }

        // btnTrasladar alterna el modo traslación: cuando está activo, las flechas mueven la figura
        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            modoTraslacion = !modoTraslacion;
            if (btnTrasladar != null)
                btnTrasladar.Text = modoTraslacion ? "Trasladar (ON)" : "Trasladar";

            // Asegurar que el formulario (y picCanvas) reciban el foco:
            try
            {
                this.ActiveControl = null;
                this.Activate();
                this.Focus();
                picCanvas?.Focus();
            }
            catch { /* no romper si Focus/Activate falla */ }
        }

        private void btnRotarDerecha_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(ANGULO_ROTACION);
            picCanvas?.Invalidate();
        }

        private void btnRotarIzquierda_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(-ANGULO_ROTACION);
            picCanvas?.Invalidate();
        }

        private void hScrollEscala_ValueChanged(object sender, EventArgs e)
        {
            if (hScrollEscala == null || hScrollEscala.Maximum == 0) return;
            float newScale = hScrollEscala.Value / 100f;
            obTransformation.SetScale(newScale);
            picCanvas?.Invalidate();
        }

        // Manejar teclas: flechas mueven sólo si modoTraslacion == true; ESC desactiva el modo.
        private void FrmFlor_KeyDown(object sender, KeyEventArgs e)
        {
            bool cambiado = false;

            if (modoTraslacion)
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        obTransformation.Translate(-INCREMENTO_TRASLACION, 0f);
                        cambiado = true;
                        break;
                    case Keys.Right:
                        obTransformation.Translate(INCREMENTO_TRASLACION, 0f);
                        cambiado = true;
                        break;
                    case Keys.Up:
                        obTransformation.Translate(0f, -INCREMENTO_TRASLACION);
                        cambiado = true;
                        break;
                    case Keys.Down:
                        obTransformation.Translate(0f, INCREMENTO_TRASLACION);
                        cambiado = true;
                        break;
                    case Keys.Escape:
                        // Salir del modo traslación
                        modoTraslacion = false;
                        if (btnTrasladar != null) btnTrasladar.Text = "Trasladar";
                        cambiado = false;
                        break;
                }
            }

            if (cambiado)
            {
                e.Handled = true;
                e.SuppressKeyPress = true; // evita el beep del sistema o navegación de controles
                picCanvas?.Invalidate();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}