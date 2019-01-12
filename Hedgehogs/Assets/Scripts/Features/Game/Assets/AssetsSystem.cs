using System.Collections.Generic;

using Assets.Scripts.Core;
using Assets.Scripts.Features.Game.Services;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Features.Game.Assets
{
    /// <summary>
    /// Система для добавления контроллеров представления ассетов
    /// </summary>
    public sealed class AssetsSystem : ReactiveSystem<GameEntity>
    {
        #region Services

        private ControllerPoolingService
            _controllerPoolingService;

        #endregion

        #region Fields

        /// <summary>
        /// Контекст
        /// </summary>
        private Contexts
            _context;

        #endregion

        #region ctor

        public AssetsSystem(Contexts context) 
            : base(context.game)
        {
            _context = context;

            _controllerPoolingService = context.game.services.ProvideControllerPoolingService();
        }

        #endregion

        #region Overriden methods

        protected override bool Filter(GameEntity entity)
        {
            // Только те сущности, у которых установлен путь к ассетам, но отсутствует контроллеры представления
            return entity.hasAsset
                && entity.hasViewController == false;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            // Добавление контроллеров представления
            for (int i = 0; i < entities.Count; i++)
            {
                var entity = entities[i];

                entity.AddViewController(_controllerPoolingService
                    .Create(_context, entity.asset.assetPath, entity));
            }
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Asset);
        }

        #endregion
    }
}