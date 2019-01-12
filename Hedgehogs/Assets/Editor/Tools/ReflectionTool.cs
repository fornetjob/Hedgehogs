using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assets.Scripts.Editor.Tools
{
    /// <summary>
    /// Тул для работы с рефлексией типов
    /// </summary>
    public class ReflectionTool
    {
        /// <summary>
        /// Возвращает список полей, содержащих атрибут
        /// </summary>
        /// <typeparam name="TAttr">Тип атрибута</typeparam>
        /// <param name="type">Анализируемый тип</param>
        /// <returns>Списпок полей и их атрибутов</returns>
        public static List<KeyValuePair<FieldInfo, TAttr>> GetAllFields<TAttr>(Type type)
            where TAttr : System.Attribute
        {
            var fields = type.GetFields(
                    BindingFlags.Public
                    | BindingFlags.NonPublic
                    | BindingFlags.Instance);

            List<KeyValuePair<FieldInfo, TAttr>> result = new List<KeyValuePair<FieldInfo, TAttr>>();

            for (int i = 0; i < fields.Length; i++)
            {
                var field = fields[i];

                var attrs = field.GetCustomAttributes(typeof(TAttr), false);

                if (attrs.Length == 0)
                {
                    continue;
                }

                result.Add(new KeyValuePair<FieldInfo, TAttr>(field, (TAttr)attrs[0]));
            }

            return result;
        }
    }
}
