using System.Collections.Generic;
using System.Linq;
using FileDownloader.Download;

namespace FileDownloader
{
    internal class DownloadPresenter
    {
        private readonly int pageStart;
        private readonly int pageEnd;
        private readonly int taskNumber;
        private readonly FileInfoService fileInfoService;
        private readonly DownloadService downloadService;

        public DownloadPresenter(FileInfoService fileInfoService, 
            DownloadService downloadService,
            int pageStart, 
            int pageEnd,
            int taskNumber)
        {
            this.pageStart = pageStart;
            this.pageEnd = pageEnd;
            this.taskNumber = taskNumber;
            this.fileInfoService = fileInfoService;
            this.downloadService = downloadService;
        }

        public void DownloadFiles()
        {
            for (int pageNumber = this.pageStart; pageNumber < this.pageEnd; pageNumber++)
            {
                View.PageNumber(pageNumber);

                var filesInfo = this.fileInfoService
                    .DownloadFilesInfo(pageNumber)
                    .ToArray();

                ShowLinks(filesInfo);
                ShowExistinFiles(filesInfo);

                MultiFileDownloader.DownloadAll(this.taskNumber, 
                    filesInfo, 
                    downloadPolicy: fileInfo => 
                    {
                        View.DownloadFile(fileInfo.Name);

                        this.downloadService.DownloadFile(fileInfo.Link, fileInfo.Name);

                        View.SavedFile(fileInfo.Name); 
                    });
            }
        }

        private void ShowLinks(IEnumerable<FileInfo> filesInfo)
        {
            foreach (var file in filesInfo)
            {
                View.FoundLinks(file.Link);
            }
        }

        private void ShowExistinFiles(IEnumerable<FileInfo> filesInfo)
        {
            foreach (var file in filesInfo)
            {
                if (file.Exist)
                {
                    View.FileExist(file.Name);
                }
            }
        }
    }
}
