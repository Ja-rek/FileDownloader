using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoFixture;
using FileDownloader.Download;
using NUnit.Framework;

namespace FileDownloader.Tests.Model.DownloadTest
{
    internal class MultiFileDownloaderTest
    {
        [Test]
        public void DownloadAll_WhenUse7FilesInfor_CallDelegatSevenTimes()
        {
            var mock = new Collection<int>();
            var tasksStub = 5;
            var filesStub = NotExistingFilesFake(7);

            MultiFileDownloader.DownloadAll(tasksStub, filesStub, x => mock.Add(0));

            Assert.True(mock.Count == 7);
        }

        [Test]
        public void DownloadAll_When3FilesNotExistAnd3FilesExistOnDisk_CallDelegatSixTimes()
        {
            var mock = new Collection<int>();
            var tasksStub = 3;
            var filesStub = NotExistingFilesFake(6).ToList();
            filesStub.AddRange(ExistingFilesFake(6));

            MultiFileDownloader.DownloadAll(tasksStub, filesStub.ToArray(), x => mock.Add(0));

            Assert.True(mock.Count == 6);
        }

        [Test]
        public void DownloadAll_When3FilesNotExistAnd3FilesExistOnDisk_ProcessItInCorrectTime()
        {
            var watch = new Stopwatch();
            var tasksStub = 3;
            var filesStub = NotExistingFilesFake(6).ToList();
            filesStub.AddRange(ExistingFilesFake(6));


            watch.Start();
            MultiFileDownloader.DownloadAll(tasksStub, filesStub.ToArray(), x => SleepFor50Milliseconds());
            watch.Stop();
            var processTime = watch.ElapsedMilliseconds; 

            Assert.True(processTime > 99, processTime.ToString());
            Assert.True(processTime < 140);
        }


        [Test]
        public void DownloadAll_WhenAll7FilesNotExistOnDisk_ProcessItInCorrectTime()
        {
            var watch = new Stopwatch();
            var tasksStub = 5;
            var filesStub = NotExistingFilesFake(7);

            watch.Start();
            MultiFileDownloader.DownloadAll(tasksStub, filesStub, x => SleepFor50Milliseconds());
            watch.Stop();
            var processTime = watch.ElapsedMilliseconds; 

            Assert.True(processTime > 99);
            Assert.True(processTime < 140);
        }

        [Test]
        public void DownloadAll_WhenAllFilesExistOnDisk_ProcessItInCorrectTime()
        {
            var watch = new Stopwatch();
            var tasksStub = 1;
            var filesStub = ExistingFilesFake(3);

            watch.Start();
            MultiFileDownloader.DownloadAll(tasksStub, filesStub, x => SleepFor50Milliseconds());
            watch.Stop();
            var processTime = watch.ElapsedMilliseconds; 

            Assert.True(processTime < 20);
        }

        private void SleepFor50Milliseconds()
        {
            Thread.Sleep(50);
        }

        private FileInfo[] ExistingFilesFake(int count)
        {
            var fix = new Fixture();
            fix.Register<string, string, bool, FileInfo>((x, y, z) => new FileInfo(x, y, true));
            return fix.CreateMany<FileInfo>(count).ToArray();
        }

        private FileInfo[] NotExistingFilesFake(int count)
        {
            var fix = new Fixture();
            fix.Register<string, string, bool, FileInfo>((x, y, z) => new FileInfo(x, y, false));
            return fix.CreateMany<FileInfo>(count).ToArray();
        }
    }
}
