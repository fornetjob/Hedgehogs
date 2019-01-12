using Assets.Scripts.Tools;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class LayerToolTest
{
    [Test]
    public static void GetEnabledLayers()
    {
        List<string> layerNames = new List<string>();

        int enabledLayersCount = Random.Range(1, 32);

        for (int i = 0; i < enabledLayersCount; i++)
        {
            var layer = LayerMask.LayerToName(i);

            if (string.IsNullOrEmpty(layer) == false)
            {
                layerNames.Add(layer);
            }
        }

        var layerMask = LayerMask.GetMask(layerNames.ToArray());

        var layers = LayersTool.GetEnabledLayers(layerMask);

        for (int i = 0; i < layerNames.Count; i++)
        {
            Assert.AreEqual(layerNames[i], LayerMask.LayerToName(layers[i]));
        }
    }
}