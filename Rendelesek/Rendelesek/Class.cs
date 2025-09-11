using System.Collections.Generic;
using System.IO;
using System;

public class Termek
{
    public string Kod;
    public string Nev;
    public int Ar;
    public int Keszlet;
}

public class Rendeles
{
    public int Szam;
    public string Email;
    public Dictionary<string, int> Termekek;

    public Rendeles()
    {
        Termekek = new Dictionary<string, int>();
    }
}

public class Adatok
{
    public static Dictionary<string, Termek> termekek = new Dictionary<string, Termek>();
    public static List<Rendeles> rendelesek = new List<Rendeles>();

    public static void RaktarBetoltes()
    {
        foreach (string sor in File.ReadAllLines("raktar.csv"))
        {
            string[] adatok = sor.Split(';');
            termekek[adatok[0]] = new Termek
            {
                Kod = adatok[0],
                Nev = adatok[1],
                Ar = int.Parse(adatok[2]),
                Keszlet = int.Parse(adatok[3])
            };
        }
    }

    public static void RendelesekBetoltes()
    {
        Rendeles rendeles = null;

        foreach (string sor in File.ReadAllLines("rendeles.csv"))
        {
            string[] adatok = sor.Split(';');

            if (adatok[0] == "M")
            {
                rendeles = new Rendeles
                {
                    Szam = int.Parse(adatok[2]),
                    Email = adatok[3]
                };
                rendelesek.Add(rendeles);
            }
            else if (adatok[0] == "T")
            {
                if (rendeles.Termekek.ContainsKey(adatok[2]))
                    rendeles.Termekek[adatok[2]] += int.Parse(adatok[3]);
                else
                    rendeles.Termekek[adatok[2]] = int.Parse(adatok[3]);
            }
        }
    }
}