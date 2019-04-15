using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace FileDownloader.Download
{
    internal class FileInfoService
    {
        private readonly HttpService httpService;
        private readonly string downloadDirectory;

        public FileInfoService(HttpService httpService, string downloadDirectory)
        {
            this.httpService = httpService;
            this.downloadDirectory = downloadDirectory;
        }

        public IEnumerable<FileInfo> DownloadFilesInfo(int pageNumber)
        {
            var frontPageLink = this.httpService
                .GetAsString($"http://www.AnyPage.com/page/{pageNumber}/");

            var threadPageLinks = LinkSeeker.GetLinksToThreadPages(frontPageLink);
            
            var collectionFilesLinks = new Collection<FileInfo>();

            foreach (var threadPageLink in threadPageLinks)
            {
                var threadPageContent = this.httpService.GetAsString(threadPageLink);
                var filesLinks = LinkSeeker.GetLinksToFiles(threadPageContent);

                foreach (var fileLink in filesLinks)
                {
                    var fileName = Path.GetFileName(fileLink);

                    var file = new FileInfo(fileLink, 
                        fileName, 
                        File.Exists($"{this.downloadDirectory}/{fileName}"));

                    collectionFilesLinks.Add(file);
                }
            }

            return collectionFilesLinks;
        }
    }
}
