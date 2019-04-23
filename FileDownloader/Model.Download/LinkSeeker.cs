using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monads;

namespace FileDownloader.Download
{
    internal static class LinkSeeker
    {
        public static IEnumerable<string> GetLinksToThreadPages(Maybe<string> content)
        {
            var regex = new Regex("<h2 class=\"entry-title\"(.*?)\"bookmark");

            return regex.Matches(content.ValueOrEmpty())
                .Select(y => y.Value
                    .Replace("<h2 class=\"entry-title\"><a href=\"", string.Empty)
                    .Replace("\" rel=\"bookmark", string.Empty));
        }

        public static IEnumerable<string> GetLinksToFiles(Maybe<string> content)
        {
            var regex = new Regex("http:\\/\\/file.AnyPage.com\\/\\d+\\/(.*?)\\\" ta");

            return regex.Matches(content.ValueOrEmpty())
                .Select(y => y.Value.Replace("\" ta", string.Empty));
        }
    }
}
