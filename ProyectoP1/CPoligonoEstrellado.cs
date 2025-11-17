using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoP1
{
    public class CPoligonoEstrellado
    {
        private float mSide; // Lado del polígono de 16 lados
        private const float startAngle = 22.5f; // Ángulo de inicio para un polígono de 16 lados (360/16/2)
        private Graphics mGraph;        
        private Pen mPen;
        private const float SF = 1; // Factor de escalamiento

        public CPoligonoEstrellado()
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

        private PointF[] CalcularVertices()
        {
            PointF[] vertices = new PointF[16];
            float radio = mSide / (2 * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 16; i++)
            {
                float angle = (startAngle + i * 22.5f) * (float)Math.PI / 180.0f;
                vertices[i] = new PointF(radio * (float)Math.Cos(angle), radio * (float)Math.Sin(angle));
            }

            return vertices;
        }

        //Funcion que grafica el octogono estrellado 1 de color rojo
        private PointF[] CalcularEstrellaInterior()
        {
            PointF[] innerStar = new PointF[16]; // Octógono estrellado de 8 puntas

            float innerRadius = mSide / (2 * (float)Math.Sin(Math.PI / 16)); // Radio para que toque los bordes del polígono

            for (int i = 0; i < 8; i++)
            {
                float outerAngle = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;
                float innerAngle = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f; // Ángulo para los vértices interiores

                innerStar[i * 2] = new PointF(innerRadius * (float)Math.Cos(outerAngle), innerRadius * (float)Math.Sin(outerAngle));
                innerStar[i * 2 + 1] = new PointF(innerRadius * 0.8f * (float)Math.Cos(innerAngle), innerRadius * 0.8f * (float)Math.Sin(innerAngle)); // Vértices internos
            }

            return innerStar;
        }

        //Funcion que grafica el octogono estrellado 2 de color verde
        private PointF[] CalcularEstrellaInterior2()
        {
            PointF[] innerStar2 = new PointF[16];

            float innerRadius2 = mSide / (2 * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle2 = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;
                float innerAngle2 = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f;

                innerStar2[i * 2] = new PointF(innerRadius2 * (float)Math.Cos(outerAngle2), innerRadius2 * (float)Math.Sin(outerAngle2));
                innerStar2[i * 2 + 1] = new PointF(innerRadius2 * 0.7f * (float)Math.Cos(innerAngle2), innerRadius2 * 0.7f * (float)Math.Sin(innerAngle2)); // Vértices internos
            }

            return innerStar2;
        }

        //Funcion que grafica el octogono estrellado 3 de color amarillo
        private PointF[] CalcularEstrellaInterior3()
        {
            float rotationAngle = 22.5f;
            PointF[] innerStar4 = new PointF[16];

            float innerRadius4 = mSide / (3.5f * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle4 = (startAngle + i * 45.0f + rotationAngle) * (float)Math.PI / 180.0f;
                float innerAngle4 = (startAngle + i * 45.0f + 22.5f + rotationAngle) * (float)Math.PI / 180.0f;

                innerStar4[i * 2] = new PointF(innerRadius4 * (float)Math.Cos(outerAngle4), innerRadius4 * (float)Math.Sin(outerAngle4));
                innerStar4[i * 2 + 1] = new PointF(innerRadius4 * 0.8f * (float)Math.Cos(innerAngle4), innerRadius4 * 0.8f * (float)Math.Sin(innerAngle4));
            }

            return innerStar4;
        }

        //Funcion que grafica el octogono estrellado 4 de color celeste
        private PointF[] CalcularEstrellaInterior4()
        {
            PointF[] innerStar5 = new PointF[16];

            float innerRadius5 = mSide / (4.5f * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle5 = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;
                float innerAngle5 = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f;

                innerStar5[i * 2] = new PointF(innerRadius5 * (float)Math.Cos(outerAngle5), innerRadius5 * (float)Math.Sin(outerAngle5));
                innerStar5[i * 2 + 1] = new PointF(innerRadius5 * 0.6f * (float)Math.Cos(innerAngle5), innerRadius5 * 0.6f * (float)Math.Sin(innerAngle5));
            }

            return innerStar5;
        }

        //Funcion que grafica el octogono estrellado 5 de color naranja
        private PointF[] CalcularEstrellaInterior5()
        {
            PointF[] innerStar5 = new PointF[16];

            float innerRadius5 = mSide / (4.5f * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle5 = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;
                float innerAngle5 = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f;

                innerStar5[i * 2] = new PointF(innerRadius5 * (float)Math.Cos(outerAngle5), innerRadius5 * (float)Math.Sin(outerAngle5));
                innerStar5[i * 2 + 1] = new PointF(innerRadius5 * 0.6f * (float)Math.Cos(innerAngle5), innerRadius5 * 0.6f * (float)Math.Sin(innerAngle5));
            }

            return innerStar5;
        }

        //Funcion que grafica el octogono estrellado 6 de color azul
        private PointF[] CalcularEstrellaInterior6()
        {
            PointF[] innerStar6 = new PointF[16];

            float innerRadius6 = mSide / (5.5f * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle6 = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;
                float innerAngle6 = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f;

                innerStar6[i * 2] = new PointF(innerRadius6 * (float)Math.Cos(outerAngle6), innerRadius6 * (float)Math.Sin(outerAngle6));
                innerStar6[i * 2 + 1] = new PointF(innerRadius6 * 0.7f * (float)Math.Cos(innerAngle6), innerRadius6 * 0.7f * (float)Math.Sin(innerAngle6)); // Vértices internos
            }

            return innerStar6;
        }

        //Funcion que grafica las rayas tranversales
        private PointF[] CalcularEstrellaInterior7()
        {
            PointF[] innerStar7 = new PointF[16];

            float innerRadius7 = mSide / (1.4f * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle7 = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;
                float innerAngle7 = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f;

                innerStar7[i * 2] = new PointF(innerRadius7 * (float)Math.Cos(outerAngle7), innerRadius7 * (float)Math.Sin(outerAngle7));
                innerStar7[i * 2] = new PointF(innerRadius7 * 0.7f * (float)Math.Cos(innerAngle7), innerRadius7 * 0.7f * (float)Math.Sin(innerAngle7));
            }

            return innerStar7;
        }

        private PointF[] CalcularEstrellaInterior8()
        {
            PointF[] innerStar8 = new PointF[16];

            float innerRadius8 = mSide / (1.4f * (float)Math.Sin(Math.PI / 16));

            for (int i = 0; i < 8; i++)
            {
                float outerAngle8 = (startAngle + i * 45.0f + 22.5f) * (float)Math.PI / 180.0f;
                float innerAngle8 = (startAngle + i * 45.0f) * (float)Math.PI / 180.0f;

                innerStar8[i * 2] = new PointF(innerRadius8 * (float)Math.Cos(outerAngle8), innerRadius8 * (float)Math.Sin(outerAngle8));
                innerStar8[i * 2] = new PointF(innerRadius8 * 0.7f * (float)Math.Cos(innerAngle8), innerRadius8 * 0.7f * (float)Math.Sin(innerAngle8));
            }

            return innerStar8; 
        }

        // Mantengo la firma original para compatibilidad y creo una sobrecarga con transformaciones
        public void DibujarPoligono(PictureBox picCanvas, CTransformation transform)
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

                mPen = new Pen(Color.Black, 1);

                // Dibujo del polígono y estrellas.
                PointF[] vertices = CalcularVertices();

                if (transform != null)
                {
                    // Cuando hay transform, dejamos la figura centrada en el origen y la transformación mueve al pivote.
                    for (int i = 0; i < vertices.Length; i++)
                    {
                        vertices[i].X = SF * vertices[i].X;
                        vertices[i].Y = SF * vertices[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < vertices.Length; i++)
                    {
                        vertices[i].X = SF * vertices[i].X + offsetX;
                        vertices[i].Y = SF * vertices[i].Y + offsetY;
                    }
                }

                g.DrawPolygon(mPen, vertices);


                // Estrellas internas: misma lógica de offset vs origen
                PointF[] innerStar = CalcularEstrellaInterior();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar.Length; i++)
                    {
                        innerStar[i].X = SF * innerStar[i].X;
                        innerStar[i].Y = SF * innerStar[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar.Length; i++)
                    {
                        innerStar[i].X = SF * innerStar[i].X + offsetX;
                        innerStar[i].Y = SF * innerStar[i].Y + offsetY;
                    }
                }
                mPen.Color = Color.Black;
                g.DrawPolygon(mPen, innerStar);

                PointF[] innerStar2 = CalcularEstrellaInterior2();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar2.Length; i++)
                    {
                        innerStar2[i].X = SF * innerStar2[i].X;
                        innerStar2[i].Y = SF * innerStar2[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar2.Length; i++)
                    {
                        innerStar2[i].X = SF * innerStar2[i].X + offsetX;
                        innerStar2[i].Y = SF * innerStar2[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar2);

                PointF[] innerStar3 = CalcularEstrellaInterior3();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar3.Length; i++)
                    {
                        innerStar3[i].X = SF * innerStar3[i].X;
                        innerStar3[i].Y = SF * innerStar3[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar3.Length; i++)
                    {
                        innerStar3[i].X = SF * innerStar3[i].X + offsetX;
                        innerStar3[i].Y = SF * innerStar3[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar3);

                PointF[] innerStar4 = CalcularEstrellaInterior4();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar4.Length; i++)
                    {
                        innerStar4[i].X = SF * innerStar4[i].X;
                        innerStar4[i].Y = SF * innerStar4[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar4.Length; i++)
                    {
                        innerStar4[i].X = SF * innerStar4[i].X + offsetX;
                        innerStar4[i].Y = SF * innerStar4[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar4);

                PointF[] innerStar5 = CalcularEstrellaInterior5();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar5.Length; i++)
                    {
                        innerStar5[i].X = SF * innerStar5[i].X;
                        innerStar5[i].Y = SF * innerStar5[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar5.Length; i++)
                    {
                        innerStar5[i].X = SF * innerStar5[i].X + offsetX;
                        innerStar5[i].Y = SF * innerStar5[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar5);

                PointF[] innerStar6 = CalcularEstrellaInterior6();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar6.Length; i++)
                    {
                        innerStar6[i].X = SF * innerStar6[i].X;
                        innerStar6[i].Y = SF * innerStar6[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar6.Length; i++)
                    {
                        innerStar6[i].X = SF * innerStar6[i].X + offsetX;
                        innerStar6[i].Y = SF * innerStar6[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar6);

                PointF[] innerStar7 = CalcularEstrellaInterior7();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar7.Length; i++)
                    {
                        innerStar7[i].X = SF * innerStar7[i].X;
                        innerStar7[i].Y = SF * innerStar7[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar7.Length; i++)
                    {
                        innerStar7[i].X = SF * innerStar7[i].X + offsetX;
                        innerStar7[i].Y = SF * innerStar7[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar7);

                PointF[] innerStar8 = CalcularEstrellaInterior8();
                if (transform != null)
                {
                    for (int i = 0; i < innerStar8.Length; i++)
                    {
                        innerStar8[i].X = SF * innerStar8[i].X;
                        innerStar8[i].Y = SF * innerStar8[i].Y;
                    }
                }
                else
                {
                    float offsetX = picCanvas.Width / 2;
                    float offsetY = picCanvas.Height / 2;
                    for (int i = 0; i < innerStar8.Length; i++)
                    {
                        innerStar8[i].X = SF * innerStar8[i].X + offsetX;
                        innerStar8[i].Y = SF * innerStar8[i].Y + offsetY;
                    }
                }
                g.DrawPolygon(mPen, innerStar8);

                // Restaurar estado
                g.Restore(state);
            }

            // Forzar repintado del PictureBox (muestra el Bitmap persistente)
            picCanvas.Refresh();
        }

        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}
