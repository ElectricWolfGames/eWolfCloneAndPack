using eWolfCloneAndPack.Clone;

namespace eWolfCloneAndPack
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--Cloning Started--");

            var railwayTrackBuilder = new CloneFolder(@"C:\Unity3d\", "RailwayTrackBuilder", ProjectType.Unity3D);
            railwayTrackBuilder.Clone();

            var railway = new CloneFolder(@"C:\Unity3d\", "Railways", ProjectType.Unity3D);
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

            //var monDispl = new CloneFolder(@"E:\Unity3D\Projects\", "MonitorDisplay", ProjectType.Unity3D);
            //monDispl.Clone();

            var cfTrains = new CopyFolderToRisk(@"E:\Trains", "Trains");
            cfTrains.Clone();

            var cfGCR = new CopyFolderToRisk(@"E:\GCR", "GCR");
            cfGCR.Clone();

            var videosSync = new SyncFolders("VideoStoreMain", "MasterBackup", "Films");
            videosSync.Sync();

            var videosSyncSci = new SyncFolders("VideoStoreMain", "MasterBackup", "FilmsClassicSci-Fi");
            videosSyncSci.Sync();

            var videosSyncTv = new SyncFolders("VideoStoreMain", "MasterBackup", "TV");
            videosSyncTv.Sync();

            //var cfTextures = new CopyFolderToRisk(@"E:\Textures", "Textures");
            //cfTextures.Clone();*/

            //cf = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
            //cf.Clone();
        }
    }
}