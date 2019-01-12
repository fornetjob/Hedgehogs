using Assets.Scripts.Editor.Tools;
using Assets.Scripts.Features.Game.Floor;
using Assets.Scripts.Features.Game.Services;
using Assets.Scripts.Features.Game.Updates;
using NUnit.Framework;
using System;
using UnityEngine;

public class RisingViewControllerTest
{
    [Test]
    public void Rising()
    {
        var context = new Contexts();

        context.game.services.MockService<IGameTimeService, MockGameTimeService>();

        var gameEventSystems = new GameEventSystems(context);
        var taskSystem = new TaskSystem(context);

        var gameEntity = context.game.CreateEntity();

        var viewControllerObj = new GameObject("TestRisingViewController");

        viewControllerObj.AddComponent<CircleCollider2D>();

        var risingViewController = viewControllerObj.AddComponent<RiseViewController>();

        BindingTool.CheckBindings(risingViewController);

        var viewController = (IViewController)risingViewController;

        viewController.BeginController(context);
        viewController.OpenController(gameEntity);

        var rb = viewControllerObj.GetComponent<Rigidbody2D>();

        Assert.IsNotNull(rb);

        rb.rotation = UnityEngine.Random.Range(-3000, 3000);

        gameEntity.isRise = true;

        gameEventSystems.Execute();

        Assert.IsTrue(gameEntity.hasTask);

        int tryCount = 4000;

        while (gameEntity.hasTask
            && --tryCount > 0)
        {
            taskSystem.Execute();

            gameEventSystems.Execute();
        }

        Assert.IsTrue(Math.Abs(rb.rotation) <= Mathf.Epsilon);
        Assert.IsFalse(gameEntity.hasTask);
    }
}