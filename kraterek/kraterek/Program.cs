using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kraterek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            List<Krater> kraterek = new List<Krater>();
            foreach (string line in File.ReadAllLines("felszin_tpont.txt"))
            {
                kraterek.Add(new Krater(line));
            }
            Console.WriteLine($"2. feladat\nA kráterek száma: {Krater.RecordCount}");
            Console.Write("3. feladat\nAdjon meg egy kráternevet: ");
            Krater.Kereses(Console.ReadLine(), kraterek);
            Krater.Legnagyobb(kraterek);
            Krater.NincsKapcsolat(kraterek);
            Krater.Tartalmazza(kraterek);
            Krater.TeruletKiiras(kraterek);
            Console.ReadLine();

        }

    }
}
