namespace eWolfCloneAndPack.Actions
{
    public class FileDetailsModels
    {
        public DateTime DateTime;

        public string FullPath;

        public string Name;

        public FileDetailsModels(string path)
        {
            FullPath = path;
            Name = Path.GetFileName(path);
            if (Name.Length >= 10 && DateTime.TryParseExact(Name.Substring(0, 10), "yyyy-MM-dd",
                    null, System.Globalization.DateTimeStyles.None, out var parsed))
                DateTime = parsed;
            else
                DateTime = File.GetLastWriteTime(path);
        }
    }
}