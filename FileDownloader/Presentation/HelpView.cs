using System;

namespace FileDownloader.Presentation.Download
{
    internal static class HelpView
    {
        public static void ShowHelp()
        {
            Console.WriteLine("HELP:\n");
            Console.WriteLine("-t  The number of tasks that download files in parallel. It can be specified from 1 to 5. If you not specified will be selected 1 by default.");
            Console.WriteLine("-s  The page number for start download. If you not specified will be selected 1 by default.");
            Console.WriteLine("-e  The page number for end download. If you not specified will be selected int.Max by default.");
            Console.WriteLine("-e  The folder for download files. If you not specified will be created /Download in the current directory.");
        }
    }
}
