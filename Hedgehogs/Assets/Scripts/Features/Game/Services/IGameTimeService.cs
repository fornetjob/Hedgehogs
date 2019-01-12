using Assets.Scripts.Core;

namespace Assets.Scripts.Features.Game.Services
{
    /// <summary>
    /// Интерфейс сервиса игрового времени
    /// </summary>
    [Service(typeof(GameTimeService))]
    public interface IGameTimeService:IService
    {
        /// <summary>
        /// Возвращает время в секундах с прошлого фрейма
        /// </summary>
        float GetDeltaTime();
    }
}
