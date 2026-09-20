namespace eWolfCloneAndPack.Clone
{
    internal static class SynchronizeFolders
    {
        public static bool Do(string from, string to, IProjectTypeDetails projectTypeDetails)
        {
            Console.Write("[");

            RemoveFromBackUp(from, to);

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
                if (IsExcluded(file, excludedFolders))
                    continue;

                string partFile = file.Replace(from, string.Empty);
                string dest = to + partFile;
                if (!File.Exists(dest))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(dest)!);
                    try
                    {
                        File.Copy(file, dest);
                    }
                    catch { }
                    Console.Write("+");
                    updated = true;
                }
                else
                {
                    DateTime fileDetailsFrom = File.GetLastWriteTime(file);
                    DateTime fileDetailsTo = File.GetLastWriteTime(dest);

                    if (fileDetailsFrom.Ticks > fileDetailsTo.Ticks)
                    {
                        try
                        {
                            File.Copy(file, dest, true);
                            Console.Write("+");
                            updated = true;
                        }
                        catch { }
                    }
                }
            }

            Console.Write("]");
            RemoveEmptyFolders(to);
            return updated;
        }

        // Read-only check: would Do() copy or delete anything?
        public static bool IsOutOfDate(string from, string to, IProjectTypeDetails projectTypeDetails)
        {
            if (!Directory.Exists(to))
                return true;

            List<string> excludedFolders = projectTypeDetails.GetExcludedFolders;

            // Anything in the source that is missing from, or newer than, the backup
            foreach (var file in Directory.GetFiles(from, "", SearchOption.AllDirectories))
            {
                if (IsExcluded(file, excludedFolders))
                    continue;

                string dest = to + file.Replace(from, string.Empty);
                if (!File.Exists(dest))
                    return true;

                if (File.GetLastWriteTime(file).Ticks > File.GetLastWriteTime(dest).Ticks)
                    return true;
            }

            // Anything in the backup that no longer exists in the source
            foreach (var file in Directory.GetFiles(to, "", SearchOption.AllDirectories))
            {
                string source = from + file.Replace(to, string.Empty);
                if (!File.Exists(source))
                    return true;
            }

            return false;
        }

        public static void RemoveFromBackUp(string from, string to)
        {
            try
            {
                string[] filesTo = Directory.GetFiles(to, "", SearchOption.AllDirectories);
                foreach (var file in filesTo)
                {
                    string partFile = file.Replace(to, string.Empty);
                    string dest = from + partFile;
                    if (!File.Exists(dest))
                    {
                        Console.Write("-");
                        File.Delete(file);
                    }
                }
            }
            catch { }
        }

        private static bool IsExcluded(string file, List<string> excludedFolders)
        {
            foreach (var excludedFolder in excludedFolders)
            {
                if (file.Contains(excludedFolder))
                    return true;
            }
            return false;
        }

        private static void RemoveEmptyFolders(string to)
        {
            foreach (var dir in Directory.GetDirectories(to, "*", SearchOption.AllDirectories)
                         .OrderByDescending(d => d.Length))
            {
                if (!Directory.EnumerateFileSystemEntries(dir).Any())
                    Directory.Delete(dir);
            }
        }
    }
}