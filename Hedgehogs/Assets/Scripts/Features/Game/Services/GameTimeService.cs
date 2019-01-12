using UnityEngine;

namespace Assets.Scripts.Features.Game.Services
{
    /// <summary>
    /// Сервис игрового времени
    /// </summary>
    internal sealed class GameTimeService : IGameTimeService
    {
        /// <summary>
        /// Возвращает время в секундах с прошлого фрейма
        /// </summary>
        /// <returns></returns>
        public float GetDeltaTime()
        {
            return Time.deltaTime;
        }
    }
}
