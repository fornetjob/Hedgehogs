using Assets.Scripts.Features.Input.InputPosition;
using Assets.Scripts.Features.Input.Services;

using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemTest:IInputPositionListener
{
    private Stack<Vector2>
        _checkValuesStack = new Stack<Vector2>();

    [Test]
    public void CheckInputSubscription()
    {
        var context = new Contexts();

        List<Vector2> testValues = new List<Vector2>();
        List<Vector2> checkValues = new List<Vector2>();

        var count = Random.Range(1, 20);

        var mainCamera = Camera.main;

        for (int i = 0; i < count; i++)
        {
            var pos = new Vector3(Random.Range(-100, 100), Random.Range(-100, 100));

            testValues.Add(pos);

            pos[2] = 10;

            checkValues.Add(mainCamera.ScreenToWorldPoint(pos));
        }

        for (int i = checkValues.Count - 1; i >= 0; i--)
        {
            _checkValuesStack.Push(checkValues[i]);
        }

        context.input.services.MockService<IInputService, MockInputService>(
            new MockInputService(testValues.ToArray()));

        var inputSystem = new InputPositionSystem(context);
        var inputEventsSystem = new InputEventSystems(context);

        context.input.inputPositionEntity.AddInputPositionListener(this);

        for (int i = 0; i < testValues.Count; i++)
        {
            inputSystem.Execute();
            inputEventsSystem.Execute();
        }

        Assert.AreEqual(_checkValuesStack.Count, 0);
    }

    void IInputPositionListener.OnInputPosition(InputEntity entity, Vector2 worldPos)
    {
        var checkPos = _checkValuesStack.Pop();

        Assert.AreEqual(checkPos, worldPos);
    }
}