using Entitas;

namespace Assets.Scripts.Features.Game.Sprite
{
    /// <summary>
    /// Компонент спрайта
    /// </summary>
    public class SpriteComponent:IComponent
    {
        /// <summary>
        /// Слой спрайта
        /// </summary>
        public int spriteSortingOrder;
    }
}
