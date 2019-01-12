using System.IO;
using System.Linq;

using DesperateDevs.CodeGeneration;

using Entitas;
using Entitas.CodeGeneration.Plugins;

namespace Assets.Editor.CodeGenerators
{
    /// <summary>
    /// Генерация проекций данных
    /// </summary>
    public class ComponentAllEntityApiInterfaceGenerator : AbstractGenerator
    {
        /// <summary>
        /// Имя генератора
        /// </summary>
        public override string name { get { return "Component (All Entity API Interface)"; } }


        const string ListenerTemplate =
@"
    void Add${EventListener}(I${EventListener} value);
    void Remove${EventListener}(I${EventListener} value, bool removeComponentWhenEmpty = true);";

        const string STANDARD_TEMPLATE =
            @"public partial interface I${ComponentName}Entity:IEntityProjection {
    ${ComponentType} ${validComponentName} { get; }
    bool has${ComponentName} { get; }
    void Add${ComponentName}(${newMethodParameters});
    void Replace${ComponentName}(${newMethodParameters});
    void Remove${ComponentName}();
    ${ListenerMethod}
}
";

        const string FLAG_TEMPLATE =
            @"public partial interface I${ComponentName}Entity:IEntityProjection {
    bool ${prefixedComponentName} { get; set; }
}
";

        const string ENTITY_INTERFACE_TEMPLATE = "public partial class ${EntityType} : I${ComponentName}Entity { }\n";

        /// <summary>
        /// Сгенерировать проекции данных
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CodeGenFile[] Generate(CodeGeneratorData[] data)
        {
            return data
                .OfType<ComponentData>()
                .Where(d => d.ShouldGenerateMethods())
                .SelectMany(generate)
                .ToArray();
        }

        CodeGenFile[] generate(ComponentData data)
        {
            return new[] { generateInterface(data) }
                .Concat(data.GetContextNames().Select(contextName => generateEntityInterface(contextName, data)))
                .ToArray();
        }

        CodeGenFile generateInterface(ComponentData data)
        {
            var template = data.GetMemberData().Length == 0
                ? FLAG_TEMPLATE
                : STANDARD_TEMPLATE;

            if (data.ComponentName().EndsWith("Listener"))
            {
                template = template.Replace("${ListenerMethod}", 
                    ListenerTemplate.Replace("${EventListener}", data.ComponentName()));
            }
            else
            {
                template = template.Replace("${ListenerMethod}", string.Empty);
            }

            return new CodeGenFile(
                "Components" + Path.DirectorySeparatorChar +
                "Interfaces" + Path.DirectorySeparatorChar +
                "I" + data.ComponentName() + "Entity.cs",
                template.Replace(data, string.Empty),
                GetType().FullName
            );
        }

        CodeGenFile generateEntityInterface(string contextName, ComponentData data)
        {
            return new CodeGenFile(
                contextName + Path.DirectorySeparatorChar +
                "Components" + Path.DirectorySeparatorChar +
                data.ComponentNameWithContext(contextName).AddComponentSuffix() + ".cs",
                ENTITY_INTERFACE_TEMPLATE.Replace(data, contextName),
                GetType().FullName
            );
        }
    }
}
