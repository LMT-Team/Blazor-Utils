using CommandLine;

namespace BlazorUtils.Cli.Options
{
    [Verb("create", HelpText = "Create new component, page,...")]
    internal sealed class CreateOptions
    {
        public enum ResourceTarget
        {
            component,
            page
        }

        [Option('n', "new", Required = true, HelpText = "Create new component, page,...")]
        public ResourceTarget Target { get; set; }

        [Option('a', "name", Required = true, HelpText = "Target name")]
        public string TargetName { get; set; }
    }
}
