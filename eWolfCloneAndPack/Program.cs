// See https://aka.ms/new-console-template for more information
using eWolfCloneAndPack.Clone;

Console.WriteLine("--Cloning Started--");

var cf = new CloneFolder(@"C:\Unity3d", "Sci-Fi_Rooms_Pack1_eWolf", ProjectType.Unity3D);
//cf.GetDrives();

cf.Clone();

var cf2 = new CloneFolder(@"C:\Unity3d", "SpaceSalvager", ProjectType.Unity3D);
cf2.Clone();