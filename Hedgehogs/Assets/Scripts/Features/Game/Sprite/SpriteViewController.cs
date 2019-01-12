using UnityEngine;

namespace Assets.Scripts.Features.Game.Sprite
{
    /// <summary>
    /// Контроллер спрайта
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteViewController : ViewControllerBase<ISpriteEntity>
    {
        #region Bindings

        /// <summary>
        /// Рендеринг спрайта
        /// </summary>
        [SerializeField]
        [Binding(".")]
        private SpriteRenderer
            _sprite = null;

        #endregion

        #region Overriden methods

        protected override void OnOpenController(ISpriteEntity projection)
        {
            _sprite.sortingOrder = projection.sprite.spriteSortingOrder;
        }

        #endregion
    }
}
