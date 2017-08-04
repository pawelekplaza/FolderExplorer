using System;
using System.Diagnostics;
using System.IO;

namespace FolderExplorer
{
    public static class CmdHelper
    {
        public static void Run(string path)
        {
            var cmdPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "cmd.exe");
            var arguments = $"/C \"{ path }\"";

            var startInfo = new ProcessStartInfo(cmdPath)
            {
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                Verb = "runas"
            };

            Process.Start(startInfo);
        }
    }
}
