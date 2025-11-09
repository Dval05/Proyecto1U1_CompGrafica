using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoP1
{
    public class CTransformation
    {
        // --- PROPIEDADES DE ESTADO ---

        /// El punto central (pivote) sobre el cual rotar y escalar.
        public PointF Pivot { get; set; } = PointF.Empty;

        /// La rotación actual en grados.
        public float Rotation { get; private set; } = 0f;

        /// El factor de escala actual (1.0 = 100%).
        public float Scale { get; private set; } = 1.0f;

        /// El desplazamiento (X, Y) desde el pivote.
        public PointF Translation { get; private set; } = PointF.Empty;


        // --- MÉTODOS DE ACCIÓN ---

        /// Añade grados a la rotación actual.
        /// <param name="degrees">Grados a añadir (puede ser negativo).</param>
        public void Rotate(float degrees)
        {
            Rotation += degrees;
        }

        /// Añade un desplazamiento a la traslación actual.
        /// <param name="dx">Cambio en X.</param>
        /// <param name="dy">Cambio en Y.</param>
        public void Translate(float dx, float dy)
        {
            Translation = new PointF(Translation.X + dx, Translation.Y + dy);
        }

        /// Establece la escala a un valor absoluto.
        /// Incluye una protección para evitar valores de 0 o negativos.
        /// <param name="newScale">El nuevo factor de escala (ej: 1.5 = 150%).</param>
        public void SetScale(float newScale)
        {
            // Protección contra el error 'Parámetro no válido'
            if (newScale < 0.01f)
            {
                Scale = 0.01f;
            }
            else
            {
                Scale = newScale;
            }
        }

        /// Multiplica la escala actual por un factor (para la rueda del ratón).
        /// <param name="factor">Factor por el cual multiplicar (ej: 1.1).</param>
        public void AdjustScale(float factor)
        {
            // Llama a SetScale para que la lógica de protección se aplique aquí también
            SetScale(Scale * factor);
        }

        /// Resetea todas las transformaciones a sus valores por defecto.
        public void Reset()
        {
            Rotation = 0f;
            Scale = 1.0f;
            Translation = PointF.Empty;
        }

        /// Aplica todas las transformaciones almacenadas a un objeto Graphics.
        /// <param name="g">El lienzo de gráficos donde se va a dibujar.</param>
        public void ApplyTransforms(Graphics g)
        {
            // El orden es crucial:
            // 1. Mover al pivote + traslación
            g.TranslateTransform(Pivot.X + Translation.X, Pivot.Y + Translation.Y);
            // 2. Rotar sobre ese nuevo punto
            g.RotateTransform(Rotation);
            // 3. Escalar sobre ese nuevo punto
            g.ScaleTransform(Scale, Scale);
        }
    }
}