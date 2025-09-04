using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kiadasok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Konyvek> konyvekLista = new List<Konyvek>();
            File.ReadAllLines("kiadas.txt").ToList().ForEach(x =>
            {
                var darabok = x.Split(';');
                konyvekLista.Add(new Konyvek(int.Parse(darabok[0]), int.Parse(darabok[1]), darabok[2] == "ma", darabok[3], int.Parse(darabok[4])));
            });
            Console.WriteLine("2. feladat:");
            Console.Write("Szerző: ");
            string szerzo = Console.ReadLine();
            Console.Write(konyvekLista.FindAll(x => x.Szerzo_Cim.Contains(szerzo)).ToList().Count == 0 ? "Nem adtak ki\n" : konyvekLista.FindAll(x => x.Szerzo_Cim.Contains(szerzo)).ToList().Count + " könykiadás\n");
            Console.WriteLine("3. feladat:");
            Console.WriteLine($"Legnagyobb példányszám: {konyvekLista.Max(x => x.Peldany)}, előfordult {konyvekLista.FindAll(x => x.Peldany == konyvekLista.Max(y => y.Peldany)).Count} alkalommal");
            Console.WriteLine("4. feladat:");
            var kulfoldi = konyvekLista.FindAll(x => x.Hazai == false).Where(x => x.Peldany >= 40000).ToList()[0];
            Console.WriteLine($"{kulfoldi.Ev}/{kulfoldi.NegyedEv}. {kulfoldi.Szerzo_Cim}");
            Console.WriteLine("5. feladat:");
            Console.WriteLine($"Év\tMagyar kiadás\tMagyar Példányszám\tKülföldi kiadás\tKülföldi példányszám");
            using (StreamWriter writer = new StreamWriter("tabla.html"))
            {
                writer.WriteLine("<table>");
                writer.WriteLine("<tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi kiadás</th><th>Külföldi példányszám</th></tr>");
                foreach (var item in konyvekLista.Select(y => y.Ev).Distinct())
                {
                    Console.WriteLine($"{item}\t\t{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == true).Count()}\t\t{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == true).Select(z => z.Peldany).ToList().Sum()}\t\t\t{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == false).Count}\t\t{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == false).Select(z => z.Peldany).ToList().Sum()}");
                    writer.WriteLine($"<tr><td>{item}</td><td>{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == true).Count()}</td><td>{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == true).Select(z => z.Peldany).ToList().Sum()}</td><td>{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == false).Count}</td><td>{konyvekLista.Where(z => z.Ev == item).ToList().FindAll(z => z.Hazai == false).Select(z => z.Peldany).ToList().Sum()}</td></tr>");
                }
                writer.WriteLine("</table>");
            }
            Console.WriteLine("6. feladat:");
            Console.WriteLine("Legalább kétszer, nagyobb példányszámban újra kiadott könyvek:");
            var ismetlodokonyvek = konyvekLista.GroupBy(x => x.Szerzo_Cim).Where(x => x.Count() > 2).ToList();
            foreach (var item in ismetlodokonyvek)
            {
                if (!item.OrderByDescending(x => x.Ev_Negyedev).ToList().All(x => x.Peldany <= item.OrderByDescending(y => y.Ev_Negyedev).ToList()[item.OrderByDescending(y => y.Peldany).ToList().Count() - 1].Peldany))
                {
                    if (konyvekLista.FindAll(x => x.Szerzo_Cim == item.Key).Skip(1).ToList().All(x => x.Peldany >= konyvekLista.FindAll(y => y.Szerzo_Cim == item.Key).First().Peldany))
                    {
                        Console.WriteLine(item.Key);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}