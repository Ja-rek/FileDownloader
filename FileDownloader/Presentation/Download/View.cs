using System;

namespace FileDownloader
{
    internal static class View
    {
        public static void PageNumber(int number)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine($"Page number: {number}");
            Console.WriteLine("````````````````````````````");
            Console.ResetColor();
        }

        public static void FoundLinks(string link)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Found: {link}");
            Console.ResetColor();
        }

        public static void DownloadFile(string fileName)
        {
            Console.ResetColor();
            Console.WriteLine($"Download: {fileName}");
        }

        public static void SavedFile(string fileName)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Saved: {fileName}");
            Console.ResetColor();
        }

        public static void FileExist(string tilte)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"FILE EXIST: {tilte}");
            Console.ResetColor();
        }
    }
}
