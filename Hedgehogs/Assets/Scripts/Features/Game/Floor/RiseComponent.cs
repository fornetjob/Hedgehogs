using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Assets.Scripts.Features.Game.Floor
{
    /// <summary>
    /// Компонент указывающий, что сущности требуется восстановление вертикального положения
    /// </summary>
    [Event(EventTarget.Self)]
    public class RiseComponent:IComponent
    {
    }
}
