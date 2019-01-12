using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Tools
{
    /// <summary>
    /// Тул для работы со слоями
    /// </summary>
    public static class LayersTool
    {
        /// <summary>
        /// Получить все включенные слои в маске
        /// </summary>
        /// <param name="layerMask">Маска</param>
        /// <returns></returns>
        public static int[] GetEnabledLayers(LayerMask layerMask)
        {
            List<int> layers = new List<int>();

            for (int i = 0; i < 32; i++)
            {
                if (layerMask == (layerMask | (1 << i)))
                {
                    layers.Add(i);
                }
            }

            return layers.ToArray();
        }
    }
}
