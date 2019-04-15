using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using DownloadBoot.Download;
using NUnit.Framework;

namespace DownloadBot.Tests.Model.DownloadTest
{
    internal class MultiFileDownloaderTest
    {
        [Test]
        public void DownloadAll_WhenUse7FilesInfor_CallDelegatSevenTimes()
        {
            var mock = new Collection<int>();
            var tasks = 5;

            MultiFileDownloader.DownloadAll(tasks, SevenFilesInfo(), x => mock.Add(0));

            Assert.True(mock.Count == 7);
        }

        [Test]
        public void DownloadAll_WhenRun5TasksFor7itemsInLoop_ProcessNeedAbout100MiliSecToFinish()
        {
            var watch = new Stopwatch();
            var tasks = 5;

            watch.Start();
            MultiFileDownloader.DownloadAll(tasks, SevenFilesInfo(), x => Sleep());
            watch.Stop();

            Assert.True(watch.ElapsedMilliseconds > 50);
            Assert.True(watch.ElapsedMilliseconds < 110);
        }

        [Test]
        public void DownloadAll_WhenAllFilesExist_ProcessNeedAbout300MiliSecToFinish()
        {
            var watch = new Stopwatch();
            var tasks = 1;

            watch.Start();
            MultiFileDownloader.DownloadAll(tasks, ExistFiles(), x => Sleep());
            watch.Stop();

            Assert.True(watch.ElapsedMilliseconds < 20);
        }

        private void Sleep()
        {
            Thread.Sleep(50);
        }

        private FileInfo[] ExistFiles()
        {
            return new FileInfo[] 
            {
                new FileInfo("", "", fileExist: true),
                new FileInfo("", "", fileExist: true),
                new FileInfo("", "", fileExist: true),
            };
        }

        private FileInfo[] SevenFilesInfo()
        {
            return new FileInfo[] 
            {
                new FileInfo("", "", false),
                new FileInfo("", "", false),
                new FileInfo("", "", false),
                new FileInfo("", "", false),
                new FileInfo("", "", false),
                new FileInfo("", "", false),
                new FileInfo("", "", false)
            };
        }
    }
}
