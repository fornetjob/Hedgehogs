using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Tools
{
    /// <summary>
    /// Тул для работы с файлами проекта
    /// </summary>
    public static class FileTool
    {
        /// <summary>
        /// Возвращает путь игры
        /// </summary>
        /// <returns></returns>
        private static string GetGamePath()
        {
            return Application.dataPath.Remove(Application.dataPath.LastIndexOf("Assets"));
        }

        /// <summary>
        /// Проверить что директория существует и создать, если не существует.
        /// </summary>
        /// <param name="assetPath">Директория в проекте</param>
        public static void CheckAssetDirectory(string assetPath)
        {
            string path = Path.Combine(GetGamePath(), assetPath);

            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Возврашщает все вложенные директории
        /// </summary>
        /// <param name="assetPath">Директория в проекте</param>
        /// <returns></returns>
        public static string[] GetAllDirectories(string assetPath)
        {
            string path = Path.Combine(GetGamePath(), assetPath);

            var exists = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);

            var newPaths = new List<string>();

            newPaths.Add(assetPath);

            foreach (var current in exists)
            {
                newPaths.Add(current.Replace(path, assetPath));
            }

            return newPaths.ToArray();
        }

        /// <summary>
        /// Загружает рекурсивно все ассеты указанного типа в директории
        /// </summary>
        /// <typeparam name="T">Тип</typeparam>
        /// <param name="assetPath">Директория в проекте</param>
        /// <returns></returns>
        public static T[] LoadAllAssetsAtPath<T>(string assetPath)
           where T : UnityEngine.Object
        {
            string path = Path.Combine(GetGamePath(), assetPath);

            var files = Directory.GetFiles(path).Select(p => new FileInfo(p)).ToList();

            List<T> items = new List<T>();

            foreach (var current in files)
            {
                var resourcePath = Path.Combine(assetPath, current.Name);

                if (typeof(T) == typeof(Sprite))
                {
                    foreach (var asset in AssetDatabase.LoadAllAssetsAtPath(resourcePath))
                    {
                        if (asset != null
                            && asset is T)
                        {
                            items.Add((T)asset);
                        }
                    }
                }
                else
                {
                    T asset = AssetDatabase.LoadAssetAtPath(resourcePath, typeof(T)) as T;

                    if (asset != null)
                    {
                        items.Add((T)asset);
                    }
                }
            }

            return items.ToArray();
        }
    }
}
