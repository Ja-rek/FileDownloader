namespace FileDownloader.Download
{
    internal class FileInfo
    {
        public FileInfo(string link, string fileName, bool fileExist)
        {
            Link = link;
            Name = fileName;
            Exist = fileExist;
        }

        public string Link { get; }
        public string Name { get; }
        public bool Exist { get; }
    }
}
