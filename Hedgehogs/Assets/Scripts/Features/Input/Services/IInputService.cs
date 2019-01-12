using Assets.Scripts.Core;
using UnityEngine;

namespace Assets.Scripts.Features.Input.Services
{
    /// <summary>
    /// Интерфейс сервиса событий экрана
    /// </summary>
    [Service(typeof(InputService))]
    public interface IInputService:IService
    {
        /// <summary>
        /// Возвращает информацию о нажатии на экран
        /// </summary>
        /// <returns></returns>
        bool IsMouseDown();
        /// <summary>
        /// Позиция экарана
        /// </summary>
        /// <returns></returns>
        Vector2 GetScreenPosition();
    }
}
