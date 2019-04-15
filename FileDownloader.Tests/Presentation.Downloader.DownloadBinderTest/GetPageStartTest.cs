using NUnit.Framework;

namespace FileDownloader.Tests.Presentation.Download.DownloadBinderTest
{
    internal class PageStartTest : BinderBaseTest
    {
        private const int DEFAULT_VALUE = 1;

        [Test]
        public void GetPageStart_WhenArgumentIsValid_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-s", "5");

            var expected = 5;
            var actual = DownloadBinder(argsStub).GetPageStart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPageStart_WhenArgNotValid_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetPageStart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPageStart_WhenArgIsLessThanZero_ReturnsDefaultArgument()
        {
            var argsStub = ArgsFake("-s", "-5");

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetPageStart();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPageStart_WhenArgIsZero_ReturnsDefaultArgument()
        {
            var argsStub = ArgsFake("-s", "-0");

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetPageStart();

            Assert.AreEqual(expected, actual);
        }
    }
}
