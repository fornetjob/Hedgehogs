using Assets.Scripts.Core;
using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Editor.CustomPropertyDrawers
{
    /// <summary>
    /// Кастомный редактор типа <see cref="BetweenFloat"/>, помеченного <see cref="BetweenRangeAttribute"/>
    /// </summary>
    [CustomPropertyDrawer(typeof(BetweenRangeAttribute))]
    public class BetweenRangeDrawer: PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.type != typeof(BetweenFloat).Name)
            {
                EditorGUI.LabelField(position, label.text, "Use BetweenRange with BetweenFloat.");

                return;
            }

            var betweenRange = (BetweenRangeAttribute)attribute;

            var value = (BetweenFloat)fieldInfo.GetValue(property.serializedObject.targetObject);

            var minValue = (float)Math.Round(value.MinValue, betweenRange.Digits);
            var maxValue = (float)Math.Round(value.MaxValue, betweenRange.Digits);

            label.text += string.Format(" ({0}, {1})", minValue, maxValue);

            EditorGUI.MinMaxSlider(position, label, ref minValue, ref maxValue, betweenRange.MinValue, betweenRange.MaxValue);

            if (value.MinValue != minValue
                || value.MaxValue != maxValue)
            {
                value.MinValue = minValue;
                value.MaxValue = maxValue;

                property.serializedObject.Update();

                fieldInfo.SetValue(property.serializedObject.targetObject, value);

                EditorUtility.SetDirty(property.serializedObject.targetObject);

                property.serializedObject.ApplyModifiedPropertiesWithoutUndo();
            }
        }
    }
}
