using System;
using System.Linq;
using FileDownloader.Presentation.Download;

namespace FileDownloader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Any(x => x == "-h"))
            {
                HelpView.ShowHelp();
                Environment.Exit(0);
            }

            DownloadPresenterFactory.DownloadPresenter(args)
                .DownloadFiles();
        }
    }
}
