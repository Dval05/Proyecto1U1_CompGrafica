using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;


namespace ProyectoP1
{
    internal class CPentagonoEstrellado
    {

        public void DibujarEstrella(Graphics g, int anchoPictureBox, int altoPictureBox, float radioBase)
        {
            Pen pen = new Pen(Color.Black, 1);
            GraphicsPath path = new GraphicsPath();

            float centroX = 0; 
            float centroY = 0;

            // Calcular radios proporcionalmente basados en radioBase
            float radio1 = radioBase;
            float radio2 = radioBase * 1.68f;
            float radio3 = radioBase * 1.80f;
            float radio4 = radioBase * 2.84f;
            float radio5 = radioBase * 3.20f;
            float radio6 = radioBase * 3.60f;
            float radio7 = radioBase * 6.80f;

            //puntos de estrella base 0-4 con radio
            PointF[] puntosPequeños = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                double angulo = Math.PI / 180 * (i * 72 - 90);
                puntosPequeños[i] = new PointF(
                    centroX + radio1 * (float)Math.Cos(angulo),
                    centroY + radio1 * (float)Math.Sin(angulo)
                );
            }

            //Calculo de puentos medios basado en la estrella base puntosPequeños
            //ajustar cada punto medio para que esté desde el centro al nuevo radio2
            PointF[] puntosNuevos = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                // Punto medio entre puntosPequeños[i] y puntosPequeños[(i+1)%5]
                PointF puntoMedio = new PointF(
                    (puntosPequeños[i].X + puntosPequeños[(i + 1) % 5].X) / 2,
                    (puntosPequeños[i].Y + puntosPequeños[(i + 1) % 5].Y) / 2
                );
                // Calcular la distancia del punto medio al centro (0,0)
                float distancia = (float)Math.Sqrt(puntoMedio.X * puntoMedio.X + puntoMedio.Y * puntoMedio.Y);

                // distancio 0 pero no deberia de pasar
                if (distancia == 0)
                {
                    puntosNuevos[i] = puntoMedio;
                }
                else
                {
                    // Escalar el punto medio para que esté a radio2 desde el centro
                    puntosNuevos[i] = new PointF(
                        puntoMedio.X * (radio2 / distancia),
                        puntoMedio.Y * (radio2 / distancia)
                    );
                }
            }

            PointF[] puntosNuevos2 = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                PointF puntoMedio = new PointF(
                    (puntosNuevos[i].X + puntosNuevos[(i + 1) % 5].X) / 2,
                    (puntosNuevos[i].Y + puntosNuevos[(i + 1) % 5].Y) / 2
                );
                float distancia = (float)Math.Sqrt(puntoMedio.X * puntoMedio.X + puntoMedio.Y * puntoMedio.Y);

                if (distancia == 0)
                {
                    puntosNuevos2[i] = puntoMedio;
                }
                else
                {
                    puntosNuevos2[i] = new PointF(
                        puntoMedio.X * (radio3 / distancia),
                        puntoMedio.Y * (radio3 / distancia)
                    );
                }
            }


            PointF[] puntosNuevos3 = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                PointF puntoMedio = new PointF(
                    (puntosNuevos2[i].X + puntosNuevos2[(i + 1) % 5].X) / 2,
                    (puntosNuevos2[i].Y + puntosNuevos2[(i + 1) % 5].Y) / 2
                );
                float distancia = (float)Math.Sqrt(puntoMedio.X * puntoMedio.X + puntoMedio.Y * puntoMedio.Y);

                if (distancia == 0)
                {
                    puntosNuevos3[i] = puntoMedio;
                }
                else
                {
                    puntosNuevos3[i] = new PointF(
                        puntoMedio.X * (radio4 / distancia),
                        puntoMedio.Y * (radio4 / distancia)
                    );
                }
            }


            PointF[] puntosNuevos4 = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                PointF puntoMedio = new PointF(
                    (puntosNuevos3[i].X + puntosNuevos3[(i + 1) % 5].X) / 2,
                    (puntosNuevos3[i].Y + puntosNuevos3[(i + 1) % 5].Y) / 2
                );
                float distancia = (float)Math.Sqrt(puntoMedio.X * puntoMedio.X + puntoMedio.Y * puntoMedio.Y);

                if (distancia == 0)
                {
                    puntosNuevos4[i] = puntoMedio;
                }
                else
                {
                    puntosNuevos4[i] = new PointF(
                        puntoMedio.X * (radio5 / distancia),
                        puntoMedio.Y * (radio5 / distancia)
                    );
                }
            }


            PointF[] puntosNuevos5 = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                PointF puntoMedio = new PointF(
                    (puntosNuevos4[i].X + puntosNuevos4[(i + 1) % 5].X) / 2,
                    (puntosNuevos4[i].Y + puntosNuevos4[(i + 1) % 5].Y) / 2
                );
                float distancia = (float)Math.Sqrt(puntoMedio.X * puntoMedio.X + puntoMedio.Y * puntoMedio.Y);

                if (distancia == 0)
                {
                    puntosNuevos5[i] = puntoMedio;
                }
                else
                {
                    puntosNuevos5[i] = new PointF(
                        puntoMedio.X * (radio6 / distancia),
                        puntoMedio.Y * (radio6 / distancia)
                    );
                }
            }


            PointF[] puntosNuevos6 = new PointF[5];
            for (int i = 0; i < 5; i++)
            {
                PointF puntoMedio = new PointF(
                    (puntosNuevos5[i].X + puntosNuevos5[(i + 1) % 5].X) / 2,
                    (puntosNuevos5[i].Y + puntosNuevos5[(i + 1) % 5].Y) / 2
                );
                float distancia = (float)Math.Sqrt(puntoMedio.X * puntoMedio.X + puntoMedio.Y * puntoMedio.Y);

                if (distancia == 0)
                {
                    puntosNuevos6[i] = puntoMedio;
                }
                else
                {
                    puntosNuevos6[i] = new PointF(
                        puntoMedio.X * (radio7 / distancia),
                        puntoMedio.Y * (radio7 / distancia)
                    );
                }
            }
            // Aplicar la transformación para centrar en el PictureBox
            //g.TranslateTransform(anchoPictureBox / 2f, altoPictureBox / 2f);


            // dibujo
            path.AddLine(puntosPequeños[0], puntosPequeños[2]);
            path.AddLine(puntosPequeños[2], puntosPequeños[4]);
            path.AddLine(puntosPequeños[4], puntosPequeños[1]);
            path.AddLine(puntosPequeños[1], puntosPequeños[3]);
            path.AddLine(puntosPequeños[3], puntosPequeños[0]);



            // Dibujar los trazos desde los puntos pequeños a los primeros nuevos vértices (radio2) puntos nuevos
            for (int i = 0; i < 5; i++)
            {
                // Solo dibujamos las dos líneas que convergen en puntosNuevos[i]
                // desde los dos puntos pequeños que lo generaron
                path.AddLine(puntosPequeños[i], puntosNuevos[i]);
                path.AddLine(puntosNuevos[i], puntosPequeños[(i + 1) % 5]);
            }

            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosNuevos[i], puntosNuevos2[i]);
                path.AddLine(puntosNuevos2[i], puntosNuevos[(i + 1) % 5]);
            }

            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosNuevos2[i], puntosNuevos3[i]); // Línea desde el primer punto del par al nuevo vértice
                path.AddLine(puntosNuevos3[i], puntosNuevos2[(i + 1) % 5]); // Línea desde el segundo punto del par al nuevo vértice 
            }


            //dibujar trazos desde los puntosNuevos3 a puntosPqueños
            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosNuevos3[i], puntosPequeños[(i + 1) % 5]);
                path.AddLine(puntosNuevos3[i], puntosPequeños[(i + 2) % 5]);
            }


            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosNuevos3[i], puntosNuevos4[i]); 
                path.AddLine(puntosNuevos4[i], puntosNuevos3[(i + 1) % 5]);
            }


            //dibujar trazos desde los puntosNuevos4 a puntosNuevos
            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosNuevos4[i], puntosNuevos[(i + 1) % 5]);
                path.AddLine(puntosNuevos4[i], puntosNuevos[(i + 2) % 5]);
            }


            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosNuevos4[i], puntosNuevos5[i]);
                path.AddLine(puntosNuevos5[i], puntosNuevos4[(i + 1) % 5]);
            }

            // Dibujar los trazos desde los quintos nuevos vértices a los sexts nuevos vértices (radio7) puntos nuevos 
            // aqui elimine nuevopuntos6




            // Calcular los 10 puntos medios primero 
            PointF[] puntosMedios = new PointF[10];
            for (int i = 0; i < 5; i++)
            {
                puntosMedios[i * 2] = new PointF(
                    (puntosNuevos5[i].X + puntosNuevos6[i].X) / 2,
                    (puntosNuevos5[i].Y + puntosNuevos6[i].Y) / 2
                );
                puntosMedios[i * 2 + 1] = new PointF(
                    (puntosNuevos6[i].X + puntosNuevos5[(i + 1) % 5].X) / 2,
                    (puntosNuevos6[i].Y + puntosNuevos5[(i + 1) % 5].Y) / 2
                );
            }
            // Dibujar los trazos desde los quintos nuevos vértices SOLO hasta los puntos medios
            for (int i = 0; i < 5; i++)
            {
                path.StartFigure(); 
                path.AddLine(puntosNuevos5[i], puntosMedios[i * 2]);

                path.StartFigure(); 
                path.AddLine(puntosMedios[i * 2 + 1], puntosNuevos5[(i + 1) % 5]);
            }
            // Dibujar las conexiones entre los puntos medios PARES (pentágono 1)
            path.StartFigure();
            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosMedios[i * 2], puntosMedios[((i + 1) % 5) * 2]);
            }
            // Dibujar las conexiones entre los puntos medios IMPARES (pentágono 2)
            path.StartFigure();
            for (int i = 0; i < 5; i++)
            {
                path.AddLine(puntosMedios[i * 2 + 1], puntosMedios[((i + 1) % 5) * 2 + 1]);
            }




            // Dibujar el path completo
            g.DrawPath(pen, path);
            // Restaurar el sistema de coordenadas original
            //g.ResetTransform();
            // Limpiar recursos
            pen.Dispose();
            path.Dispose();
        }
    }
}
