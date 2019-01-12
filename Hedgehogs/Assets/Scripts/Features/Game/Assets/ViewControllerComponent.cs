using Entitas;

namespace Assets.Scripts.Features.Game.Assets
{
    /// <summary>
    /// Компонент контроллера представления
    /// </summary>
    public sealed class ViewControllerComponent:IComponent
    {
        /// <summary>
        /// Композит со всеми контроллерами представления ассета
        /// </summary>
        public ViewControllerComposite controller;
    }
}