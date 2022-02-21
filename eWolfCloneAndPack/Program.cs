// See https://aka.ms/new-console-template for more information

namespace eWolfCloneAndPack.Clone
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("--Cloning Started--");
            var cf = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Rooms_Pack1_eWolf", ProjectType.Unity3D);
            cf.Clone();

            cf = new CloneFolder(@"C:\Unity3d", "SpaceSalvager", ProjectType.Unity3D);
            cf.Clone();

            cf = new CloneFolder(@"C:\Unity3d", "TrainMatch", ProjectType.Unity3D);
            cf.Clone();
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