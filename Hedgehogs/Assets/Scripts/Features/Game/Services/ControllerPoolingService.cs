using Assets.Scripts.Core;
using Assets.Scripts.Features.Game.Assets;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Features.Game.Services
{
    /// <summary>
    /// Пулинг контроллеров
    /// </summary>
    public class ControllerPoolingService:IService
    {
        #region Fields

        /// <summary>
        /// Префабы
        /// </summary>
        private WeakDictionary<string, GameObject>
            _viewPrefabs = new WeakDictionary<string, GameObject>(path => Resources.Load<GameObject>(path));

        /// <summary>
        /// Уничтоженные контроллеры
        /// </summary>
        private Dictionary<string, Queue<ViewControllerComposite>>
            _destroyed = new Dictionary<string, Queue<ViewControllerComposite>>();

        #endregion

        #region Public methods

        /// <summary>
        /// Создать контроллер
        /// </summary>
        /// <param name="context">Контекст</param>
        /// <param name="viewPath">Путь к вью</param>
        /// <param name="projection">Проекция данных</param>
        /// <returns></returns>
        public ViewControllerComposite Create(Contexts context, string viewPath, IEntityProjection projection)
        {
            Queue<ViewControllerComposite> queue;

            if (_destroyed.TryGetValue(viewPath, out queue) == false)
            {
                queue = new Queue<ViewControllerComposite>();

                _destroyed.Add(viewPath, queue);
            }

            ViewControllerComposite viewController;

            if (queue.Count == 0)
            {
                var viewPrefab = _viewPrefabs.GetValue(viewPath);

                var viewObj = GameObject.Instantiate(viewPrefab);

                var viewControllers = viewObj.GetComponentsInChildren<IViewController>(true);

                viewController = new ViewControllerComposite(viewPath, viewObj, viewControllers);

                viewController.BeginController(context);
            }
            else
            {
                viewController = queue.Dequeue();
            }

            viewController.OpenController(projection);

            return viewController;
        }

        /// <summary>
        /// Удалить контроллер
        /// </summary>
        /// <param name="viewController">Контроллер к удалению</param>
        public void Destroy(ViewControllerComposite viewController)
        {
            viewController.CloseController();

            _destroyed[viewController.ViewPath].Enqueue(viewController);
        }

        #endregion
    }
}
