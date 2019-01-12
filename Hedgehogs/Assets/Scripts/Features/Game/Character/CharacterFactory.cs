using Assets.Scripts.Configs;
using Assets.Scripts.Features.Game.Services;
using Assets.Scripts.Tools;

using UnityEngine;

namespace Assets.Scripts.Features.Game.Character
{
    /// <summary>
    /// Фабрика персонажей
    /// </summary>
    public sealed class CharacterFactory
    {
        #region Settings and constants

        /// <summary>
        /// Настройки персонажа
        /// </summary>
        private CharacterSettings CharacterSettings;

        #endregion

        #region Services;

        /// <summary>
        /// Cервис случайных чисел
        /// </summary>
        private RandomService
            _randomService;

        #endregion

        #region Fields

        /// <summary>
        /// Контекст
        /// </summary>
        private GameContext
           _context;

        /// <summary>
        /// Слои персонажа
        /// </summary>
        private int[]
            _characterLayers;

        #endregion

        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context">Контекст</param>
        public CharacterFactory(GameContext context)
        {
            _context = context;

            _randomService = _context.services.ProvideRandomService();

            CharacterSettings = _context.services.ProvideConfigService()
                .GetCharacterSettings();

            _characterLayers = LayersTool.GetEnabledLayers(CharacterSettings.LayerMask);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Создать персонажа
        /// </summary>
        /// <param name="pos">Позиция персонажа</param>
        /// <returns></returns>
        public GameEntity Create(Vector2 pos)
        {
            var characterEntity = _context.CreateEntity();

            int layerIndex = _randomService.Range(0, _characterLayers.Length);

            float size = _randomService.Range(CharacterSettings.Size);

            characterEntity.AddCharacter(pos, size, _characterLayers[layerIndex]);
            characterEntity.AddSprite(layerIndex);
            characterEntity.AddAsset(ViewPrefabs.Characters_Hedgehod);

            return characterEntity;
        }

        #endregion
    }
}
