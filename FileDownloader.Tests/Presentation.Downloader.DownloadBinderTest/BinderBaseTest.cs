using FileDownloader.Presentation.Download;

namespace FileDownloader.Tests.Presentation.Download.DownloadBinderTest
{
    internal abstract class BinderBaseTest
    {
        public string[] ArgsFake(string arg, string value)
        {
            return new string[] {"-ab", "abbsdf", arg, value, "-f", "other" };
        }

        public string[] NotValidArgsFake()
        {
            return new string[] {"-ab", "abbsdf", "-f", "other" };
        }

        public DownloadBinder DownloadBinder(string[] args)
        {
            return new DownloadBinder(args);
        }
    }
}
