using System;
using System.Linq;

namespace FileDownloader.Presentation.Download
{
    internal abstract class Binder
    {
        protected readonly string[] args;

        public Binder(string[] args)
        {
            this.args = args;
        }

        protected string GetValue(string pattern, string[] args)
        {
            if (pattern == null) throw new ArgumentNullException(nameof(pattern));
            if (args == null) throw new ArgumentNullException(nameof(args));

            for (int i = 0; i < args.Count(); i++)
            {
                if (args[i] != pattern) continue;

                return args[i + 1];
            }

            return null;
        }
    }
}
