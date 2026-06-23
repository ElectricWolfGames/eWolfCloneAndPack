using eWolfCloneAndPack.Configuration;

namespace eWolfCloneAndPack.Actions
{
    internal partial class TrimZips
    {
        internal void Do()
        {
            TrimDrive(Settings.ZipStore);

            try
            {
                TrimDrive(@"M:\_BackUpZips");
            }
            catch { }
        }

        private void TrimDrive(string baseStore)
        {
            var unityFolder = Path.Combine(baseStore, "Unity3D");
            if (!Directory.Exists(unityFolder))
                return;

            foreach (var folder in Directory.GetDirectories(unityFolder))
            {
                Trim(folder);
            }
        }

        private void RemoveExtras(IEnumerable<FileDetailsModels> items)
        {
            items = items.OrderByDescending(x => x.DateTime);

            foreach (var item in items.Skip(1))
            {
                File.Delete(item.FullPath);
            }
        }

        private void Trim(string path)
        {
            var files = Directory.GetFiles(path, "", SearchOption.AllDirectories);

            files = files.OrderBy(f => f).ToArray();

            List<FileDetailsModels> fileDetails = new();

            foreach (var file in files)
            {
                FileDetailsModels fileDetail = new(file);
                fileDetails.Add(fileDetail);
            }

            DateTime now = DateTime.Now;
            var list = fileDetails.DistinctBy(x => $"{x.DateTime.Year}-{x.DateTime.Month}");
            foreach (var file in list)
            {
                if (file.DateTime.Year == now.Year && file.DateTime.Month == now.Month)
                {
                    continue;
                }

                var items = fileDetails.Where(x => x.DateTime.Year == file.DateTime.Year && x.DateTime.Month == file.DateTime.Month);
                if (items.Count() > 1)
                {
                    RemoveExtras(items);
                }
            }
        }
    }
}