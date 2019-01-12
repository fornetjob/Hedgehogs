using Assets.Scripts.Core;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    /// <summary>
    /// Настройки создания персонажей
    /// </summary>
    public sealed class CharacterSettings:ScriptableObject
    {
        /// <summary>
        /// Слои персонажей
        /// </summary>
        [Tooltip("Слои персонажей")]
        public LayerMask LayerMask;

        /// <summary>
        /// Количество создаваемых при клике персонажей
        /// </summary>
        [Tooltip("Количество создаваемых при клике персонажей")]
        [Range(1, 50)]
        public int CreateCount = 1;

        /// <summary>
        /// Скорость переворачивания персонажа на ножки
        /// </summary>
        [Tooltip("Скорость переворачивания персонажа на ножки")]
        [Range(100f, 1000f)]
        public float RisingSpeed = 300f;

        /// <summary>
        /// Интервал размера создаваемых персонажей
        /// </summary>
        [Tooltip("Интервал размера создаваемых персонажей")]
        [BetweenRange(0.1f, 1f)]
        public BetweenFloat Size = new BetweenFloat(0.1f, 1);
    }
}
