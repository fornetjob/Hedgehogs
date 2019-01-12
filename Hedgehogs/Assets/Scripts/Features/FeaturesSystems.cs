using Assets.Scripts.Core;
using Assets.Scripts.Features.Game;
using Assets.Scripts.Features.Game.Assets;
using Assets.Scripts.Features.Game.Destroy;
using Assets.Scripts.Features.Game.Push;
using Assets.Scripts.Features.Game.Updates;
using Assets.Scripts.Features.Input.InputPosition;
using Assets.Scripts.Features.Input.Services;

namespace Assets.Scripts.Features
{
    public sealed class FeaturesSystems: Feature
    {
        public FeaturesSystems(Contexts contexts)
        {
            // Input
            Add(new InputPositionSystem(contexts));

            // Game
            Add(new TaskSystem(contexts));
            Add(new AssetsSystem(contexts));
            Add(new PushSystem(contexts));

            // Events
            Add(new GameEventSystems(contexts));
            Add(new InputEventSystems(contexts));

            // Cleanup
            Add(new DestroySystem(contexts));
        }
    }
}