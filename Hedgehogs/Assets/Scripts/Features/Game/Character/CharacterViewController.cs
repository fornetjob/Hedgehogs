using UnityEngine;

namespace Assets.Scripts.Features.Game.LayerPosition
{
    /// <summary>
    /// Контроллер персонажа
    /// </summary>
    public sealed class CharacterViewController :ViewControllerBase<ICharacterEntity>
    {
        #region Bindings

        /// <summary>
        /// Механизм трансформации
        /// </summary>
        [SerializeField]
        [Binding(".")]
        private Transform
            _tr = null;

        #endregion

        #region Overriden methods

        protected override void OnOpenController(ICharacterEntity projection)
        {
            // Инициализировать состояние персонажа
            _tr.position = projection.character.position;
            _tr.localScale = Vector3.one * projection.character.size;
            _tr.rotation = Quaternion.identity;

            gameObject.layer = projection.character.objectLayer;
        }

        #endregion
    }
}