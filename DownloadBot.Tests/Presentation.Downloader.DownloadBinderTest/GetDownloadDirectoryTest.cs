using NUnit.Framework;

namespace DownloadBot.Tests.Presentation.Download.DownloadBinderTest
{
    internal class GetDownloadDirectoryTest : BinderBaseTest
    {
        [Test]
        public void GetDownloadDirectory_WhenArgumentIsValid_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-d", "Test");

            var expected = "Test";
            var actual = DownloadBinder(argsStub).GetDownloadDirectory();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetDownloadDirectory_WhenArgNotValid_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = "Download";
            var actual = DownloadBinder(argsStub).GetDownloadDirectory();

            Assert.AreEqual(expected, actual);
        }
    }
}
