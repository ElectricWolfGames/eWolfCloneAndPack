namespace eWolfCloneAndPack.Actions
{
    internal partial class TrimZips
    {
        internal void Do()
        {
            var folders = Directory.GetDirectories("E:\\_BackUpZips\\Unity3D");
            foreach (var folder in folders)
            {
                Trim(folder);
            }

            try
            {
                folders = Directory.GetDirectories("M:\\_BackUpZips\\Unity3D");
                foreach (var folder in folders)
                {
                    Trim(folder);
                }
            }
            catch { }
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