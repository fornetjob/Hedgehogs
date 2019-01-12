using UnityEngine;

namespace Assets.Scripts.Tools
{
    /// <summary>
    /// Тул математических функций
    /// </summary>
    public static class MathTool
    {
        /// <summary>
        /// Возвращает позицию в спирали по индексу элемента
        /// </summary>
        /// <param name="index">Индекс элемента в спирали</param>
        /// <returns></returns>
        public static Vector2 GetSpiralPositionByIndex(int index)
        {
            if (index > 0)
            {
                index--;

                int radius = Mathf.FloorToInt((Mathf.Sqrt(index + 1) - 1) / 2) + 1;

                int p = (8 * radius * (radius - 1)) / 2;

                int en = radius * 2;

                int a = (1 + index - p) % (radius * 8);

                // Стороны: 0 top, 1 right, 2, bottom, 3 left
                int side = Mathf.FloorToInt(a / (radius * 2));

                if (side == 0)
                {
                    return new Vector2(a - radius, -radius);
                }
                else if (side == 1)
                {
                    return new Vector2(radius, (a % en) - radius);
                }
                else if (side == 2)
                {
                    return new Vector2(radius - (a % en), radius);
                }
                else if (side == 3)
                {
                    return new Vector2(-radius, radius - (a % en));
                }
            }

            return new Vector2(0, 0);
        }
    }
}
