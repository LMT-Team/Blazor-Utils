using BlazorUtils.Cli.Options;
using BlazorUtils.Cli.Utils;
using CommandLine;
using System;

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

            _Parser
           .ParseArguments<ImportOptions, CreateOptions>(args)
           .WithParsed<ImportOptions>(o =>
           {
               Console.WriteLine("Begin importing packages...");
               ImportUtils.ImportPackage(o.Packages, o.IsPrerelease);
           })
           .WithParsed<CreateOptions>(o =>
           {

           });
        }
    }
}
