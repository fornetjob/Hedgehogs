using Assets.Scripts.Configs;
using Assets.Scripts.Features.Game.Character;
using Assets.Scripts.Features.Game.Services;
using Assets.Scripts.Tools;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Assets.Scripts.Features.Game.Push
{
    /// <summary>
    /// Система выталкивания
    /// </summary>
    public class PushSystem : IInitializeSystem, IInputPositionListener
    {
        #region Settings and constants

        /// <summary>
        /// Настройки персонажа
        /// </summary>
        private CharacterSettings CharacterSettings;
        /// <summary>
        /// Настройки выталкивания
        /// </summary>
        private PushSettings PushSettings;

        #endregion

        #region Services

        /// <summary>
        /// Сервис случайных чисел
        /// </summary>
        private RandomService
            _randomService;

        #endregion

        #region Fields

        /// <summary>
        /// Контекст
        /// </summary>
        private Contexts
            _context;

        /// <summary>
        /// Фабрика создания персонажей
        /// </summary>
        private CharacterFactory
            _characterFactory;

        #endregion

        #region ctor

        public PushSystem(Contexts context)
        {
            _context = context;

            _characterFactory = new CharacterFactory(_context.game);
        }

        #endregion

        #region IInitializeSystem implementation

        void IInitializeSystem.Initialize()
        {
            // слушаем изменение позиции
            _context.input.inputPositionEntity.AddInputPositionListener(this);

            _randomService = _context.game.services.ProvideRandomService();

            CharacterSettings = _context.game.services.ProvideConfigService().GetCharacterSettings();
            PushSettings = _context.game.services.ProvideConfigService().GetPushSettings();
        }

        #endregion

        #region IInputPositionListener implementation

        void IInputPositionListener.OnInputPosition(InputEntity entity, Vector2 worldPos)
        {
            var hittedCharacters = Physics2D.CircleCastAll(worldPos, PushSettings.RaycastRadius, Vector2.zero, 0, CharacterSettings.LayerMask);

            // Если по клику вокруг нет персонажей
            if (hittedCharacters.Length == 0)
            {
                // Добавляем персонажей в месте клика
                for (int i = 0; i < CharacterSettings.CreateCount; i++)
                {
                    var spiralPos = MathTool.GetSpiralPositionByIndex(i);

                    _characterFactory.Create(worldPos + spiralPos * CharacterSettings.Size.MaxValue * 2);
                }
            }
            else
            {
                // Иначе - выталкиваем персонажей
                for (int i = 0; i < hittedCharacters.Length; i++)
                {
                    var hittedCharacter = hittedCharacters[i];

                    var character = (GameEntity)hittedCharacter.collider.gameObject.GetEntityLink().entity;

                    var direction = new Vector2(_randomService.Range(-1f, 1f), 1);
                    var force = _randomService.Range(PushSettings.Force);

                    character.ReplacePush(direction, force);
                }
            }
        }

        #endregion
    }
}