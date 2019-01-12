using System;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Указывается у интерфейса для связывания его с сервисом
    /// </summary>
    [AttributeUsage(AttributeTargets.Interface)]
    public class ServiceAttribute: Attribute
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="serviceType">Тип сервиса, реализующего данный интерфейс</param>
        public ServiceAttribute(Type serviceType)
        {
            ServiceType = serviceType;
        }

        public Type ServiceType;
    }
}
