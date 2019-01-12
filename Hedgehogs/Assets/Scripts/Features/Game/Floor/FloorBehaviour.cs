using Assets.Scripts.Core;
using Entitas.Unity;

using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Features.Game.Floor
{
    /// <summary>
    /// Отслеживает коллизии ёжиков с полом и инициирует их переворот на ножки.
    /// Так как слоёв ёжиков много и они должны взаимодействовать друг с другом, выгодней отслеживать колизии пола с ёжиками, а не ёжиков друг с другом и полом.
    /// </summary>
    public class FloorBehaviour : MonoBehaviour
    {
        #region Settings and constants

        /// <summary>
        /// Пороговое значение скорости, при которой начинаем переворачивать ёжиков
        /// </summary>
        private const float StopVelocityPrecission = 0.15f;
        /// <summary>
        /// Пороговое значение угла, при котором начинаем переворачивать ёжиков
        /// </summary>
        private const float RiseAnglePrecission = 1;

        #endregion

        #region Fields

        /// <summary>
        /// Список твёрдых тел, лежащих на полу
        /// </summary>
        private List<Rigidbody2D>
            _rbs = new List<Rigidbody2D>();

        /// <summary>
        /// Текущее исследуемое твёрдое тело
        /// </summary>
        private int
            _currentIndex;

        #endregion

        #region Messages

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_rbs.Contains(collision.rigidbody) == false)
            {
                _rbs.Add(collision.rigidbody);
            }
        }

        private void Update()
        {
            if (_rbs.Count > 0)
            {
                if (_currentIndex >= _rbs.Count)
                {
                    _currentIndex = 0;
                }

                var rb = _rbs[_currentIndex];

                // Если тело не двигается и требует поворота
                if (rb.velocity.magnitude < StopVelocityPrecission
                    && Mathf.Abs(rb.rotation) > RiseAnglePrecission)
                {
                    var entity = (GameEntity)rb.gameObject.GetEntityLink().entity;

                    if (entity == null)
                    {
                        _rbs.Remove(rb);

                        return;
                    }
                    else
                    {
                        // Поставить задачу на поворот
                        entity.isRise = true;
                    }
                }

                _currentIndex++;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _rbs.Remove(collision.rigidbody);
        }

        #endregion
    }
}