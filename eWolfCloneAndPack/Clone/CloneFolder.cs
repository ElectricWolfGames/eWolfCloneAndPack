using eWolfCloneAndPack.Configuration;

namespace eWolfCloneAndPack.Clone
{
    internal class CloneFolder
    {
        public CloneFolder(string folder, string name, ProjectType projectType)
        {
            Name = name;
            Folder = folder;
            ProjectType = projectType;
        }

        public string Folder { get; set; }

        public string Name { get; set; }

        public ProjectType ProjectType { get; set; }

        private string Destination
        {
            get
            {
                return $"{Settings.CloneStore}\\{ProjectType}\\{Name}";
            }
        }

        private string From
        {
            get
            {
                return $"{Folder}\\{Name}";
            }
        }

        internal void Clone()
        {
            string[] files = Directory.GetFiles(From, "", SearchOption.AllDirectories);
            Console.WriteLine($"=============================================");
            Console.WriteLine($"Starting Cloning {From} to {Destination}");

            IProjectTypeDetails projectTypeUnity3D = new ProjectTypeUnity3D();

            Directory.CreateDirectory(Destination);

            SynchronizeFolders.Do(From, Destination, projectTypeUnity3D);

            Console.WriteLine($"Finished {From} to {Destination}");
        }

        internal void GetDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            Console.WriteLine("Detected Drives: ");
            for (int i = 0; i < drives.Length; i++)
            {
                try
                {
                    Console.WriteLine($"Drive {i} {drives[i].Name} {drives[i].VolumeLabel}");
                }
                catch { }
            }

            // return drives;
        }
    }
}