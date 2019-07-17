using System;
using System.IO;
using System.Text;

namespace BlazorUtils.Cli.Utils
{
    internal static class CreateUtils
    {
        public static void CreateComponent(string name)
        {
            var componentDir = $"{Program.WorkingDir}\\Shared\\Components";
            var componentPath = $"{componentDir}\\{name}.razor";

            Directory.CreateDirectory(componentDir);

            if (File.Exists(componentPath))
            {
                Console.WriteLine($"Component {name} already exists");
                return;
            }

            Console.WriteLine($"Creating component {name}...");

            using (var stream = File.CreateText(componentPath))
            {
                stream.Write(Encoding.UTF8
                    .GetString(Properties.Resources.component)
                    .Replace("{0}", name));
            }
        }

        public static void CreatePage(string name)
        {
            var pageDir = $"{Program.WorkingDir}\\Pages";
            var pagePath = $"{pageDir}\\{name}.razor";

            Directory.CreateDirectory(pageDir);

            if (File.Exists(pagePath))
            {
                Console.WriteLine($"Page {name} already exists");
                return;
            }

            Console.WriteLine($"Creating page {name}...");

            using (var stream = File.CreateText(pagePath))
            {
                stream.Write(Encoding.UTF8
                    .GetString(Properties.Resources.page)
                    .Replace("{0}", name.ToLower())
                    .Replace("{1}", name));
            }
        }
    }
}
