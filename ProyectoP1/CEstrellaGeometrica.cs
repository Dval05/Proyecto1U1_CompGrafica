using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoP1
{
    internal class CEstrellaGeometrica
    {
        private float mSide; // Lado del polígono de 16 lados
        private const float startAngle = 45f; // Ángulo de inicio para un polígono de 16 lados (360/16/2)
        private Graphics mGraph;
        private Pen mPen;
        private const float SF = 1; // Factor de escalamiento

        public CEstrellaGeometrica()
        {
            mSide = 0.0f;
        }

        public bool ReadData(TextBox txtSide)
        {
            bool respuesta = true;
            try
            {
                mSide = float.Parse(txtSide.Text);
                if (mSide <= 0.0f)
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
            mSide = 0.0f;
            txtSide.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();

        }

        
        // Dibuja líneas conectando los 8 puntos en el orden especificado para formar la estrella
        private void DibujarEstrellaConOrden(Graphics g, Pen pen, PointF[] vertices)
        {
            // Orden de conexión de los vértices para la estrella de 8 puntas
            int[] orden = { 0, 2, 4, 6, 0, 3 , 1,4,7,1,6,3,5,7,2,5,0};

            for (int i = 0; i < orden.Length - 1; i++)
            {
                g.DrawLine(pen, vertices[orden[i]], vertices[orden[i + 1]]);
            }
        }

        // Reemplaza la sección correspondiente en DibujarEstrella:
        public void DibujarEstrella(PictureBox picCanvas, CTransformation transform)
        {
            if (mSide <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor válido para el lado del polígono.");
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
                g.Clear(Color.White);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                // Guardar estado antes de aplicar transformaciones
                GraphicsState state = g.Save();

                if (transform != null)
                {
                    transform.ApplyTransforms(g);
                }

                mPen = new Pen(Color.White, 0);

                // Dibujo del políg ono regular de 8 lados
                PointF[] vertices = new PointF[8];
                float radio = mSide / ((float)Math.Sin(Math.PI / 8));
                float offsetX = picCanvas.Width / 2;
                float offsetY = picCanvas.Height / 2;

                for (int i = 0; i < 8; i++)
                {
                    float angle = (startAngle + i * 45f) * (float)Math.PI / 180.0f;
                    float x = radio * (float)Math.Cos(angle);
                    float y = radio * (float)Math.Sin(angle);

                    if (transform == null)
                    {
                        x += offsetX;
                        y += offsetY;
                    }
                    vertices[i] = new PointF(x, y);
                }

                g.DrawPolygon(mPen, vertices);

                // Dibuja la estrella conectando los vértices en el orden especificado
                using (Pen estrellaPen = new Pen(Color.Blue, 2))
                {
                    DibujarEstrellaConOrden(g, estrellaPen, vertices);
                }

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
