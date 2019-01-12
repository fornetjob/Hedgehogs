using System;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Интервал
    /// </summary>
    [Serializable]
    public struct BetweenFloat
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="minValue">Минимальное значение в интервале</param>
        /// <param name="maxValue">Максимальное значение в интервале</param>
        public BetweenFloat(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Минимальное значение в интервале
        /// </summary>
        public float MinValue;
        /// <summary>
        /// Максимальное значение в интервале
        /// </summary>
        public float MaxValue;
    }
}
