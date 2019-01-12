using Assets.Scripts.Core;
using Assets.Scripts.Editor.Tools;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.CustomPropertyDrawers
{
    /// <summary>
    /// Кастомный редактор полей компонентов, помеченных <see cref="BindingAttribute"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(BindingAttribute))]
    public class BindingDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            if (property.objectReferenceValue == null)
            {
                return EditorGUI.GetPropertyHeight(property, label, true);
            }

            return 0;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Если компонент был установлен верно - не показываем его в инспекторе
            // Так как по своей сути это поле только для просмотра и не должно изменяться в инспекторе
            if (property.objectReferenceValue == null)
            {
                GUI.enabled = false;

                EditorGUI.PropertyField(position, property, label, true);
                GUI.enabled = true;
            }
        }

        /// <summary>
        /// Перегрузить биндинги после перегрузки скриптов
        /// </summary>
        [UnityEditor.Callbacks.DidReloadScripts]
        private static void OnScriptsReloaded()
        {
            var allComponents = Resources.FindObjectsOfTypeAll<Component>();

            foreach (var current in allComponents)
            {
                // Если маппинги были изменены - пометим объект как изменённый
                if (BindingTool.CheckBindings(current))
                {
                    EditorUtility.SetDirty(current.gameObject);
                }
            }

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }
}
