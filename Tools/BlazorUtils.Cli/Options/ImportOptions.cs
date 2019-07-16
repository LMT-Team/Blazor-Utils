using CommandLine;
using System.Collections.Generic;

namespace BlazorUtils.Cli.Options
{
    [Verb("import", HelpText = "Create new component, page,...")]
    internal class ImportOptions
    {
        public enum IncludedPackage
        {
            dom,
            cookie,
            dev,
            js
        }

        [Option('p', "packages", Required = false, HelpText = "List of included packages", Separator = ',')]
        public IEnumerable<IncludedPackage> Packages { get; set; }

        [Option('r', "pre", Required = false, HelpText = "Set whether install stable or prerelease version")]
        public bool IsPrerelease { get; set; }
    }
}
