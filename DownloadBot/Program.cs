using System;
using System.Linq;
using DownloadBoot.Presentation.Download;

namespace DownloadBoot
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

            var downloadPresenter = DownloadPresenterFactory.DownloadPresenter(args);

            downloadPresenter.DownloadFiles();
        }
    }
}
