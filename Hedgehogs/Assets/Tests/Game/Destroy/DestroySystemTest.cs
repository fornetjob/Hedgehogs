using Assets.Scripts.Features.Game.Destroy;
using Entitas;
using NUnit.Framework;
using UnityEngine;

public class DestroySystemTest
{
    [Test]
    public void Destroy()
    {
        var context = new Contexts();
        var destroySystem = (ICleanupSystem)new DestroySystem(context);

        var entity1 = context.game.CreateEntity();
        var entity2 = context.game.CreateEntity();

        Assert.IsTrue(context.game.count == 2);

        entity1.isDestroy = true;

        destroySystem.Cleanup();

        Assert.IsTrue(context.game.count == 1);

        entity2.isDestroy = true;

        destroySystem.Cleanup();

        Assert.IsTrue(context.game.count == 0);
    }
}