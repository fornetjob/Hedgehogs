using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections;

namespace Assets.Scripts.Features.Game.Updates
{
    /// <summary>
    /// Компонент заданий
    /// </summary>
    //[Event(EventTarget.Self)]
    public sealed class TaskComponent :IComponent
    {
        public IEnumerator Task;
    }
}