using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProyectoP1
{
    public partial class frmPentagonoEstrellado : Form
    {
        private CPentagonoEstrellado dibujo = new CPentagonoEstrellado();
        private CTransformation obTransformation = new CTransformation();

        // Constantes de interacción
        private const float INCREMENTO_TRASLACION = 5.0f;
        private const float ANGULO_ROTACION = 15.0f;

        // Modo para habilitar movimiento con flechas tras pulsar btnTrasladar
        private bool modoTraslacion = false;

        public frmPentagonoEstrellado()
        {
            InitializeComponent();

            // Suscribir el evento Paint del PictureBox (por si no está en el diseñador)
            this.picCanvas.Paint += this.picCanvas_Paint;

            // AÑADIDO: permitir que picCanvas reciba foco y que las flechas sean input keys
            this.picCanvas.TabStop = true;
            this.picCanvas.PreviewKeyDown += Control_PreviewKeyDown;

            // Inicializar transformaciones
            obTransformation.Pivot = new PointF(0f, 0f);
            obTransformation.SetScale(1.0f);

            // Reemplazar el bloque de configuración de hScrollEscala en el constructor por:
            hScrollEscala.Minimum = 0;
            hScrollEscala.Maximum = 200;
            hScrollEscala.Value = 100;
            hScrollEscala.TickFrequency = 10;
            hScrollEscala.SmallChange = 1;
            hScrollEscala.LargeChange = 10;
            hScrollEscala.ValueChanged += hScrollEscala_ValueChanged;

            // AÑADIDO: TrackBar puede tener foco y consumir flechas -> garantizar PreviewKeyDown
            hScrollEscala.PreviewKeyDown += Control_PreviewKeyDown;

            // Suscribir botones
            btnTrasladar.Click += btnTrasladar_Click;
            btnRotarDerecha.Click += btnRotarDerecha_Click;
            btnRotarIzquierda.Click += btnRotarIzquierda_Click;
            btnResetear.Click += btnResetear_Click;
            btnSalir.Click += btnSalir_Click;

            // Permitir captura de teclas en el formulario
            this.KeyPreview = true;
            this.KeyDown += FrmPentagonoEstrellado_KeyDown;
        }

        // NUEVO: marcar flechas como teclas de entrada para que lleguen a KeyDown
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
            float radioBase;
            if (!float.TryParse(txtRadio.Text, out radioBase) || radioBase <= 0)
            {
                return;
            }

            int w = picCanvas.Width;
            int h = picCanvas.Height;

            // Calcular el radio más grande (radio7 = radioBase * 6.8)
            float radioMaximo = radioBase * 6.8f;

            // Reemplaza estas líneas (cálculo de factorEscalaAuto)
            float tamañoDisponible = Math.Min(w, h) * 0.4f;
            float factorEscalaAuto = Math.Min(1f, tamañoDisponible / radioMaximo);
            // Ya no necesitas la comprobación: if (factorEscalaAuto <= 0) factorEscalaAuto = 1f;
            if (factorEscalaAuto <= 0) factorEscalaAuto = 1f;

            // Crear bitmap del tamaño del PictureBox
            using (Bitmap bmp = new Bitmap(Math.Max(1, w), Math.Max(1, h)))
            using (Graphics gOff = Graphics.FromImage(bmp))
            {
                gOff.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Centrar y escalar en el bitmap ANTES de dibujar
                gOff.TranslateTransform(w / 2f, h / 2f);

                // Aplicar una escala automática para que quepa (esto mantiene coordenadas centradas en 0,0)
                gOff.ScaleTransform(factorEscalaAuto, factorEscalaAuto);

                // Aplicar transformaciones del usuario (pivot relativo a 0,0 ya que centramos antes)
                obTransformation.ApplyTransforms(gOff);

                // Dibujar la estrella (ahora dibuja en 0,0 sin transformaciones internas)
                dibujo.DibujarEstrella(gOff, w, h, radioBase);

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // Dibujar el bitmap en (0,0) para que ocupe todo el PictureBox
                e.Graphics.DrawImage(bmp, 0, 0, w, h);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            picCanvas.Invalidate();
        }

        private void btnTrasladar_Click(object sender, EventArgs e)
        {
            // Toggle del modo traslación: al activar, las flechas moverán la figura
            modoTraslacion = !modoTraslacion;

            // Visual feedback: cambiar texto del botón
            btnTrasladar.Text = modoTraslacion ? "Trasladar (ON)" : "Trasladar";

            // Asegurar que el formulario reciba teclas y picCanvas tenga foco
            this.ActiveControl = null;
            this.Focus();
            picCanvas.Focus();

            picCanvas.Invalidate();
        }

        private void btnRotarDerecha_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(ANGULO_ROTACION);
            picCanvas.Invalidate();
        }

        private void btnRotarIzquierda_Click(object sender, EventArgs e)
        {
            obTransformation.Rotate(-ANGULO_ROTACION);
            picCanvas.Invalidate();
        }

        private void btnResetear_Click(object sender, EventArgs e)
        {
            // Dentro de btnResetear_Click, añadir:
            txtRadio.Clear();
            picCanvas.Image = null;
            picCanvas.Invalidate();
            obTransformation.Reset();
            hScrollEscala.Value = 100;
            obTransformation.SetScale(1.0f);
            modoTraslacion = false;
            btnTrasladar.Text = "Trasladar";
            picCanvas.Invalidate();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hScrollEscala_ValueChanged(object sender, EventArgs e)
        {
            float scale = hScrollEscala.Value / 100f; // convertir a factor (100 => 1.0)
            // proteger contra 0 (aunque SetScale debe manejarlo)
            if (scale <= 0) scale = 0.01f;
            obTransformation.SetScale(scale);
            picCanvas.Invalidate();
        }

        private void FrmPentagonoEstrellado_KeyDown(object sender, KeyEventArgs e)
        {
            bool cambiado = false;

            // Solo permitir traslación con flechas si modoTraslacion está activo
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
                        // Salir del modo traslación con ESC
                        modoTraslacion = false;
                        btnTrasladar.Text = "Trasladar";
                        cambiado = false;
                        break;
                }
            }

            // Otras teclas (rotación/escala) siguen funcionando siempre
            switch (e.KeyCode)
            {
                case Keys.Add:
                case Keys.Oemplus:
                    obTransformation.AdjustScale(1.1f);
                    hScrollEscala.Value = Math.Min(hScrollEscala.Maximum, (int)(obTransformation.Scale * 100));
                    cambiado = true;
                    break;
                case Keys.Subtract:
                case Keys.OemMinus:
                    obTransformation.AdjustScale(1f / 1.1f);
                    hScrollEscala.Value = Math.Max(hScrollEscala.Minimum, (int)(obTransformation.Scale * 100));
                    cambiado = true;
                    break;
                case Keys.R:
                    obTransformation.Rotate(ANGULO_ROTACION);
                    cambiado = true;
                    break;
                case Keys.L:
                    obTransformation.Rotate(-ANGULO_ROTACION);
                    cambiado = true;
                    break;
            }

            if (cambiado)
            {
                e.Handled = true;
                picCanvas.Invalidate();
            }
        }
    }
}