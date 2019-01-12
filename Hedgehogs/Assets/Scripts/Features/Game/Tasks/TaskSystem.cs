using System.Collections.Generic;

using Entitas;

namespace Assets.Scripts.Features.Game.Updates
{
    /// <summary>
    /// Система заданий
    /// Чтобы начать задание, необходимо его добавить с помощью AddUpdate.
    /// Чтобы прекратить выполнение задания, необходимо вызвать RemoveUpdate.
    /// </summary>
    public sealed class TaskSystem : IExecuteSystem
    {
        #region Fields

        private IGroup<GameEntity>
            _taskEntities;

        #endregion

        #region ctor

        public TaskSystem(Contexts context)
        {
            _taskEntities = context.game.GetGroup(GameMatcher.Task);
        }

        #endregion

        #region IExecuteSystem implementation

        public void Execute()
        {
            var entities = _taskEntities.GetEntities();

            for (int i = 0; i < entities.Length; i++)
            {
                var entity = entities[i];

                if (entity.task.Task.MoveNext() == false)
                {
                    entity.RemoveTask();
                }
            }
        }

        #endregion
    }
}