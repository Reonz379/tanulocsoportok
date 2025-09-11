using System;
using System.Collections.Generic;
using System.IO;

namespace Letra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Rolls> throws = new List<Rolls>();
            int asd = 0;
            string asdf = "";
            foreach (var item in File.ReadAllText("dobasok.txt").Split(", "))
            {
                asd += 1;
                asdf = asd + " + " + item;
                throws.Add(new Rolls(asdf));
            }

            Console.WriteLine("2. feladat");
            //foreach (var item in throws)
            //{
            //    Console.Write(item.Rollval + ", ");
            //}
            int curTile = 0;
            int ladder = 0;
            foreach (var item in throws)
            {
                curTile += item.Rollval;
                if (curTile % 10 == 0)
                {
                    ladder++;
                    curTile -= 3;
                }
                Console.Write(curTile + " ");
            }
            Console.WriteLine($"\n3. feladat\nA játék során {ladder} alkalommal lépett létrára.");
            Console.WriteLine($"4. feladat");
            if (curTile >= 45)
            {
                Console.WriteLine("A játékot befejezte.");
            }
            else
            {
                Console.WriteLine("A játékot abbahagyta.");
            }
            Console.ReadKey();
        }
    }
}