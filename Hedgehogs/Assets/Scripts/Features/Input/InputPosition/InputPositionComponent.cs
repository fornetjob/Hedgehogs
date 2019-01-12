using Entitas;
using Entitas.CodeGeneration.Attributes;

using UnityEngine;

namespace Assets.Scripts.Features.Input.InputPosition
{
    /// <summary>
    /// Компонент содержащий мировые координаты клика
    /// </summary>
    [Input]
    [Event(EventTarget.Self)]
    [Unique]
    public class InputPositionComponent : IComponent
    {
        public Vector2 worldPos;
    }
}