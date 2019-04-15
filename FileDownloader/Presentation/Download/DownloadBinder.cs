namespace FileDownloader.Presentation.Download
{
    internal class DownloadBinder : Binder
    {
        public DownloadBinder(string[] args) : base(args)
        {
        }

        public string GetDownloadDirectory()
        {
            return base.GetValue("-d", base.args) ?? "Download";
        }

        public int GetPageEnd()
        {
            var endPage = base.GetValue("-e", args);

            int intEndPage;
            var parsed = int.TryParse(endPage, out intEndPage);

            if (parsed && intEndPage > 0) return intEndPage;

            return int.MaxValue; 
        }

        public int GetPageStart()
        {
            var startPage = base.GetValue("-s", base.args);

            int intStartPage;
            var parsed = int.TryParse(startPage, out intStartPage);

            if (parsed && intStartPage > 0) return intStartPage;

            return 1; 
        }

        public int GetTaskNumber()
        {
            var taskNumber = base.GetValue("-t", base.args);

            int intTaskNumber;
            var parsed = int.TryParse(taskNumber, out intTaskNumber);

            if (parsed && intTaskNumber < 6 && intTaskNumber > 0) return intTaskNumber;

            return 1; 
        }
    }
}
