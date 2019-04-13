using NUnit.Framework;
using DownloadBoot.Download;

namespace DownloadBot.Tests
{
    public class ArgumentSelectorTest
    {
        [Test]
        public void DownloadDirectory_WhenSelectArgument_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-d", "Test");

            var expected = "Test";
            var actual = new DownloadBinder(argsStub).DownloadDirectory();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DownloadDirectory_WhenArgNotExist_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = "Download";
            var actual = new DownloadBinder(argsStub).DownloadDirectory();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PageEnd_WhenSelectArgument_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-e", "5");

            var expected = 5;
            var actual = new DownloadBinder(argsStub).PageEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PageEnd_WhenArgNotExist_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = int.MaxValue;
            var actual = new DownloadBinder(argsStub).PageEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PageStart_WhenSelectArgument_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-s", "5");

            var expected = 5;
            var actual = new DownloadBinder(argsStub).PageStart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PageStart_WhenArgNotExist_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = 1;
            var actual = new DownloadBinder(argsStub).PageStart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TaskNumber_WhenSelectArgument_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-t", "5");

            var expected = 5;
            var actual = new DownloadBinder(argsStub).TaskNumber();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TaskNumber_WhenArgNotExist_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = 1;
            var actual = new DownloadBinder(argsStub).TaskNumber();

            Assert.AreEqual(expected, actual);
        }

        public string[] ArgsFake(string arg, string value)
        {
            return new string[] {"-ab", "abbsdf", arg, value, "-f", "other" };
        }

        public string[] NotValidArgsFake()
        {
            return new string[] {"-ab", "abbsdf", "-f", "other" };
        }
    }
}

