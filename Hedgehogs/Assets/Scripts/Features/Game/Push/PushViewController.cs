using UnityEngine;

namespace Assets.Scripts.Features.Game.Push
{
    /// <summary>
    /// Контроллер выталкивания
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public sealed class PushViewController:ViewControllerBase<IPushProjection>, IPushListener
    {
        #region Bindings

        /// <summary>
        /// Твёрдое тело персонажа
        /// </summary>
        [Binding(".")]
        [SerializeField]
        private Rigidbody2D
            _rb = null;

        /// <summary>
        /// Аниматор персонажа (для анимации выталкивания)
        /// </summary>
        [Binding(".")]
        [SerializeField]
        private Animator
            _anim = null;

        #endregion

        #region Overriden

        protected override void OnOpenController(IPushProjection projection)
        {
            // Подпишемся на событие выталкивания
            projection.AddPushListener(this);
        }

        #endregion

        #region IPushListener implementation

        void IPushListener.OnPush(GameEntity entity, Vector2 direction, float force)
        {
            // Применим силу выталкивания и проиграем анимацию
            _rb.AddForce(direction * force, ForceMode2D.Impulse);

            _anim.Play("Push");
        }

        #endregion
    }
}
