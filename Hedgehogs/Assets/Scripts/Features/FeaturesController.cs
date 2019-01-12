using Entitas;
using UnityEngine;

namespace Assets.Scripts.Features
{
    /// <summary>
    /// Контроллер игровых фич
    /// </summary>
    public class FeaturesController : MonoBehaviour
    {
        #region Fields

        /// <summary>
        /// Зарегестрированные системы
        /// </summary>
        private Systems
            _systems;

        #endregion

        #region Game

        void Awake()
        {
            _systems = new FeaturesSystems(Contexts.sharedInstance);
        }

        void Start()
        {
            _systems.Initialize();
        }

        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        void OnDestroy()
        {
            _systems.TearDown();
        }

        #endregion
    }
}
