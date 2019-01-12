using Assets.Scripts.Features.Game.Services;

public class MockGameTimeService : IGameTimeService
{
    public float GetDeltaTime()
    {
        return 1f;
    }
}