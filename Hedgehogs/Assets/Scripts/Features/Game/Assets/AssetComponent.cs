using Entitas;

namespace Assets.Scripts.Features.Game.Assets
{
    /// <summary>
    /// Компонент ассета
    /// </summary>
    public sealed class AssetComponent:IComponent
    {
        /// <summary>
        /// Путь к ассету в папке Resources
        /// </summary>
        public string assetPath;
    }
}
