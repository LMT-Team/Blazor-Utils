using BlazorUtils.Cli.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BlazorUtils.Cli.Utils
{
    internal static class ImportUtils
    {
        public static void ImportPackage(IEnumerable<ImportOptions.IncludedPackage> packages, bool IsPrerelease)
        {
            //Find project file
            if (!Directory.EnumerateFiles(Program.WorkingDir, "*.csproj").Any())
            {
                Console.WriteLine("Could not find any project. Current directory should contain project files and csproj");
                return;
            }

            foreach (var package in packages)
            {
                Console.WriteLine($"- {package.ToString()}");

                if (IsPrerelease)
                    InstallPackagePrerelease(Program.WorkingDir, package);
                else
                    InstallPackage(Program.WorkingDir, package);
            }

            var importRazorFile = $"{Program.WorkingDir}\\_Imports.razor";

            if (File.Exists(importRazorFile) 
                && ReadKeyUtils.YesNo("Add using... statement to _Import.razor?"))
            {
                using (var stream = File.AppendText(importRazorFile))
                {
                    stream.WriteLine("@using BlazorUtils.Interfaces.Invokers");
                    stream.WriteLine("@using BlazorUtils.Interfaces.EventArgs");
                    if (packages.Contains(ImportOptions.IncludedPackage.dom))
                    {
                        stream.WriteLine("@using static BlazorUtils.Dom.DomUtils");
                        stream.WriteLine("@using BlazorUtils.Dom.BlazorUtilsComponents");
                    }

                    if (packages.Contains(ImportOptions.IncludedPackage.cookie))
                    {
                        stream.WriteLine("@using BlazorUtils.Cookie");
                        stream.WriteLine("@using BlazorUtils.Interfaces.Cookie");
                    }

                    if (packages.Contains(ImportOptions.IncludedPackage.dev))
                    {
                        stream.WriteLine("@using BlazorUtils.Dev");
                    }
                }
            }
        }

        private static void InstallPackage(string projectDir, ImportOptions.IncludedPackage package)
        {
            switch (package)
            {
                case ImportOptions.IncludedPackage.js:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Js.Bundle --version 0.4.4.3", projectDir);
                    return;
                case ImportOptions.IncludedPackage.dom:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Dom --version 0.5.4.1", projectDir);
                    return;
                case ImportOptions.IncludedPackage.cookie:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Cookie --version 0.4.1", projectDir);
                    return;
                case ImportOptions.IncludedPackage.dev:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Dev --version 1.4.1", projectDir);
                    return;
            }
        }

        private static void InstallPackagePrerelease(string projectDir, ImportOptions.IncludedPackage package)
        {
            switch (package)
            {
                case ImportOptions.IncludedPackage.js:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Js.Bundle --version 0.5.0-alpha2", projectDir);
                    return;
                case ImportOptions.IncludedPackage.dom:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Dom --version 0.6.0-alpha1", projectDir);
                    return;
                case ImportOptions.IncludedPackage.cookie:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Cookie --version 0.5.0-alpha1", projectDir);
                    return;
                case ImportOptions.IncludedPackage.dev:
                    CommandLineUtils.Run("dotnet", "add package LMT.BlazorUtils.Dev --version 1.5.0-alpha2", projectDir);
                    return;
            }
        }
    }
}
