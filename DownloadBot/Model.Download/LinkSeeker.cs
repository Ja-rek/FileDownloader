using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Monads;

namespace DownloadBoot.Download
{
    internal static class LinkSeeker
    {
        public static IEnumerable<string> GetLinksToThreadPages(Maybe<string> content)
        {
            var regex = new Regex("<h2 class=\"entry-title\"(.*?)\"bookmark");

            return content.Map(regex.Matches)
                .Map(x => x.Select(y => y.Value
                    .Replace("<h2 class=\"entry-title\"><a href=\"", string.Empty)
                    .Replace("\" rel=\"bookmark", string.Empty)))
                .ValueOr(Enumerable.Empty<string>());
        }

        public static IEnumerable<string> GetLinksToFiles(Maybe<string> content)
        {
            var regex = new Regex("http:\\/\\/file.AnyPagecom\\/\\d+\\/(.*?)\\\" ta");

            return content.Map(regex.Matches)
                .Map(x => x.Select(y => y.Value.Replace("\" ta", string.Empty)))
                .ValueOr(Enumerable.Empty<string>());
        }
    }
}
