using CommandLine;
using System.Collections.Generic;

namespace BlazorUtils.Cli.Options
{
    [Verb("create", HelpText = "Create new project, component,...")]
    internal sealed class CreateOptions
    {
        public enum ResourceTarget
        {
            project,
            component,
            page
        }

        public enum IncludedPackage
        {
            dom,
            cookie,
            dev,
            js
        }

        [Option('p', "packages", Required = false, HelpText = "List of included packages", Separator = ',')]
        public IEnumerable<IncludedPackage> Packages { get; set; }

        [Option('n', "new", Required = true, HelpText = "Create new project, component,...")]
        public ResourceTarget Target { get; set; }

        [Option('a', "as", Required = true, HelpText = "File/project name")]
        public string ProjectName { get; set; }
    }
}
