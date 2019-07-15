using BlazorUtils.Cli.Options;
using CommandLine;
using System;

namespace BlazorUtils.Cli
{
    class Program
    {
        static Parser _Parser = Parser.Default;

        static void Main(string[] args)
        {
            _Parser
           .ParseArguments<CreateOptions>(args)
           .WithParsed<CreateOptions>(o =>
           {
               Console.WriteLine(o.ProjectName);
               Console.WriteLine(o.Target);

               foreach (var package in o.Packages)
                   Console.WriteLine(package);
           });
        }
    }
}
