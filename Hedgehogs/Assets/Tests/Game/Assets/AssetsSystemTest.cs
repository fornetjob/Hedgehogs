using Assets.Scripts.Features.Game.Assets;
using Assets.Scripts.Features.Game.Character;
using Assets.Scripts.Features.Game.Destroy;
using Entitas;
using NUnit.Framework;
using UnityEngine;

public class AssetsSystemTest
{
    [Test]
    public void AddView()
    {
        var context = new Contexts();

        var gameEntity = CharacterFactoryTestHelper.CreateCharacterView(context);

        Assert.IsTrue(gameEntity.hasAsset);
        Assert.IsTrue(gameEntity.hasViewController);
    }

    [Test]
    public void DestroyView()
    {
        var context = new Contexts();

        var destroySystem = (ICleanupSystem)new DestroySystem(context);

        var character = CharacterFactoryTestHelper.CreateCharacterView(context);

        character.isDestroy = true;

        destroySystem.Cleanup();

        Assert.IsTrue(context.game.count == 0); 
    }
}