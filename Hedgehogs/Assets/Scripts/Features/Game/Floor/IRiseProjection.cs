public partial class GameEntity : Assets.Scripts.Features.Game.Floor.IRiseProjection
{

}

namespace Assets.Scripts.Features.Game.Floor
{
    /// <summary>
    /// Проекция данных для восстановления вертикального положения
    /// </summary>
    public interface IRiseProjection: IRiseEntity, IRiseListenerEntity, ITaskEntity, IDestroyEntity
    {
    }
}
