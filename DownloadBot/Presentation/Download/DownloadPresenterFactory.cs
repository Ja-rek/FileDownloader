using DownloadBoot.Download;
using DownloadBoot.Presentation.Download;

namespace DownloadBoot
{
    internal static class DownloadPresenterFactory
    {
        public static DownloadPresenter DownloadPresenter(string[] args)
        {
            var binder = new DownloadBinder(args);
            var taskNuber = binder.GetTaskNumber();
            var pageStart= binder.GetPageStart();
            var pageEnd = binder.GetPageEnd();
            var downloadDirectory = binder.GetDownloadDirectory();

            var httpService = new HttpService();
            var fileInfoService = new FileInfoService(httpService, downloadDirectory);
            var downloadService = new DownloadService(httpService, downloadDirectory);

            return new DownloadPresenter(fileInfoService, downloadService, pageStart, pageEnd, taskNuber);
        }
    }
}
