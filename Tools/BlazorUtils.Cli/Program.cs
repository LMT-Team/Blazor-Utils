using BlazorUtils.Cli.Options;
using BlazorUtils.Cli.Utils;
using CommandLine;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace BlazorUtils.Cli
{
    class Program
    {
        static Parser _Parser = Parser.Default;
        internal static string WorkingDir = Environment.CurrentDirectory;
        //internal static string WorkingDir = @"C:\Users\lemin\Desktop\Blazor.ClientSide";

        static void Main(string[] args)
        {
            Console.WriteLine($"Current directory: {WorkingDir}");

            if (!IsCorrectCurrentDir())
            {
                Console.WriteLine("Could not find any project. Current directory should contain project files and csproj");
                return;
            }

            _Parser
           .ParseArguments<ImportOptions, CreateOptions>(args)
           .WithParsed<ImportOptions>(o =>
           {
               Console.WriteLine("Begin importing packages...");
               ImportUtils.ImportPackage(o.Packages, o.IsPrerelease);
           })
           .WithParsed<CreateOptions>(o =>
           {
               switch (o.Target)
               {
                   case CreateOptions.ResourceTarget.component:
                       CreateUtils.CreateComponent(o.TargetName);
                       break;
                   case CreateOptions.ResourceTarget.page:
                       CreateUtils.CreatePage(o.TargetName);
                       break;
               }
           });
        }

        static bool IsCorrectCurrentDir()
        {
            //Find project file
            if (!Directory.EnumerateFiles(WorkingDir, "*.csproj").Any())
            {
                return false;
            }
            return true;
        }
    }
}
