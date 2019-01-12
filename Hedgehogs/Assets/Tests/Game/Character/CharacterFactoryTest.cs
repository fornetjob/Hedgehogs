using Assets.Scripts.Features.Game.Assets;
using Assets.Scripts.Features.Game.Character;
using NUnit.Framework;
using UnityEngine;

using System.Linq;
using Assets.Scripts.Features.Game.LayerPosition;
using Assets.Scripts.Features.Game.Push;
using Assets.Scripts.Features.Game.Floor;
using Assets.Scripts.Features.Game.Sprite;

public class CharacterFactoryTest
{
    [Test]
    public void Create()
    {
        var context = new Contexts();

        var character = CharacterFactoryTestHelper.CreateCharacterView(context);

        Assert.IsTrue(character.hasViewController);

        var views = character.viewController.controller.GetViews();

        Assert.IsTrue(views.OfType<CharacterViewController>().Count() == 1);
        Assert.IsTrue(views.OfType<PushViewController>().Count() == 1);
        Assert.IsTrue(views.OfType<RiseViewController>().Count() == 1);
        Assert.IsTrue(views.OfType<SpriteViewController>().Count() == 1);

        Assert.IsTrue(views.Length == 4);
    }
}
