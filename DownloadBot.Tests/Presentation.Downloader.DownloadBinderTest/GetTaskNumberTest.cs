using NUnit.Framework;

namespace DownloadBot.Tests.Presentation.Download.DownloadBinderTest
{
    internal class GetTaskNumberTest : BinderBaseTest
    {
        private const int DEFAULT_VALUE = 1;

        [Test]
        public void GetTaskNumber_WhenArgumentIsValid_ReturnsCoorectArgument()
        {
            var argsStub = ArgsFake("-t", "3");

            var expected = 3;
            var actual = DownloadBinder(argsStub).GetTaskNumber();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTaskNumber_WhenArgNotValid_ReturnsDefaultArgument()
        {
            var argsStub = NotValidArgsFake();

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetTaskNumber();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTaskNumber_WhenArgIsLessThanZero_ReturnsDefaultArgument()
        {
            var argsStub = ArgsFake("-t", "-5");

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetTaskNumber();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetTaskNumber_WhenArgIsZero_ReturnsDefaultArgument()
        {
            var argsStub = ArgsFake("-t", "-0");

            var expected = DEFAULT_VALUE;
            var actual = DownloadBinder(argsStub).GetTaskNumber();

            Assert.AreEqual(expected, actual);
        }
    }
}
