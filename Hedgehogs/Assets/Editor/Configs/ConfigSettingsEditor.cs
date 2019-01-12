using Assets.Scripts.Configs;
using Assets.Scripts.Editor.Tools;

using System.IO;

using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.Configs
{
    /// <summary>
    /// Редактор конфигураций проекта
    /// </summary>
    public class ConfigSettingsEditor
    {
        /// <summary>
        /// Добавить конфигурацию настроек персонажа
        /// </summary>
        [MenuItem("Assets/Create/Configs/CharacterSettings")]
        public static void CreateCharacterSettings()
        {
            CreateConfigAsset<CharacterSettings>();
        }

        /// <summary>
        /// Добавить конфигурацию выталкивания
        /// </summary>
        [MenuItem("Assets/Create/Configs/PushSettings")]
        public static void CreatePushSettings()
        {
            CreateConfigAsset<PushSettings>();
        }

        /// <summary>
        /// Добавить конфигурацию по пути Resources\Configs\
        /// </summary>
        /// <typeparam name="T">Тип конфигурации</typeparam>
        private static void CreateConfigAsset<T>()
            where T : ScriptableObject
        {
            T asset = ScriptableObject.CreateInstance<T>();

            string directory = @"Assets\Resources\Configs\";

            FileTool.CheckAssetDirectory(directory);

            AssetDatabase.CreateAsset(asset, Path.Combine(directory, typeof(T).Name + ".asset"));

            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}
