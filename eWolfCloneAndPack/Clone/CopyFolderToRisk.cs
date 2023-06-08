using eWolfCloneAndPack.Configuration;

namespace eWolfCloneAndPack.Clone
{
    internal class CopyFolderToRisk
    {
        public CopyFolderToRisk(string folder, string name)
        {
            Name = name;
            Folder = folder;
        }

        public string Folder { get; set; }

        public string Name { get; set; }

        internal string From
        {
            get
            {
                return $"{Folder}\\{Name}";
            }
        }

        public bool TryGetDrive(ref string riskyDrive, string driveNameToGet)
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            for (int i = 0; i < drives.Length; i++)
            {
                try
                {
                    string driveName = drives[i].VolumeLabel;
                    if (driveName == driveNameToGet)
                    {
                        riskyDrive = drives[i].Name;
                        return true;
                    }
                }
                catch
                {
                }
            }
            return false;
        }

        internal void Clone()
        {
            Console.WriteLine($"=============================================");
            string driveLetter = "";
            if (TryGetDrive(ref driveLetter, "RiskyStore"))
            {
                string destination = $"{driveLetter}Development\\{Name}";

                Console.WriteLine($"Starting Cloning {Folder} to {destination}");

                IProjectTypeDetails projectTypeUnity3D = new ProjectTypeUnity3D();

                Directory.CreateDirectory(destination);

                bool updated = SynchronizeFolders.Do(Folder, destination, projectTypeUnity3D);
                Console.WriteLine($"Finished Cloning {From} to {destination}");
            }

            if (TryGetDrive(ref driveLetter, "Master2"))
            {
                string destination = $"{driveLetter}Development\\{Name}";

                Console.WriteLine($"Starting Cloning {Folder} to {destination}");

                IProjectTypeDetails projectTypeUnity3D = new ProjectTypeUnity3D();

                Directory.CreateDirectory(destination);

                bool updated = SynchronizeFolders.Do(Folder, destination, projectTypeUnity3D);
                Console.WriteLine($"Finished Cloning {From} to {destination}");
            }
        }
    }
}