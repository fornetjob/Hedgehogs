using Assets.Scripts.Core;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    /// <summary>
    /// Настройки "выталкивания" персонажей 
    /// </summary>
    public class PushSettings:ScriptableObject
    {
        /// <summary>
        /// Радиус клика
        /// </summary>
        [Tooltip("Радиус клика")]
        [Range(0.1f, 1f)]
        public float RaycastRadius = 0.3f;

        /// <summary>
        /// Интервал силы выталкивания персонажей
        /// </summary>
        [Tooltip("Интервал силы выталкивания персонажей")]
        [BetweenRange(20f, 100f, 0)]
        public BetweenFloat Force = new BetweenFloat(20, 60);
    }
}