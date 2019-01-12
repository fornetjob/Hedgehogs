using Entitas;
using Entitas.Unity;

using UnityEngine;

namespace Assets.Scripts.Features.Game.Assets
{
    /// <summary>
    /// Композит контроллера представлений
    /// </summary>
    public sealed class ViewControllerComposite : IViewController
    {
        #region Fields

        /// <summary>
        /// Рутовый объект ассета
        /// </summary>
        private GameObject
            _viewObj;

        /// <summary>
        /// Контролеры представления ассета
        /// </summary>
        private IViewController[]
            _viewControllers;

        #endregion

        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="viewPath">Путь к ассету</param>
        /// <param name="viewObj">Рутовый объект ассета</param>
        /// <param name="viewControllers">Контролеры представления ассета</param>
        public ViewControllerComposite(string viewPath, GameObject viewObj, IViewController[] viewControllers)
        {
            ViewPath = viewPath;
            _viewObj = viewObj;
            _viewControllers = viewControllers;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Путь к ассету
        /// </summary>
        public string ViewPath;

        #endregion

        #region Public methods

        /// <summary>
        /// Возвращает все контролеры представления ассета
        /// </summary>
        /// <returns></returns>
        public IViewController[] GetViews()
        {
            return _viewControllers;
        }

        /// <summary>
        /// Вызывается один раз, при создании контроллера представления
        /// </summary>
        /// <param name="context">Контекст</param>
        public void BeginController(Contexts context)
        {
            for (int i = 0; i < _viewControllers.Length; i++)
            {
                _viewControllers[i].BeginController(context);
            }
        }

        /// <summary>
        /// Вызывается при открытии контроллера представления
        /// </summary>
        /// <param name="projection">Проекция данных</param>
        public void OpenController(IEntityProjection projection)
        {
            if (_viewObj.activeSelf == false)
            {
                _viewObj.SetActive(true);
            }

            // Присоединим сущность к объекту
            _viewObj.Link((IEntity)projection);

            for (int i = 0; i < _viewControllers.Length; i++)
            {
                _viewControllers[i].OpenController(projection);
            }
        }

        /// <summary>
        /// Вызывается при закрытии контроллера представления
        /// </summary>
        public void CloseController()
        {
            for (int i = 0; i < _viewControllers.Length; i++)
            {
                _viewControllers[i].CloseController();
            }

            // Отсоединим сущность от объекта
            _viewObj.Unlink();

            _viewObj.SetActive(false);
        }

        #endregion
    }
}