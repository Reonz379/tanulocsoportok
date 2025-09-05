using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace kraterek
{
    internal class Krater
    {
        public static int RecordCount;
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; set; }
        public string Nev { get; set; }


        public Krater(string line)
        {
            string[] data = line.Split('\t');
            if (data[0].Contains("."))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = data[i].Replace(".", ",");
                }
            }
            X = double.Parse(data[0]);
            Y = double.Parse(data[1]);
            R = double.Parse(data[2]);
            Nev = data[3];
            RecordCount++;
        }
        public static void Kereses(string kraternev, List<Krater> kraterek)
        {
            bool talal = false;
            for (int i = 0; i < Krater.RecordCount; i++)
            {
                if (kraternev == kraterek[i].Nev)
                {
                    Console.WriteLine($"A(z) {kraterek[i].Nev} középpontja X={kraterek[i].X} Y={kraterek[i].Y} sugara R={kraterek[i].R}.");
                    talal = true;
                    break;
                }

            }
            if (!talal)
            {
                Console.WriteLine("Nincs ilyen nevű kráter.");
            }
        }
        public static void Legnagyobb(List<Krater> kraterek)
        {
            double max = 0.0;
            string nev = "";
            foreach (Krater k in kraterek)
            {
                if (k.R > max)
                {
                    max = k.R;
                    nev = k.Nev;
                }
            }
            Console.WriteLine($"4. feladat\nA legnagyobb kráter neve és sugara: {nev} {max}");
        }
        public static double PontTav(Vector v1, Vector v2)
        {
            double tav = Math.Sqrt(Math.Pow((v1.X - v2.X), 2) + Math.Pow((v1.Y - v2.Y), 2));
            return tav;
        }
        public static void NincsKapcsolat(List<Krater> kraterek)
        {
            Console.Write("6. feladat\nKérem egy kráter nevét: ");
            List<string> nKozos = new List<string>();
            string keresett = Console.ReadLine();
            Krater k = kraterek[0];
            Console.Write("Nincs közös része: ");
            foreach (Krater krater in kraterek)
            {
                if (krater.Nev == keresett)
                {
                    k = krater;
                    break;
                }
            }
            foreach (Krater krater in kraterek)
            {
                if (krater == k) continue;
                double tav = PontTav(new Vector(k.X, k.Y), new Vector(krater.X, krater.Y));
                if (krater.R + k.R < tav)
                {
                    nKozos.Add(krater.Nev);
                }
            }
            foreach (string s in nKozos)
            {
                if (s == nKozos[nKozos.Count - 1])
                {
                    Console.Write($"{s}. ");
                }
                else Console.Write($"{s},");
            }
        }
        public static void Tartalmazza(List<Krater> kraterek)
        {
            Console.WriteLine("\n7. feladat");
            List<string> volt = new List<string>();
            for (int i = 0; i < Krater.RecordCount; i++)
            {
                for (int j = 1; j < Krater.RecordCount; j++) {
                    bool voltMar = false;
                    foreach (string item in volt) if (item.IndexOf(kraterek[i].Nev)> -1 && item.IndexOf(kraterek[j].Nev)>-1) voltMar = true;
                    if (voltMar) continue;
                    double tav = PontTav(new Vector(kraterek[i].X, kraterek[i].Y), new Vector(kraterek[j].X, kraterek[j].Y));
                    if (kraterek[i].R < kraterek[j].R)
                    {
                        if (kraterek[j].R - kraterek[i].R > tav)
                        {
                            Console.WriteLine($"A(z) {kraterek[j].Nev} kráter tartalmazza a(z) {kraterek[i].Nev} krátert.");
                            volt.Add($"{kraterek[j].Nev} {kraterek[i].Nev}");
                        }
                    }
                    else
                    {
                        if (kraterek[i].R - kraterek[j].R > tav)
                        {
                            Console.WriteLine($"A(z) {kraterek[i].Nev} kráter tartalmazza a(z) {kraterek[j].Nev} krátert.");
                            volt.Add($"{kraterek[i].Nev} {kraterek[j].Nev}");
                        }
                    }

                }
            }
        }
        public static void TeruletKiiras(List<Krater> kraterek)
        {
            StreamWriter sw = new StreamWriter("terulet.txt");
            sw.WriteLine("Terület\tNeve");
            foreach (Krater krater in kraterek) {
                sw.WriteLine($"{Math.Round(Math.Pow(krater.R, 2),2)}\t{krater.Nev}");
            }
            sw.Close();
        }
    }
}
