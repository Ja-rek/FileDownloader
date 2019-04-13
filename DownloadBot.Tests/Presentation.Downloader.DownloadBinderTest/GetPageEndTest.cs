using NUnit.Framework;

namespace DownloadBot.Tests.Presentation.Download.DownloadBinderTest
{
    internal class PageEndTest : BinderBaseTest
    {
        private const int DEFAULT_VALUE = int.MaxValue;

        [Test]
        public void GetPageEnd_WhenArgumentIsValid_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-e", "5");

            var expected = 5;
            var actual = DownloadBinder(argsStub).GetPageEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPageEnd_WhenArgNotValid_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetPageEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPageEnd_WhenArgIsLessThanZero_ReturnsDefaultArgument()
        {
            var argsStub = ArgsFake("-e", "-5");

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetPageEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPageEnd_WhenArgIsZero_ReturnsDefaultArgument()
        {
            var argsStub = ArgsFake("-e", "-0");

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetPageEnd();

            Assert.AreEqual(expected, actual);
        }
    }
}
