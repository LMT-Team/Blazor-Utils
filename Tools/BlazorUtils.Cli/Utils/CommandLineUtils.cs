using System.Diagnostics;

namespace BlazorUtils.Cli.Utils
{
    internal static class CommandLineUtils
    {
        public static void Run(string fileName, string argument, string workingDirectory)
        {
            using (var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = argument,
                    CreateNoWindow = true,
                    WorkingDirectory = workingDirectory
                }
            })
            {
                process.Start();
                process.WaitForExit();
            }
        }
    }
}
