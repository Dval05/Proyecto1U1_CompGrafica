using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP1
{
    internal class CFlor
    {

        public static void DibujarCirculo(Graphics g, int ancho, int alto)
        {
            //g.TranslateTransform(ancho / 2, alto / 2);

            GraphicsPath ruta = new GraphicsPath();
            int centroX = 0;
            int centroY = 0;
            int radio = 50;
            ruta.AddEllipse(centroX - radio, centroY - radio, radio * 2, radio * 2);

            int centroX1 = 0;
            int centroY1 = 50;
            ruta.AddEllipse(centroX1 - radio, centroY1 - radio, radio * 2, radio * 2);

            int centroX2 = 0;
            int centroY2 = -50;
            ruta.AddEllipse(centroX2 - radio, centroY2 - radio, radio * 2, radio * 2);

            int centroX3 = -45;
            int centroY3 = -25;
            ruta.AddEllipse(centroX3 - radio, centroY3 - radio, radio * 2, radio * 2);

            int centroX4 = 45;
            int centroY4 = 25;
            ruta.AddEllipse(centroX4 - radio, centroY4 - radio, radio * 2, radio * 2);

            int centroX5 = 45;
            int centroY5 = -25;
            ruta.AddEllipse(centroX5 - radio, centroY5 - radio, radio * 2, radio * 2);

            int centroX6 = -45;
            int centroY6 = 25;
            ruta.AddEllipse(centroX6 - radio, centroY6 - radio, radio * 2, radio * 2);

            Pen lapiz = new Pen(Color.Black, 2);
            g.DrawPath(lapiz, ruta);

            // Crear la ruta para el primer pétalo diagonal superior derecho
            GraphicsPath rutaPetal = new GraphicsPath();
            int centroX7 = 45;
            int centroY7 = -75;
            rutaPetal.AddEllipse(centroX7 - radio, centroY7 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal);
            g.ResetClip();

            // Crear la ruta para el segundo pétalo diagonal inferior derecho
            GraphicsPath rutaPetal2 = new GraphicsPath();
            int centroX8 = 45;
            int centroY8 = 75;
            rutaPetal2.AddEllipse(centroX8 - radio, centroY8 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal2);
            g.ResetClip();

            // Crear la ruta para el tercer pétalo diagonal inferior izquierdo
            GraphicsPath rutaPetal3 = new GraphicsPath();
            int centroX9 = -45;
            int centroY9 = 75;
            rutaPetal3.AddEllipse(centroX9 - radio, centroY9 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal3);
            g.ResetClip();

            // Crear la ruta para el cuarto pétalo diagonal superior izquierdo
            GraphicsPath rutaPetal4 = new GraphicsPath();
            int centroX10 = -45;
            int centroY10 = -75;
            rutaPetal4.AddEllipse(centroX10 - radio, centroY10 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal4);
            g.ResetClip();

            // Crear la ruta para el quinto pétalo de arriba
            GraphicsPath clipCirculoArriba = new GraphicsPath();
            int centroCirculoArriba = 0;
            int centroYCirculoArriba = -50;
            clipCirculoArriba.AddEllipse(centroCirculoArriba - radio, centroYCirculoArriba - radio, radio * 2, radio * 2);
            // Crear el pétalo
            GraphicsPath rutaPetal5 = new GraphicsPath();
            int centroX11 = 0;
            int centroY11 = -100;
            rutaPetal5.AddEllipse(centroX11 - radio, centroY11 - radio, radio * 2, radio * 2);
            // Hacer el clip solo con el círculo de arriba
            g.SetClip(clipCirculoArriba);
            g.DrawPath(lapiz, rutaPetal5);
            g.ResetClip();


            // Crear el clip solo con el círculo de abajo
            GraphicsPath clipCirculoAbajo = new GraphicsPath();
            int centroCirculoAbajo = 0;
            int centroYCirculoAbajo = 50;
            clipCirculoAbajo.AddEllipse(centroCirculoAbajo - radio, centroYCirculoAbajo - radio, radio * 2, radio * 2);
            GraphicsPath rutaPetal6 = new GraphicsPath();
            int centroX12 = 0;
            int centroY12 = 100;
            rutaPetal6.AddEllipse(centroX12 - radio, centroY12 - radio, radio * 2, radio * 2);
            g.SetClip(clipCirculoAbajo);
            g.DrawPath(lapiz, rutaPetal6);
            g.ResetClip();

            // Crear el pétalo derecho
            GraphicsPath rutaPetal7 = new GraphicsPath();
            int centroX13 = 85;
            int centroY13 = 0;
            rutaPetal7.AddEllipse(centroX13 - radio, centroY13 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal7);
            g.ResetClip();
            // Crear el pétalo izquierdo
            GraphicsPath rutaPetal8 = new GraphicsPath();
            int centroX14 = -85;
            int centroY14 = 0;
            rutaPetal8.AddEllipse(centroX14 - radio, centroY14 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal8);
            g.ResetClip();


            // Crear el clip solo con el círculo diagonal superior derecho
            GraphicsPath clipDiagonal = new GraphicsPath();
            int centroDiagonalX = 45;
            int centroDiagonalY = -25;
            clipDiagonal.AddEllipse(centroDiagonalX - radio, centroDiagonalY - radio, radio * 2, radio * 2);
            // Crear el pétalo
            GraphicsPath rutaPetal9 = new GraphicsPath();
            int centroX15 = 85;
            int centroY15 = -50;
            rutaPetal9.AddEllipse(centroX15 - radio, centroY15 - radio, radio * 2, radio * 2);
            g.SetClip(clipDiagonal);
            g.DrawPath(lapiz, rutaPetal9);
            g.ResetClip();
            clipDiagonal.Dispose();
            rutaPetal9.Dispose();


            // Crear el clip solo con el círculo diagonal inferior derecho
            GraphicsPath clipDiagonalI = new GraphicsPath();
            int centroDiagonalIX = 45;
            int centroDiagonalIY = 25;
            clipDiagonalI.AddEllipse(centroDiagonalIX - radio, centroDiagonalIY - radio, radio * 2, radio * 2);
            // Crear el pétalo
            GraphicsPath rutaPetal10 = new GraphicsPath();
            int centroX16 = 85;
            int centroY16 = 50;
            rutaPetal10.AddEllipse(centroX16 - radio, centroY16 - radio, radio * 2, radio * 2);
            g.SetClip(clipDiagonalI);
            g.DrawPath(lapiz, rutaPetal10);
            g.ResetClip();
            clipDiagonalI.Dispose();


            // Crear el clip solo con el círculo diagonal superior izquierdo
            GraphicsPath clipDiagonalSI = new GraphicsPath();
            int centroDiagonalSIX = -45;
            int centroDiagonalSIY = -25;
            clipDiagonalSI.AddEllipse(centroDiagonalSIX - radio, centroDiagonalSIY - radio, radio * 2, radio * 2);
            // Crear el pétalo
            GraphicsPath rutaPetal11 = new GraphicsPath();
            int centroX17 = -85;
            int centroY17 = -50;
            rutaPetal11.AddEllipse(centroX17 - radio, centroY17 - radio, radio * 2, radio * 2);
            g.SetClip(clipDiagonalSI);
            g.DrawPath(lapiz, rutaPetal11);
            g.ResetClip();
            clipDiagonalSI.Dispose();


            // Crear el clip solo con el círculo diagonal inferior izquierdo
            GraphicsPath clipDiagonalII = new GraphicsPath();
            int centroDiagonalIIX = -45;
            int centroDiagonalIIY = 25;
            clipDiagonalII.AddEllipse(centroDiagonalIIX - radio, centroDiagonalIIY - radio, radio * 2, radio * 2);
            // Crear el pétalo
            GraphicsPath rutaPetal12 = new GraphicsPath();
            int centroX18 = -85;
            int centroY18 = 50;
            rutaPetal12.AddEllipse(centroX18 - radio, centroY18 - radio, radio * 2, radio * 2);
            g.SetClip(clipDiagonalII);
            g.DrawPath(lapiz, rutaPetal12);
            g.ResetClip();
            clipDiagonalII.Dispose();


            //12 circulos de los extremos):
            // Crear la ruta para el primer pétalo diagonal extremo superior derecho
            GraphicsPath rutaPetal13 = new GraphicsPath();
            int centroX19 = 42;
            int centroY19 = -125;
            rutaPetal13.AddEllipse(centroX19 - radio, centroY19 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal13);
            g.ResetClip();

            // Crear la ruta para el segundo pétalo diagonal extremo inferior dercho
            GraphicsPath rutaPetal14 = new GraphicsPath();
            int centroX20 = 42;
            int centroY20 = 125;
            rutaPetal14.AddEllipse(centroX20 - radio, centroY20 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal14);
            g.ResetClip();

            // Crear la ruta para el tercero pétalo diagonal extremo inferior izquierdo
            GraphicsPath rutaPetal15 = new GraphicsPath();
            int centroX21 = -42;
            int centroY21 = 125;
            rutaPetal15.AddEllipse(centroX21 - radio, centroY21 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal15);
            g.ResetClip();

            // Crear la ruta para el cuarto pétalo diagonal extremo superior izquierdo
            GraphicsPath rutaPetal16 = new GraphicsPath();
            int centroX22 = -42;
            int centroY22 = -125;
            rutaPetal16.AddEllipse(centroX22 - radio, centroY22 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal16);
            g.ResetClip();

            // Crear la ruta para el quinto pétalo diagonal2 extremo superior derecho
            GraphicsPath rutaPetal17 = new GraphicsPath();
            int centroX23 = 85;
            int centroY23 = -100;
            rutaPetal17.AddEllipse(centroX23 - radio, centroY23 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal17);
            g.ResetClip();

            // Crear la ruta para el sexto pétalo diagonal2 extremo inferior derecho
            GraphicsPath rutaPetal18 = new GraphicsPath();
            int centroX24 = 85;
            int centroY24 = 100;
            rutaPetal18.AddEllipse(centroX24 - radio, centroY24 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal18);
            g.ResetClip();

            // Crear la ruta para el sptimo pétalo diagonal2 extremo inferior izquierdo
            GraphicsPath rutaPetal19 = new GraphicsPath();
            int centroX25 = -85;
            int centroY25 = 100;
            rutaPetal19.AddEllipse(centroX25 - radio, centroY25 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal19);
            g.ResetClip();

            // Crear la ruta para el octav pétalo diagonal2 extremo superior derecho
            GraphicsPath rutaPetal20 = new GraphicsPath();
            int centroX26 = -85;
            int centroY26 = -100;
            rutaPetal20.AddEllipse(centroX26 - radio, centroY26 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal20);
            g.ResetClip();

            // Crear la ruta para el nov pétalo diagonal3 extremo superior derecho
            GraphicsPath rutaPetal21 = new GraphicsPath();
            int centroX27 = 131;
            int centroY27 = -25;
            rutaPetal21.AddEllipse(centroX27 - radio, centroY27 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal21);
            g.ResetClip();

            // Crear la ruta para el dec pétalo diagonal3 extremo inferior derecho
            GraphicsPath rutaPetal22 = new GraphicsPath();
            int centroX28 = 131;
            int centroY28 = 25;
            rutaPetal22.AddEllipse(centroX28 - radio, centroY28 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal22);
            g.ResetClip();

            // Crear la ruta para el undecim pétalo diagonal3 extremo inferior izquierdo
            GraphicsPath rutaPetal23 = new GraphicsPath();
            int centroX29 = -131;
            int centroY29 = 25;
            rutaPetal23.AddEllipse(centroX29 - radio, centroY29 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal23);
            g.ResetClip();

            // Crear la ruta para el duodecim pétalo diagonal3 extremo sup izquierdo
            GraphicsPath rutaPetal24 = new GraphicsPath();
            int centroX30 = -131;
            int centroY30 = -25;
            rutaPetal24.AddEllipse(centroX30 - radio, centroY30 - radio, radio * 2, radio * 2);
            g.SetClip(ruta);
            g.DrawPath(lapiz, rutaPetal24);
            g.ResetClip();


            // Circulo final F
            // Circulo final con líneas entrecortadas
            GraphicsPath rutaCirculoF = new GraphicsPath();
            int radioF = 105;
            int centroXF = 0;
            int centroYF = 0;
            rutaCirculoF.AddEllipse(centroXF - radioF, centroYF - radioF, radioF * 2, radioF * 2);
            // Crear un lápiz con líneas entrecortadas
            Pen lapizEntrecortado = new Pen(Color.Black);
            lapizEntrecortado.DashStyle = DashStyle.Dash;// Líneas entrecortadas
            // Dibujarlo
            g.DrawPath(lapizEntrecortado, rutaCirculoF);
            lapizEntrecortado.Dispose();
            rutaCirculoF.Dispose();


            lapiz.Dispose();
            ruta.Dispose();
            rutaPetal.Dispose();
            rutaPetal2.Dispose();
            rutaPetal3.Dispose();
            rutaPetal4.Dispose();
            rutaPetal5.Dispose();
            rutaPetal6.Dispose();
            rutaPetal7.Dispose();
            rutaPetal8.Dispose();
            rutaPetal9.Dispose();
            rutaPetal10.Dispose();
            rutaPetal11.Dispose();
            rutaPetal12.Dispose();
            rutaPetal13.Dispose();
            rutaPetal14.Dispose();
            rutaPetal15.Dispose();
            rutaPetal16.Dispose();
            rutaPetal17.Dispose();
            rutaPetal18.Dispose();
            rutaPetal19.Dispose();
            rutaPetal20.Dispose();
            rutaPetal21.Dispose();
            rutaPetal22.Dispose();
            rutaPetal23.Dispose();
            rutaPetal24.Dispose();
            // (Opcional) Restaurar la transformación si dibujarás más cosas luego
            //g.ResetTransform();
        }
    }
}
