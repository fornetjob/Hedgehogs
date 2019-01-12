using Entitas;
using Entitas.Unity;

using UnityEngine;

/// <summary>
/// Базовый класс контроллера представления
/// </summary>
/// <typeparam name="TProjection">Тип проекции данных</typeparam>
public class ViewControllerBase<TProjection> : MonoBehaviour, IViewController
    where TProjection : IEntityProjection
{
    #region IView implementation

    void IViewController.BeginController(Contexts context)
    {
        OnBeginController(context);
    }

    void IViewController.OpenController(IEntityProjection projection)
    {
        OnOpenController((TProjection)projection);
    }

    void IViewController.CloseController()
    {
        OnCloseController();
    }

    #endregion

    #region Virtual methods

    /// <summary>
    /// Вызывается один раз, при создании контроллера представления
    /// </summary>
    /// <param name="context">Контекст</param>
    protected virtual void OnBeginController(Contexts context)
    {

    }

    /// <summary>
    /// Вызывается при открытии контроллера представления
    /// </summary>
    /// <param name="projection">Проекция данных</param>
    protected virtual void OnOpenController(TProjection projection)
    {

    }

    /// <summary>
    /// Вызывается при закрытии контроллера представления
    /// </summary>
    protected virtual void OnCloseController()
    {

    }

    #endregion
}