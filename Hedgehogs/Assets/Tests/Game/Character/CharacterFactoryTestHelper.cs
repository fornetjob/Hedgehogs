using Assets.Scripts.Features.Game.Assets;
using Assets.Scripts.Features.Game.Character;

using NUnit.Framework;
using UnityEngine;

public static class CharacterFactoryTestHelper
{
    public static GameEntity CreateCharacterView(Contexts context)
    {
        return CreateCharacterView(context, Vector2.zero);
    }

    public static GameEntity CreateCharacterView(Contexts context, Vector2 pos)
    {
        var characterFactory = new CharacterFactory(context.game);

        var assetsSystem = new AssetsSystem(context);

        var entity = characterFactory.Create(pos);

        Assert.IsTrue(entity.hasAsset);
        Assert.IsFalse(entity.hasViewController);

        assetsSystem.Execute();

        return entity;
    }
}