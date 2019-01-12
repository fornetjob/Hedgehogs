/// <summary>
/// Базовый интерфейс для контроллера представления
/// </summary>
public interface IViewController
{
    /// <summary>
    /// Вызывается один раз, при создании
    /// </summary>
    /// <param name="context">Контекст</param>
    void BeginController(Contexts context);
    /// <summary>
    /// Вызывается при открытии
    /// </summary>
    /// <param name="projection">Проекция данных</param>
    void OpenController(IEntityProjection projection);
    /// <summary>
    /// Вызывается при закрытии
    /// </summary>
    void CloseController();
}