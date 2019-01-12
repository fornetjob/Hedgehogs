using System;
using System.Collections.Generic;

using UnityEngine;

namespace Assets.Scripts.Editor.Tools
{
    /// <summary>
    /// Тул для работы с биндингами
    /// </summary>
    public static class BindingTool
    {
        /// <summary>
        /// Связывает поля компонента, помеченных <see cref="BindingAttribute"/>
        /// </summary>
        /// <param name="component">Компонент</param>
        /// <returns>Биндинги изменились</returns>
        public static bool CheckBindings(Component component)
        {
            bool isChanged = false;

            var parentTr = component.gameObject.GetComponent<Transform>();

            var type = component.GetType();

            var fields = ReflectionTool.GetAllFields<BindingAttribute>(type);

            for (int i = 0; i < fields.Count; i++)
            {
                var field = fields[i].Key;

                var mapAttr = fields[i].Value;

                Transform valueTr = null;

                string path = string.IsNullOrEmpty(mapAttr.Path) ? field.Name : mapAttr.Path;

                if (path.StartsWith("_"))
                {
                    path = path.Substring(1);
                    path = path[0].ToString().ToUpper() + path.Substring(1);
                }

                if (path.ToLower().Trim() == ".")
                {
                    valueTr = parentTr;
                }
                else
                {
                    valueTr = parentTr.Find(path);
                }

                if (valueTr == null)
                {
                    if (mapAttr.CanEmpty == false)
                    {
                        Debug.LogError("Field " + field.Name + " on path " + path + " not exists in " + type.Name + " for component " + component.name + " in " + component.gameObject.name);
                    }
                }
                else
                {
                    if (field.FieldType.IsArray)
                    {
                        var elementType = field.FieldType.GetElementType();

                        var existComponents = valueTr.GetComponentsInChildren(elementType, true);

                        List<Component> values = new List<Component>();

                        for (int j = 0; j < existComponents.Length; j++)
                        {
                            var comp = existComponents[j];

                            if (comp.transform != valueTr
                                && comp.CompareTag("IgnoreComponent") == false)
                            {
                                values.Add(comp);
                            }
                        }

                        if (values == null)
                        {
                            if (mapAttr.CanEmpty == false)
                            {
                                Debug.LogError("Component " + field.FieldType.Name + " in field " + field.Name + " on path " + path + " not exists in " + type.Name + " for component " + component.name + " in " + component.gameObject.name);
                            }
                        }
                        else
                        {
                            var arr = Array.CreateInstance(elementType, values.Count);
                            Array.Copy(values.ToArray(), arr, values.Count);

                            field.SetValue(component, arr);

                            isChanged = true;
                        }
                    }
                    else
                    {
                        var value = valueTr.GetComponent(field.FieldType);

                        if (value == null)
                        {
                            if (mapAttr.CanEmpty == false)
                            {
                                Debug.LogError("Component " + field.FieldType.Name + " in field " + field.Name + " on path " + path + " not exists in " + type.Name + " for component " + component.name + " in " + component.gameObject.name);
                            }
                        }
                        else
                        {
                            var currentValue = (Component)field.GetValue(component);

                            if (currentValue != value)
                            {
                                field.SetValue(component, value);

                                isChanged = true;
                            }
                        }
                    }
                }
            }

            return isChanged;
        }
    }
}