using UnityEngine;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Атрибут предела значений BetweenFloat
    /// </summary>
    public class BetweenRangeAttribute:PropertyAttribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="digits">Округление до знака после запятой</param>
        public BetweenRangeAttribute(float minValue, float maxValue, int digits = 2)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Digits = digits;
        }

        /// <summary>
        /// Минимальное значение
        /// </summary>
        public float MinValue;
        /// <summary>
        /// Максимальное значение
        /// </summary>
        public float MaxValue;
        /// <summary>
        /// Округление до знака после запятой
        /// </summary>
        public int Digits;
    }
}
