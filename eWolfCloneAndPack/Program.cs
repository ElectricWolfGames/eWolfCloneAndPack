// See https://aka.ms/new-console-template for more information

namespace eWolfCloneAndPack.Clone
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--Cloning Started--");

            var cfob2 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Objects_Pack2_eWolf", ProjectType.Unity3D);
            cfob2.Clone();

            var cfob1 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Objects_Pack1", ProjectType.Unity3D);
            cfob1.Clone();

            var cfss = new CloneFolder(@"C:\Unity3d", "SpaceSalvager", ProjectType.Unity3D);
            cfss.Clone();
            
            var cfrp = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Rooms_Pack1_eWolf", ProjectType.Unity3D);
            cfrp.Clone();
            
            //var cfpb = new CloneFolder(@"C:\Unity3d", "PipeBuilder", ProjectType.Unity3D);
            //cfpb.Clone();

            var cfesb = new CloneFolder(@"E:\Projects\GitHub\eWolfSiteBuilder\", "eWolfSiteBuilder", ProjectType.VSProject);
            cfesb.Clone();

            var cfrsb = new CloneFolder(@"E:\Projects\eWolfModelRailwayWeb\RailwayWebBuilder\", "RailwayWebBuilder", ProjectType.VSProject);
            cfrsb.Clone();

            var cfTrains = new CopyFolderToRisk(@"E:\Trains", "Trains");
            cfTrains.Clone();

            var cfGCR = new CopyFolderToRisk(@"E:\GCR", "GCR");
            cfGCR.Clone();

            //var cfTextures = new CopyFolderToRisk(@"E:\Textures", "Textures");
            //cfTextures.Clone();*/

            //cf = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
            //cf.Clone();
        }
    }
}

/*

var cf2 = new CloneFolder(@"C:\Unity3d", "SpaceSalvager", ProjectType.Unity3D);
cf2.Clone();

cf2 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Objects_Pack1", ProjectType.Unity3D);
cf2.Clone();

cf2 = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Objects_Pack2_eWolf", ProjectType.Unity3D);
cf2.Clone();

cf2 = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
cf2.Clone();
*/

/*var cf2 = new CloneFolder(@"E:\Unity3D\Projects_Done", "GemChaserAndroid", ProjectType.Unity3D);
cf2.Clone();
cf2 = new CloneFolder(@"E:\Unity3D\Projects_Done", "PipeBuilder", ProjectType.Unity3D);
cf2.Clone();
cf2 = new CloneFolder(@"E:\Unity3D\Projects_Done", "RoadBuilder", ProjectType.Unity3D);
cf2.Clone();
cf2 = new CloneFolder(@"E:\Unity3D\Projects_Done", "SpaceGame", ProjectType.Unity3D);
cf2.Clone();*/
/*cf2 = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
cf2.Clone();
cf2 = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
cf2.Clone();*/