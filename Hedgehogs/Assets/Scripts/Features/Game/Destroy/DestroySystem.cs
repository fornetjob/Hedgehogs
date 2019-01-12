using Assets.Scripts.Features.Game.Services;
using Entitas;

namespace Assets.Scripts.Features.Game.Destroy
{
    /// <summary>
    /// Система уничтожения сущностей
    /// </summary>
    public class DestroySystem : ICleanupSystem
    {
        #region Services

        private ControllerPoolingService
            _controllerPoolingService;

        #endregion

        #region Fields

        /// <summary>
        /// Группа сущностей к уничтожению
        /// </summary>
        private IGroup<GameEntity>
            _destroyGroup;

        #endregion

        #region ctor

        public DestroySystem(Contexts context)
        {
            _destroyGroup = context.game.GetGroup(GameMatcher.Destroy);

            _controllerPoolingService = context.game.services.ProvideControllerPoolingService();
        }

        #endregion

        #region ICleanupSystem implementation

        void ICleanupSystem.Cleanup()
        {
            var entities = _destroyGroup.GetEntities();

            // Удалить все сущности
            for (int index = 0; index < entities.Length; index++)
            {
                var destroyed = entities[index];

                if (destroyed.hasViewController)
                {
                    _controllerPoolingService.Destroy(destroyed.viewController.controller);
                }

                destroyed.Destroy();
            }
        }

        #endregion
    }
}
