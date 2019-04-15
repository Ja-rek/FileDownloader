using NUnit.Framework;
using FileDownloader.Download;
using System.Linq;

namespace FileDownloader.Tests.Model.DownloadTest
{
    public class LinkSeekerTest 
    {
        [Test]
        public void GetLinksToThreadPages_WhenPageContainLinks_ReturnsLinks()
        {
            var frontPageStub = WebsiteFake.FrontPage;

            var expected = "http://www.AnyPage.com/unreal-for-mobile-and-standalone-vr/";
            var actual = LinkSeeker.GetLinksToThreadPages(frontPageStub).FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLinksToThreadPages_WhenPageNotContainLinks_ReturnsEmptyList()
        {
            var frontPageStub = string.Empty;

            var expected = Enumerable.Empty<string>();
            var actual = LinkSeeker.GetLinksToThreadPages(frontPageStub);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLinksToFiles_WhenPageContainLinks_ReturnsLinks()
        {
            var threadPageStub = WebsiteFake.ThreadPage;

            var expected = "http://file.AnyPage.com/20190414/Unreal for Mobile and Standalone VR.pdf";
            var actual = LinkSeeker.GetLinksToFiles(threadPageStub).FirstOrDefault();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetLinksToFiles_WhenPageNotContainLinks_ReturnsEmptyList()
        {
            var frontPageStub = string.Empty;

            var expected = Enumerable.Empty<string>();
            var actual = LinkSeeker.GetLinksToFiles(frontPageStub);

            Assert.AreEqual(expected, actual);
        }
    }
}
