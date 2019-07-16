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
    }
}
