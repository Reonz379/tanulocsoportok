/*
 * ========================================
 *              Made By Vince
 * ========================================
 */

using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main()
    {
        Adatok.RaktarBetoltes();
        Adatok.RendelesekBetoltes();
        RendelesekFeldolgozasa();
    }

    static void RendelesekFeldolgozasa()
    {
        List<string> levelek = new List<string>();
        Dictionary<string, int> beszerzesek = new Dictionary<string, int>();

        foreach (Rendeles rendeles in Adatok.rendelesek)
        {
            bool teljesitheto = true;
            int osszErtek = 0;

            foreach (var tetel in rendeles.Termekek)
            {
                if (!Adatok.termekek.ContainsKey(tetel.Key) || Adatok.termekek[tetel.Key].Keszlet < tetel.Value)
                {
                    teljesitheto = false;
                    break;
                }
                osszErtek += Adatok.termekek[tetel.Key].Ar * tetel.Value;
            }

            if (teljesitheto)
            {
                foreach (var tetel in rendeles.Termekek)
                    Adatok.termekek[tetel.Key].Keszlet -= tetel.Value;

                levelek.Add(rendeles.Email + ";A rendelését két napon belül szállítjuk. A rendelés értéke: " + osszErtek + " Ft");
            }
            else
            {
                levelek.Add(rendeles.Email + ";A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.");

                foreach (var tetel in rendeles.Termekek)
                {
                    int jelenlegiKeszlet = Adatok.termekek.ContainsKey(tetel.Key) ? Adatok.termekek[tetel.Key].Keszlet : 0;
                    int szuksegesMennyiseg = tetel.Value - jelenlegiKeszlet;

                    if (szuksegesMennyiseg > 0)
                    {
                        if (!beszerzesek.ContainsKey(tetel.Key) || beszerzesek[tetel.Key] < szuksegesMennyiseg)
                            beszerzesek[tetel.Key] = szuksegesMennyiseg;
                    }
                }
            }
        }

        File.WriteAllLines("levelek.csv", levelek);

        List<string> beszerzesList = new List<string>();
        foreach (var besz in beszerzesek)
            beszerzesList.Add(besz.Key + ";" + besz.Value);
        File.WriteAllLines("beszerzes.csv", beszerzesList);
    }
}