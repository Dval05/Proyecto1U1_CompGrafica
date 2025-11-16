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
    internal class CGema
    {
        // CONSTANTES DE DISE�O
        private const int NUM_VERTICES_DECAGONO = 10;
        private const float ANGULO_INICIAL = -90f; // V�rtice apuntando hacia arriba
        private const float ANGULO_ENTRE_VERTICES = 36f; // 360/10
        private const float FACTOR_DECAGONO_INTERNO = 0.92f; // 92% del exterior
        private const float FACTOR_CIRCULO_CENTRAL = 0.09f; // 9% del radio total
        private const float ALTURA_TRIANGULO_FACTOR = 0.1f; // Factor para la altura del tri�ngulo (3% del radio)
        private const float SF = 1; // Factor de escalamiento

        private float mAltura; // Altura de la gema
        private Graphics mGraph;
        private Pen mPen;

        public CGema()
        {
            mAltura = 0.0f;
        }

        public bool ReadData(TextBox txtSide)
        {
            bool respuesta = true;
            try
            {
                mAltura = float.Parse(txtSide.Text);
                if (mAltura <= 0.0f)
                {
                    throw new Exception();
                }
            }
            catch
            {
                respuesta = false;
                MessageBox.Show("Ingrese Datos v�lidos...!", "ERROR!");
            }

            return respuesta;
        }

        public void InitializeData(TextBox txtSide, PictureBox picCanvas)
        {
            mAltura = 0.0f;
            txtSide.Text = "";
            txtSide.Focus();
            picCanvas.Refresh();
        }

        // M�TODO GENERALIZADO: Calcula los v�rtices de un dec�gono con un factor de radio
        private PointF[] CalcularDecagono(float factorRadio)
        {
            PointF[] vertices = new PointF[NUM_VERTICES_DECAGONO];
            float radio = (mAltura / 2) * factorRadio;

            for (int i = 0; i < NUM_VERTICES_DECAGONO; i++)
            {
                float angle = (ANGULO_INICIAL + i * ANGULO_ENTRE_VERTICES) * (float)Math.PI / 180.0f;
                vertices[i] = new PointF(
                    radio * (float)Math.Cos(angle),
                    radio * (float)Math.Sin(angle)
                );
            }

            return vertices;
        }

        // PASO 1: Calcula los v�rtices del dec�gono exterior (usa factor 1.0)
        private PointF[] CalcularDecagonoExterior()
        {
            return CalcularDecagono(1.0f);
        }

        // PASO 2: Calcula los v�rtices del dec�gono interno (usa factor 0.92)
        private PointF[] CalcularDecagonoInterno()
        {
            return CalcularDecagono(FACTOR_DECAGONO_INTERNO);
        }

        // M�TODO AUXILIAR: Aplica offset y escala a un array de puntos
        private void AplicarOffsetYEscala(PointF[] vertices, PictureBox picCanvas, CTransformation transform)
        {
            if (transform == null)
            {
                // Sin transformaci�n: centrar en el canvas
                float offsetX = picCanvas.Width / 2;
                float offsetY = picCanvas.Height / 2;

                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i].X = SF * vertices[i].X + offsetX;
                    vertices[i].Y = SF * vertices[i].Y + offsetY;
                }
            }
            else
            {
                // Con transformaci�n: mantener en origen
                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i].X = SF * vertices[i].X;
                    vertices[i].Y = SF * vertices[i].Y;
                }
            }
        }

        // PASO 3: Dibuja l�neas conectando los v�rtices correspondientes entre dec�gonos
        private void DibujarConexionesDecagonos(Graphics g, Pen pen, PointF[] decagonoExt, PointF[] decagonoInt)
        {
            for (int i = 0; i < NUM_VERTICES_DECAGONO; i++)
            {
                g.DrawLine(pen, decagonoExt[i], decagonoInt[i]);
            }
        }

        // PASO 4: Dibuja el c�rculo central
        private void DibujarCirculoCentral(Graphics g, Pen pen, PointF centro, CTransformation transform)
        {
            float radioCentral = (mAltura / 2) * FACTOR_CIRCULO_CENTRAL;
            
            RectangleF rect;
            
            if (transform == null)
            {
                rect = new RectangleF(
                    centro.X - radioCentral,
                    centro.Y - radioCentral,
                    radioCentral * 2,
                    radioCentral * 2
                );
            }
            else
            {
                rect = new RectangleF(
                    -radioCentral,
                    -radioCentral,
                    radioCentral * 2,
                    radioCentral * 2
                );
            }
            
            g.DrawEllipse(pen, rect);
        }

        // PASO 3.5: Dibuja tri�ngulos peque�os en el punto medio de cada lado del dec�gono interno
        private void DibujarTriangulosDecagonoInterno(Graphics g, Pen pen, PointF[] decagonoInt)
        {
            float alturaTriangulo = (mAltura / 2) * ALTURA_TRIANGULO_FACTOR;

            for (int i = 0; i < NUM_VERTICES_DECAGONO; i++)
            {
                // Obtener el lado actual y el siguiente v�rtice
                PointF p1 = decagonoInt[i];
                PointF p2 = decagonoInt[(i + 1) % NUM_VERTICES_DECAGONO];

                // Calcular el punto medio del lado
                PointF puntoMedio = new PointF(
                    (p1.X + p2.X) / 2,
                    (p1.Y + p2.Y) / 2
                );

                // Calcular el vector del lado
                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;

                // Calcular la perpendicular hacia afuera (normal)
                // Giramos 90 grados a la derecha y normalizamos
                float longitud = (float)Math.Sqrt(dx * dx + dy * dy);
                float normalX = -dy / longitud;
                float normalY = dx / longitud;

                // El �pice del tri�ngulo est� hacia afuera del dec�gono
                PointF apice = new PointF(
                    puntoMedio.X + normalX * alturaTriangulo,
                    puntoMedio.Y + normalY * alturaTriangulo
                );

                // Dibujar el tri�ngulo
                PointF[] triangulo = new PointF[] { p1, apice, p2 };
                g.DrawPolygon(pen, triangulo);
            }
        }

        public void DibujarGema(PictureBox picCanvas, CTransformation transform)
        {
            if (mAltura <= 0)
            {
                MessageBox.Show("Por favor, ingrese un valor v�lido para la altura de la gema.");
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

                // Calcular el centro para el c�rculo
                PointF centro = (transform == null) 
                    ? new PointF(picCanvas.Width / 2, picCanvas.Height / 2) 
                    : new PointF(0, 0);

                // PASO 1: Calcular y aplicar offset al dec�gono exterior
                PointF[] decagono = CalcularDecagonoExterior();
                AplicarOffsetYEscala(decagono, picCanvas, transform);

                // PASO 2: Calcular y aplicar offset al dec�gono interno
                PointF[] decagonoInterno = CalcularDecagonoInterno();
                AplicarOffsetYEscala(decagonoInterno, picCanvas, transform);

                // Dibujar los dec�gonos
                mPen = new Pen(Color.Black, 2);
                g.DrawPolygon(mPen, decagono);
                g.DrawPolygon(mPen, decagonoInterno);

                // PASO 3: Dibujar las l�neas de conexi�n entre los v�rtices
                DibujarConexionesDecagonos(g, mPen, decagono, decagonoInterno);

                // PASO 3.5: Dibujar tri�ngulos en cada lado del dec�gono interno
                DibujarTriangulosDecagonoInterno(g, mPen, decagonoInterno);

                // PASO 4: Dibujar el c�rculo central
                DibujarCirculoCentral(g, mPen, centro, transform);

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
