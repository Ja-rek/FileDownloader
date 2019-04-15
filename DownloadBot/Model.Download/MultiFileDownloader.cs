using System;
using System.Linq;
using System.Threading.Tasks;

namespace DownloadBoot.Download
{
    internal static class MultiFileDownloader
    {
        public static void DownloadAll(int taskNumber, FileInfo[] filesInfo, Action<FileInfo> downloadPolicy)
        {
            var notDownloaded = filesInfo.Where(x => !x.Exist);
            var notDownloadedCount = filesInfo.Count();
            var skip = 0;

            while (true)
            {
                var filesToDownload = notDownloaded.Skip(skip).Take(taskNumber);

                Parallel.ForEach(filesToDownload, fileInfo => 
                {
                    downloadPolicy(fileInfo);
                });

                if (skip + taskNumber >= notDownloadedCount) break;

                skip += taskNumber;
            }
        }
    }
}
