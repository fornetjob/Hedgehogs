using Assets.Scripts.Configs;
using Assets.Scripts.Core;

using UnityEngine;

namespace Assets.Scripts.Features.Game.Services
{
    /// <summary>
    /// Сервис конфигураций
    /// </summary>
    public sealed class ConfigService : IService
    {
        #region Fields

        /// <summary>
        /// Словарь с конфигурациями
        /// </summary>
        private WeakDictionary<string, ScriptableObject>
            _configs = new WeakDictionary<string, ScriptableObject>(path => Resources.Load<ScriptableObject>(path));

        #endregion

        #region Public methods

        /// <summary>
        /// Получить конфигурацию персонажей
        /// </summary>
        /// <returns></returns>
        public CharacterSettings GetCharacterSettings()
        {
            return GetSettings<CharacterSettings>();
        }

        /// <summary>
        /// Получить конфигурацию выталкивания
        /// </summary>
        /// <returns></returns>
        public PushSettings GetPushSettings()
        {
            return GetSettings<PushSettings>();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Возвращает находящиеся по пути Resources/Configs/ конфигурации
        /// </summary>
        /// <typeparam name="T">Тип конфигурации</typeparam>
        /// <returns></returns>
        private T GetSettings<T>()
            where T:ScriptableObject
        {
            return (T)_configs.GetValue(string.Format("Configs/{0}", typeof(T).Name));
        }

        #endregion
    }
}
