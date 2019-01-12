using Assets.Scripts.Tools;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public static class MathToolTest
{
    [Test]
    public static void GetSpiralPositionByIndex()
    {
        int spiralLenght = Random.Range(1, 320);

        var prevIndex = MathTool.GetSpiralPositionByIndex(0);

        for (int i = 1; i < spiralLenght; i++)
        {
            var currIndex = MathTool.GetSpiralPositionByIndex(i);

            Assert.IsTrue(Mathf.Abs(currIndex.x - prevIndex.x) <= 1);
            Assert.IsTrue(Mathf.Abs(currIndex.y - prevIndex.y) <= 1);

            prevIndex = currIndex;
        }
    }
}