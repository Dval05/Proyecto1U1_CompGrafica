using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoP1
{
    internal class CHexagonoConcentrico
    {
        // CONSTANTES DE DISEÑO
        private const int NUM_HEXAGONOS_PRINCIPALES = 6;
        private const int NUM_NIVELES_CONCENTRICOS = 5;
        private const int NUM_VERTICES_HEXAGONO = 6;
        private const float FACTOR_ESCALA_VISUAL = 0.6f; // Para ajustar al tamaño del canvas
        private const float RADIO_NIVEL_FACTOR = 0.2f; // Factor de radio para cada nivel
        private const float SF = 1; // Factor de escalamiento

        private float mRadioCm; // Radio en centímetros
        private Pen mPen;

        public CHexagonoConcentrico()
        {
            mRadioCm = 0.0f;
        }

        public bool ReadData(TextBox txtSide)
        {
            bool respuesta = true;
            try
            {
                mRadioCm = float.Parse(txtSide.Text);
                if (mRadioCm <= 0.0f)
                {
                    throw new Exception();
                }
            }
            catch
            {
                respuesta = false;
                MessageBox.Show("Ingrese Datos válidos...!", "ERROR!");
            }

            return respuesta;
        }

        public void InitializeData(TextBox txtSide, PictureBox picCanvas)
        {
            mRadioCm = 0.0f;
            txtSide.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
        }

        /// <summary>
        /// Dibuja la flor hexagonal completa (6 hexágonos con múltiples niveles concéntricos cada uno)
        /// </summary>
        private void DibujarFlorHexagonal(Graphics g, Pen pen, PointF centro, float radio)
        {
            // Puntos de los 6 hexágonos principales alrededor del centro
            PointF[] mainHexPoints = new PointF[NUM_HEXAGONOS_PRINCIPALES];

            // Calcular los 6 puntos principales (centros de los hexágonos pequeños)
            // Ángulo inicial: -0.523599 radianes (-30°)
            float tethaAdd = 0.0f;

            for (int i = 0; i < NUM_HEXAGONOS_PRINCIPALES; i++)
            {
                float tetha = (float)((i * 1.0472) + tethaAdd - 0.523599); // 1.0472 rad = 60°
                mainHexPoints[i] = new PointF(
                    centro.X + radio * (float)Math.Cos(tetha),
                    centro.Y + radio * (float)Math.Sin(tetha)
                );
            }

            // Dibujar líneas desde el centro a cada punto principal
            for (int i = 0; i < NUM_HEXAGONOS_PRINCIPALES; i++)
            {
                g.DrawLine(pen, centro, mainHexPoints[i]);
            }

            // Para cada uno de los 6 hexágonos principales
            for (int j = 0; j < NUM_HEXAGONOS_PRINCIPALES; j++)
            {
                // Dibujar 5 niveles de hexágonos concéntricos
                for (int k = 0; k < NUM_NIVELES_CONCENTRICOS; k++)
                {
                    PointF[] hexPoints = new PointF[NUM_VERTICES_HEXAGONO];

                    // Calcular los 6 vértices del hexágono en este nivel
                    for (int i = 0; i < NUM_VERTICES_HEXAGONO; i++)
                    {
                        // Ángulo base: -1.5708 rad (-90°) + offset del sector j
                        float tetha = (float)((i * 1.0472) + tethaAdd - 1.5708 + (1.0472 * j));

                        // Radio del nivel actual (escala de 0.2 por cada nivel)
                        float currentRadius = radio * RADIO_NIVEL_FACTOR * (k + 1);

                        hexPoints[i] = new PointF(
                            mainHexPoints[j].X + currentRadius * (float)Math.Cos(tetha),
                            mainHexPoints[j].Y + currentRadius * (float)Math.Sin(tetha)
                        );
                    }

                    // Dibujar las 4 primeras aristas del hexágono
                    // (las últimas 2 se comparten con hexágonos vecinos)
                    for (int i = 0; i < 4; i++)
                    {
                        g.DrawLine(pen, hexPoints[i], hexPoints[i + 1]);
                    }
                }
            }
        }

        public void DibujarHexagono(PictureBox picCanvas, CTransformation transform)
        {
            if (mRadioCm <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el radio.");
                return;
            }

            // Asegurar que haya un Bitmap persistente en el PictureBox
            if (picCanvas.Image == null || picCanvas.Image.Width != picCanvas.Width || picCanvas.Image.Height != picCanvas.Height)
            {
                picCanvas.Image?.Dispose();
                picCanvas.Image = new Bitmap(Math.Max(1, picCanvas.Width), Math.Max(1, picCanvas.Height));
            }

            using (Graphics g = Graphics.FromImage(picCanvas.Image))
            {
                g.Clear(Color.FromArgb(20, 30, 50)); // Fondo azul oscuro
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Guardar estado antes de aplicar transformaciones
                GraphicsState state = g.Save();

                if (transform != null)
                {
                    transform.ApplyTransforms(g);
                }

                // Conversión de cm a píxeles
                float dpi = g.DpiX;
                float pixelesPorCm = dpi / 2.54f;
                float radio = mRadioCm * pixelesPorCm * FACTOR_ESCALA_VISUAL;

                // Calcular el centro
                PointF centro = (transform == null)
                    ? new PointF(picCanvas.Width / 2.0f, picCanvas.Height / 2.0f)
                    : new PointF(0, 0);

                // Dibujar la flor hexagonal
                mPen = new Pen(Color.White, 2.5f);
                DibujarFlorHexagonal(g, mPen, centro, radio);

                g.Restore(state);
            }
            picCanvas.Refresh();
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}
