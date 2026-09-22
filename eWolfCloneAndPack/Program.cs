using eWolfCloneAndPack.Actions;
using eWolfCloneAndPack.Clone;
using System.Diagnostics.CodeAnalysis;

namespace eWolfCloneAndPack
{
    internal class Program
    {
        // Check whether a backup is out of date without touching anything, e.g.
        //   eWolfCloneAndPack --check E:\Personal PersonalData Data
        // Prints "true" (exit code 1) if the backup is out of date, "false" (exit code 0) if it is current.
        private static int CheckFromArgs(string[] args)
        {
            if (!TryParseCloneFolder(args, out CloneFolder? cloneFolder))
                return 2;

            bool outOfDate = cloneFolder.IsOutOfDate();
            Console.WriteLine(outOfDate ? "true" : "false");
            return outOfDate ? 1 : 0;
        }

        // Clone a single folder from the command line, e.g.
        //   eWolfCloneAndPack E:\Personal PersonalData Data
        private static int CloneFromArgs(string[] args)
        {
            if (!TryParseCloneFolder(args, out CloneFolder? cloneFolder))
                return 1;

            Console.WriteLine("--Cloning Started--");
            cloneFolder.Clone();
            return 0;
        }

        private static int Main(string[] args)
        {
            if (args.Length > 0 && args[0].Equals("--check", StringComparison.OrdinalIgnoreCase))
                return CheckFromArgs(args[1..]);

            if (args.Length > 0)
                return CloneFromArgs(args);

            Console.WriteLine("--Cloning Started--");

            var buildingBuilder = new CloneFolder(@"E:\Unity3D\Projects\", "BuildingBuilder", ProjectType.Unity3D);
            buildingBuilder.Clone();

            var SpinnerMaths_Unity = new CloneFolder(@"E:\Unity3D\Projects", "SpinnerMaths", ProjectType.Unity3D);
            SpinnerMaths_Unity.Clone();

            var PersonalData = new CloneFolder(@"E:\Personal\", "PersonalData", ProjectType.Data);
            PersonalData.Clone();
            var photo2023 = new CloneFolder(@"E:\Personal\Pictures\", "2023", ProjectType.Data);
            photo2023.Clone();
            var photo2024 = new CloneFolder(@"E:\Personal\Pictures\", "2024", ProjectType.Data);
            photo2024.Clone();
            var photo2025 = new CloneFolder(@"E:\Personal\Pictures\", "2025", ProjectType.Data);
            photo2025.Clone();
            var photo2026 = new CloneFolder(@"E:\Personal\Pictures\", "2026", ProjectType.Data);
            photo2026.Clone();

            var eWoldSiteVintageSciFiBuilder = new CloneFolder(@"E:\Projects\", "VintageSciFi", ProjectType.VSProject);
            eWoldSiteVintageSciFiBuilder.Clone();

            var railwayTrackBuilder = new CloneFolder(@"C:\Unity3d\", "RailwayTrackBuilder", ProjectType.Unity3D);
            railwayTrackBuilder.Clone();

            var railway = new CloneFolder(@"C:\Unity3d\", "Railway_Trains_Freight", ProjectType.Unity3D);
            railway.Clone();

            var book = new CloneFolder(@"E:\Unity3D\Projects\", "OpenBook", ProjectType.Unity3D);
            book.Clone();

            var gcr = new CloneFolder(@"E:\Unity3D\Projects\", "GCR", ProjectType.Unity3D);
            gcr.Clone();

            var twoD = new CloneFolder(@"E:\Unity3D\Projects\", "2DLabs", ProjectType.Unity3D);
            twoD.Clone();

            var eWoldSiteBuilder = new CloneFolder(@"E:\Projects\GitHub\eWolfSiteBuilder\", "eWolfSiteBuilder", ProjectType.VSProject);
            eWoldSiteBuilder.Clone();

            var codeExamples = new CloneFolder(@"E:\Unity3D\Projects\", "CodeExamples", ProjectType.Unity3D);
            codeExamples.Clone();

            var carryOnTraining = new CloneFolder(@"C:\Unity3d", "CarryOnTraining", ProjectType.Unity3D);
            carryOnTraining.Clone();

            var trainMatch = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
            trainMatch.Clone();

            var fenceBuilder = new CloneFolder(@"E:\Unity3D\Projects\", "FenceWallHedgeBuilder", ProjectType.Unity3D);
            fenceBuilder.Clone();

            var fillTheBox = new CloneFolder(@"C:\Unity3d", "FillTheBox", ProjectType.Unity3D);
            fillTheBox.Clone();

            var eWolfSciFiObject2 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Objects_Pack2_eWolf", ProjectType.Unity3D);
            eWolfSciFiObject2.Clone();

            var eWolfSciFiObject1 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Objects_Pack1", ProjectType.Unity3D);
            eWolfSciFiObject1.Clone();

            var spaceSalvager = new CloneFolder(@"C:\Unity3d", "SpaceSalvager", ProjectType.Unity3D);
            spaceSalvager.Clone();

            var eWolfSciFiPack1 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Rooms_Pack1_eWolf", ProjectType.Unity3D);
            eWolfSciFiPack1.Clone();

            var railwayWebBuilder = new CloneFolder(@"E:\Projects\eWolfModelRailwayWeb\RailwayWebBuilder\", "RailwayWebBuilder", ProjectType.VSProject);
            railwayWebBuilder.Clone();

            //var cfTrains = new CopyFolderToRisk(@"E:\Trains", "Trains");
            //cfTrains.Clone();

            //var cfGCR = new CopyFolderToRisk(@"E:\GCR", "GCR");
            //cfGCR.Clone();

            /*var videosSync dont run= new SyncFolders("VideoStoreMain", "MasterBackup", "Films");
            videosSync.Sync();

            var videosSyncSci dont run = new SyncFolders("VideoStoreMain", "MasterBackup", "FilmsClassicSci-Fi");
            videosSyncSci.Sync();

            var videosSyncTv  dont run = new SyncFolders("VideoStoreMain", "MasterBackup", "TV");
            videosSyncTv.Sync();
            */
            //var cfTextures = new CopyFolderToRisk(@"E:\Textures", "Textures");
            //cfTextures.Clone();*/

            TrimZips tz = new();
            tz.Do();
            return 0;
        }

        private static bool TryParseCloneFolder(string[] args, [NotNullWhen(true)] out CloneFolder? cloneFolder)
        {
            cloneFolder = null;
            if (args.Length != 3 || !Enum.TryParse(args[2], ignoreCase: true, out ProjectType projectType))
            {
                Console.WriteLine("Usage: eWolfCloneAndPack [--check] <folder> <name> <projectType>");
                Console.WriteLine($"  projectType: {string.Join(", ", Enum.GetNames<ProjectType>())}");
                Console.WriteLine(@"  e.g. eWolfCloneAndPack E:\Personal PersonalData Data");
                Console.WriteLine(@"       eWolfCloneAndPack --check E:\Personal PersonalData Data");
                return false;
            }

            cloneFolder = new CloneFolder(args[0], args[1], projectType);
            if (!Directory.Exists(cloneFolder.From))
            {
                Console.WriteLine($"Folder not found: {cloneFolder.From}");
                return false;
            }
            return true;
        }
    }
}