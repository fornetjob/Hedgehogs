using UnityEngine;

namespace Assets.Scripts.Features.Input.Services
{
    /// <summary>
    /// Сервис событий игрового поля
    /// </summary>
    public class InputService : IInputService
    {
        /// <summary>
        /// Возвращает информацию о нажатии на игровое поле
        /// </summary>
        /// <returns></returns>
        bool IInputService.IsMouseDown()
        {
            return UnityEngine.Input.GetMouseButtonDown(0);
        }
        /// <summary>
        /// Позиция игрового поля
        /// </summary>
        /// <returns></returns>
        Vector2 IInputService.GetScreenPosition()
        {
            return UnityEngine.Input.mousePosition;
        }
    }
}