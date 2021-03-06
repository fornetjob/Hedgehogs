﻿using System;
using System.Collections.Generic;

namespace Assets.Scripts.Core
{
    /// <summary>
    /// Словарь для отложенной подгрузки элементов по требованию
    /// </summary>
    /// <typeparam name="TKey">Ключ</typeparam>
    /// <typeparam name="TValue">Тип элемента</typeparam>
    public sealed class WeakDictionary<TKey, TValue>
    {
        #region Fields

        /// <summary>
        /// Функция подгрузки при отсутствии элемента в словаре
        /// </summary>
        private Func<TKey, TValue>
            _loadNotExistFunc;

        /// <summary>
        /// Словарь с элементами
        /// </summary>
        private Dictionary<TKey, TValue>
            _dict = new Dictionary<TKey, TValue>();

        #endregion

        #region ctor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="loadNotExistFunc">Функция подгрузки при отсутствии элемента в словаре</param>
        public WeakDictionary(Func<TKey, TValue> loadNotExistFunc)
        {
            _loadNotExistFunc = loadNotExistFunc;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Добавить элемент
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Элемент</param>
        public void Add(TKey key, TValue value)
        {
            _dict.Add(key, value);
        }

        /// <summary>
        /// Получить элемент (при его отсутствии будет вызвана функция подгрузки <see cref="_loadNotExistFunc"/>)
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <returns>Элемент</returns>
        public TValue GetValue(TKey key)
        {
            TValue value;

            if (_dict.TryGetValue(key, out value) == false)
            {
                value = _loadNotExistFunc(key);

                Add(key, value);
            }

            return value;
        }

        #endregion
    }
}