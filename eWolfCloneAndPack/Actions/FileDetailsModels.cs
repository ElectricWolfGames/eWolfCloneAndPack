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
            DateTime = DateTime.Parse(Name.Substring(0, 10));
        }
    }
}