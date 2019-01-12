using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Контейнер сервисов
    /// </summary>
    public class ServicesContainer
    {
        #region Feilds

        /// <summary>
        /// Словарь с сервисами
        /// </summary>
        private Dictionary<string, IService>
            _dict = new Dictionary<string, IService>();

        #endregion

        #region Editor only

#if (UNITY_EDITOR)

        /// <summary>
        /// Используется только в редакторе, для мокания сервисов
        /// </summary>
        /// <typeparam name="TInterface">Тип интерфейса сервиса</typeparam>
        /// <typeparam name="TService">Тип мока сервиса</typeparam>
        /// <returns></returns>
        public ServicesContainer MockService<TInterface, TService>()
            where TService : TInterface, new()
            where TInterface : IService
        {
            return MockService<TInterface, TService>(new TService());
        }

        /// <summary>
        /// Используется только в редакторе, для мокания сервисов
        /// </summary>
        /// <typeparam name="TInterface">Тип интерфейса сервиса</typeparam>
        /// <typeparam name="TService">Тип мока сервиса</typeparam>
        /// <param name="serviceObject">Объект мока сервиса</param>
        /// <returns></returns>
        public ServicesContainer MockService<TInterface, TService>(TService serviceObject)
            where TService : TInterface
            where TInterface : IService
        {
            _dict.Add(GetTypeKey(typeof(TInterface)), serviceObject);

            return this;
        }

#endif

        #endregion

        #region Protected methods

        /// <summary>
        /// Получить сервис по его типу. Если это интерфейс сервиса, то тип берётся из <see cref="ServiceAttribute"/>.
        /// </summary>
        /// <typeparam name="T">Тип сервиса</typeparam>
        /// <returns>Объект сервиса</returns>
        protected T Provide<T>()
            where T : IService
        {
            var type = typeof(T);

            string key = GetTypeKey(type);

            IService service;

            if (_dict.TryGetValue(key, out service) == false)
            {
                if (type.IsInterface)
                {
                    var serviceAttribute = (ServiceAttribute)Attribute.GetCustomAttribute(type, typeof(ServiceAttribute));

                    if (serviceAttribute == null)
                    {
                        throw new ArgumentOutOfRangeException(string.Format("Service attribute for interface {0} not found", type.Name));
                    }

                    service = (IService)Activator.CreateInstance(serviceAttribute.ServiceType);
                }
                else
                {
                    service = (IService)Activator.CreateInstance(type);
                }

                if (service == null)
                {
                    throw new NullReferenceException(string.Format("Type {0} not implement IService", type.Name));
                }

                _dict.Add(key, service);
            }

            return (T)service;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Возвращает ключ типа сервиса
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns>Ключ</returns>
        private string GetTypeKey(Type type)
        {
            return type.FullName;
        }

        #endregion
    }
}