using Assets.Scripts.Features.Input.Services;
using UnityEngine;

public class MockInputService : IInputService
{
    private int
        _clickIndex;

    private Vector2[]
        _positions;

    public MockInputService(Vector2[] positions)
    {
        _clickIndex = -1;

        _positions = positions;
    }

    public Vector2 GetScreenPosition()
    {
        if (_clickIndex >= _positions.Length)
        {
            return Vector2.zero;
        }

        return _positions[_clickIndex];
    }

    public bool IsMouseDown()
    {
        _clickIndex++;

        return _clickIndex < _positions.Length;
    }
}