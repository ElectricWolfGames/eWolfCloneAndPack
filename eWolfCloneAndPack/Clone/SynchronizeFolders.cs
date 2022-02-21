namespace eWolfCloneAndPack.Clone
{
    internal static class SynchronizeFolders
    {
        public static bool Do(string from, string to, IProjectTypeDetails projectTypeDetails)
        {
            bool updated = false;
            string[] files;
            try
            {
                files = Directory.GetFiles(from, "", SearchOption.AllDirectories);
            }
            catch
            {
                return updated;
            }

            List<string> excludedFolders = projectTypeDetails.GetExcludedFolders;

            foreach (var file in files)
            {
                bool copy = true;

                foreach (var excludedFolder in excludedFolders)
                {
                    if (file.Contains(excludedFolder))
                    {
                        copy = false;
                        break;
                    }
                }
                if (!copy)
                    continue;

                string partFile = file.Replace(from, string.Empty);
                string dest = to + partFile;
                if (!File.Exists(dest))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dest));
                    File.Copy(file, dest);
                    Console.Write("+");
                    updated = true;
                }
                else
                {
                    DateTime fileDetailsFrom = File.GetLastWriteTime(file);
                    DateTime fileDetailsTo = File.GetLastWriteTime(dest);

                    if (fileDetailsFrom.Ticks > fileDetailsTo.Ticks)
                    {
                        File.Copy(file, dest, true);
                        Console.Write("+");
                        updated = true;
                    }
                }
            }
            RemoveFromBackUp(from, to);
            return updated;
        }

        public static void RemoveFromBackUp(string from, string to)
        {
            string[] filesTo = Directory.GetFiles(to, "", SearchOption.AllDirectories);
            foreach (var file in filesTo)
            {
                string partFile = file.Replace(to, string.Empty);
                string dest = from + partFile;
                if (!File.Exists(dest))
                {
                    File.Delete(file);
                }
            }
        }
    }
}