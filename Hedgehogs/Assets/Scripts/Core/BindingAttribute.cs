using System;
using UnityEngine;

/// <summary>
/// Биндинг компонентов ("." для получения компонента текущего объекта, если путь пустой, то берётся объект по имени поля)
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class BindingAttribute : PropertyAttribute
{
    /// <summary>
    /// Получить компонент, взяв в качестве пути к объекту имя поля
    /// </summary>
    public BindingAttribute()
        : this(string.Empty)
    {

    }

    /// <summary>
    /// Получить компонент объекта
    /// </summary>
    /// <param name="path">Путь к объекту</param>
    public BindingAttribute(string path)
    {
        Path = path;
    }

    /// <summary>
    /// Путь к объекту
    /// </summary>
    public string Path;
    /// <summary>
    /// Отсутствие компонента является допустимым
    /// </summary>
    public bool CanEmpty;
}