using System.IO;
using System.Threading.Tasks;
using Monads;

namespace DownloadBoot.Download
{
    internal class DownloadService
    {
        private readonly HttpService httpService;
        private readonly string downloadDirectory;

        public DownloadService(HttpService httpService, string downloadDirectory)
        {
            this.httpService = httpService;

            CreateDownloadFolderIfNotExist(downloadDirectory);

            this.downloadDirectory = downloadDirectory;
        }

        public void DownloadFile(string fileLink, string fileName)
        {
            var stream = this.httpService.GetAsStream(fileLink);

            SaveFile(fileName, stream).Wait();
        }

        private async Task SaveFile(string fileName, Maybe<Stream> fileStream)
        {
            await Task.Run(() => fileStream.DoWhenHasValue(val => 
            {
                var textFile = File.Create($"{this.downloadDirectory}/{fileName}");

                val.CopyTo(textFile);

                textFile.Flush(); 
            }));
        }

        private static void CreateDownloadFolderIfNotExist(string downloadDirectory)
        {
            if (!Directory.Exists(downloadDirectory)) 
            {
                Directory.CreateDirectory(downloadDirectory);
            }
        }
    }
}
