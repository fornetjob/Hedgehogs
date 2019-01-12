using Assets.Scripts.Configs;
using Assets.Scripts.Features.Game.Services;
using Assets.Scripts.Features.Services;

using System.Collections;

using UnityEngine;

namespace Assets.Scripts.Features.Game.Floor
{
    /// <summary>
    /// Контроллер восстановления вертикального положения
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class RiseViewController:ViewControllerBase<IRiseProjection>, IRiseListener
    {
        #region Settings and constants

        private const float StopVelocityPrecission = 0.1f;

        /// <summary>
        /// Настройки персонажа
        /// </summary>
        private static CharacterSettings CharacterSettings;

        #endregion

        #region Services

        private static IGameTimeService
            _timeService;

        private static CameraService 
            _cameraService;

        #endregion

        #region Bindings

        /// <summary>
        /// Твёрдое тело
        /// </summary>
        [SerializeField]
        [Binding(".")]
        private Rigidbody2D
            _rb = null;

        /// <summary>
        /// Коллайдер
        /// </summary>
        [SerializeField]
        [Binding(".")]
        private Collider2D
            _collider = null;

        #endregion

        #region Overriden methods

        protected override void OnBeginController(Contexts context)
        {
            CharacterSettings = context.game.services
                .ProvideConfigService().GetCharacterSettings();

            _cameraService = context.services.ProvideCameraService();
            _timeService = context.game.services.ProvideGameTimeService();
        }

        protected override void OnOpenController(IRiseProjection projection)
        {
            // Подпишемся на требование восстановления вертикального положения
            projection.AddRiseListener(this);
        }

        #endregion

        #region IRiseListener implementation

        void IRiseListener.OnRise(GameEntity entity)
        {
            if (_cameraService.IsColliderInFrustum(_collider) == false)
            {
                entity.isDestroy = true;

                return;
            }

            // Добавим задание
            entity.AddTask(RotateToFloor(entity));
        }

        #endregion

        #region Tasks

        private IEnumerator RotateToFloor(IRiseProjection projection)
        {
            while (true)
            {
                if (_rb.angularVelocity <= Mathf.Epsilon
                    && _rb.velocity.magnitude <= Mathf.Epsilon)
                {
                    break;
                }

                var deltaTime = _timeService.GetDeltaTime();

                _rb.angularVelocity = Mathf.MoveTowards(_rb.angularVelocity, 0, deltaTime);
                _rb.velocity = Vector2.MoveTowards(_rb.velocity, Vector2.zero, deltaTime);

                yield return 0;
            }

            var _rotateTo = 0;

            var rotation = _rb.rotation % 360;

            if (rotation > 180)
            {
                _rotateTo = 360;
            }
            else if (rotation < -180)
            {
                _rotateTo = -360;
            }

            _rb.isKinematic = true;
            _rb.rotation = rotation;
            _rb.angularVelocity = 0;

            float distance;

            while(true)
            {
                // Будем вращать персонажа, пока он не восстановит вертикальное положение
                _rb.rotation = Mathf.MoveTowards(_rb.rotation, _rotateTo, 
                    _timeService.GetDeltaTime() * CharacterSettings.RisingSpeed);

                distance = Mathf.Abs(Mathf.DeltaAngle(_rb.rotation, _rotateTo));

                if (distance < Mathf.Epsilon)
                {
                    break;
                }

                yield return 0;
            }

            _rb.velocity = Vector2.zero;
            _rb.angularVelocity = 0;
            _rb.rotation = 0;

            _rb.isKinematic = false;

            projection.isRise = false;

            yield break;
        }

        #endregion
    }
}