using Assets.Scripts.Features.Input;
using Assets.Scripts.Features.Input.Services;
using Assets.Scripts.Features.Services;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Features.Input.InputPosition
{
    /// <summary>
    /// Система отслеживания кликов по игровому полю
    /// </summary>
    public class InputPositionSystem : IExecuteSystem
    {
        #region Services

        /// <summary>
        /// Сервис событий игрового поля
        /// </summary>
        private IInputService
            _inputService;

        /// <summary>
        /// Сервис работы с камерой
        /// </summary>
        private CameraService
            _cameraService;

        #endregion

        #region Fields

        /// <summary>
        /// Контекст
        /// </summary>
        private InputContext
            _inputContext;

        #endregion

        #region ctor

        public InputPositionSystem(Contexts context)
        {
            _inputContext = context.input;

            _cameraService = context.services.ProvideCameraService();
            _inputService = _inputContext.services.ProvideInputService();

            _inputContext.SetInputPosition(Vector3.zero);
        }

        #endregion

        #region IExecuteSystem implementation

        public void Execute()
        {
            if (_inputService.IsMouseDown())
            {
                // Если было произведено нажатие, сохраним мировые координаты клика
                _inputContext.ReplaceInputPosition(
                    _cameraService.ScreenToWorldPoint(_inputService.GetScreenPosition()));
            }
        }

        #endregion
    }
}