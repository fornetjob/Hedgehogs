using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Assets.Scripts.Features.Game.Push
{
    /// <summary>
    /// Компонент выталкивания
    /// </summary>
    [Event(EventTarget.Self)]
    public sealed class PushComponent:IComponent
    {
        /// <summary>
        /// Направление выталкивания
        /// </summary>
        public Vector2 direction;
        /// <summary>
        /// Сила выталкивания
        /// </summary>
        public float force;
    }
}
