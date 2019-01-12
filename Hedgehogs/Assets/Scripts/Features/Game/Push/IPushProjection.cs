public partial class GameEntity : Assets.Scripts.Features.Game.Push.IPushProjection
{

}

namespace Assets.Scripts.Features.Game.Push
{
    /// <summary>
    /// Проекция данных выталкивания
    /// </summary>
    public interface IPushProjection : IPushEntity, IPushListenerEntity
    {
    }
}