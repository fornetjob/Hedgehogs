using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Features.Game.Services
{
    /// <summary>
    /// Сервис случайных чисел
    /// </summary>
    public sealed class RandomService:IService
    {
        /// <summary>
        /// Возвращает случайное целочисленное значение
        /// </summary>
        /// <param name="from">Минимальное значение (включено)</param>
        /// <param name="to">Максимальное значение (исключено)</param>
        /// <returns></returns>
        public int Range(int from, int to)
        {
            return Random.Range(from, to);
        }

        /// <summary>
        /// Возвращает случайное число с правающей запятой
        /// </summary>
        /// <param name="from">Минимальное значение</param>
        /// <param name="to">Максимальное значение</param>
        /// <returns></returns>
        public float Range(float from, float to)
        {
            return Random.Range(from, to);
        }

        /// <summary>
        /// Возвращает случайное число с правающей запятой
        /// </summary>
        /// <param name="value">Интервал значений</param>
        /// <returns></returns>
        public float Range(BetweenFloat value)
        {
            return Range(value.MinValue, value.MaxValue);
        }
    }
}
