using Assets.Scripts.Editor.Tools;

using DesperateDevs.CodeGeneration;

using System.IO;
using System.Text;

using UnityEngine;

namespace Assets.Editor.CodeGenerators
{
    /// <summary>
    /// Генерация списка используемых в игре представлений <see cref="ViewPrefabs"/>
    /// </summary>
    public class ViewsCodeGenerator : ICodeGenerator
    {
        /// <summary>
        /// Имя генератора
        /// </summary>
        public string name
        {
            get
            {
                return "ViewsCodeGenerator";
            }
        }

        /// <summary>
        /// Приоритет генерации
        /// </summary>
        public int priority
        {
            get
            {
                return 0;
            }
        }

        bool ICodeGenerationPlugin.runInDryMode
        {
            get
            {
                return true;
            }
        }

        CodeGenFile[] ICodeGenerator.Generate(CodeGeneratorData[] data)
        {
            return new CodeGenFile[]
            {
                new CodeGenFile("ViewPrefabs.cs", GetCode<Component>("ViewPrefabs", "Assets/Resources/Views/"), name)
            };
        }

        private string GetCode<T>(string className, string prefabsPath)
            where T:Object
        {
            StringBuilder bulder = new StringBuilder();

            bulder.AppendLine("using UnityEngine;");
            bulder.AppendLine();

            bulder.AppendLine(string.Format("public static class {0}", className));
            bulder.AppendLine("{");

            string currentPath = 
                (prefabsPath.Replace("Assets/Resources/", string.Empty) + "/")
                .Replace("//", "/");

            string prefabsPathRenamed = prefabsPath.Replace("\\", "_").Replace("/", "_");

            StringBuilder allBuilder = new StringBuilder();

            foreach (var path in FileTool.GetAllDirectories(prefabsPath))
            {
                var dirName = new DirectoryInfo(path).FullName
                    .Replace("\\", "_").Replace("/", "_");

                var pathName = dirName
                    .Substring(dirName.LastIndexOf(prefabsPathRenamed) + prefabsPathRenamed.Length)
                    .Trim();

                if (string.IsNullOrEmpty(pathName) == false)
                {
                    pathName += "_";
                }

                foreach (var current in FileTool.LoadAllAssetsAtPath<T>(path))
                {
                    string prefabPropertyName = (pathName + current.name)
                        .Replace("/", "_").Replace("\\", "_");

                    bulder.AppendLine(string.Format("\tpublic const string {0} = \"{1}\";",
                        prefabPropertyName,
                        currentPath + pathName.Replace("_", "/") + current.name));

                    allBuilder.AppendLine(string.Format("\t\t{0},", prefabPropertyName));
                }
            }

            bulder.AppendLine(string.Format("\tpublic static readonly string[] All = new string[]"));
            bulder.AppendLine("\t{");
            bulder.Append(allBuilder);
            bulder.AppendLine("\t};");

            bulder.AppendLine("}");

            return bulder.ToString();
        }
    }
}
