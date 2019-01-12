using Entitas;
using UnityEngine;

namespace Assets.Scripts.Features.Game.Character
{
    /// <summary>
    /// Компонент персонажа
    /// </summary>
    public sealed class CharacterComponent:IComponent
    {
        /// <summary>
        /// Начальная позиция персонажа
        /// </summary>
        public Vector2 position;
        /// <summary>
        /// Размер персонажа
        /// </summary>
        public float size;
        /// <summary>
        /// Слой персонажа
        /// </summary>
        public int objectLayer;
    }
}