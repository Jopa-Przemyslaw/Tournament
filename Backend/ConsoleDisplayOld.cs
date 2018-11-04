using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend
{
    class ConsoleDisplayOld
    {
        public const int stalaZawodnikow = 5;
        public const int minimalnaIloscDruzynDoTurniejuSiatkowki = 8;
        public const int minimalnaIloscSedziowDoTurniejuSiatkowki = 2;

        public class Rozgrywki
        {
            /**
            *   Zwraca i pobiera punkty.
            */
            public int pkty { get; set; }
            /**
            *   Zwraca i pobiera nazwę drużyny zapisanej na turniej.
            */
            public string nazwa { get; set; }
            public Rozgrywki() { }
            /**
            *   Konstruktor.
            */
            public Rozgrywki(string nazwa) { this.nazwa = nazwa; }
            public override string ToString() { return nazwa; }
        }
        public class Siatkowka
        {
            private Referee sedziaGlowny;
            private Referee sedziaBoczny;
            private Rozgrywki druzynaX;
            private Rozgrywki druzynaY;
            public Siatkowka() { }
            /**
            *   Konstruktor.
            */
            public Siatkowka(Rozgrywki druzynaX, Rozgrywki druzynaY, Referee sedziaGlowny, Referee sedziaBoczny)
            {
                this.druzynaX = druzynaX; this.druzynaY = druzynaY; this.sedziaGlowny = sedziaGlowny; this.sedziaBoczny = sedziaBoczny;
            }
            public Rozgrywki MeczSiatkowki()
            {
                Random rnd = new Random();
                int losowanie = rnd.Next(0, 9);
                if (losowanie % 2 == 0)
                    return druzynaX;
                else
                    return druzynaY;
            }
        }
        public class DwaOgnie
        {
            private Referee sedziaGlowny;
            private Rozgrywki druzynaX;
            private Rozgrywki druzynaY;
            public DwaOgnie() { }
            /**
            *   Konstruktor.
            */
            public DwaOgnie(Rozgrywki druzynaX, Rozgrywki druzynaY, Referee sedziaGlowny)
            {
                this.druzynaX = druzynaX; this.druzynaY = druzynaY; this.sedziaGlowny = sedziaGlowny;
            }
            public Rozgrywki RozegrajMecz()
            {
                Random rnd = new Random();
                int losowanie = rnd.Next(0, 9);
                if (losowanie % 2 == 0)
                    return druzynaX;
                else
                    return druzynaY;
            }
        }

        public static void WyswietlMenu_Spis(string[] menuOpcji, int wybranaOpcja)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\tMENU \t \t  \t    ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("............................................");
            Console.ResetColor();
            for (int i = 0; i < menuOpcji.Length; i++)
            {
                if (wybranaOpcja == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(menuOpcji[i]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(menuOpcji[i]);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("............................................");
            Console.ResetColor();
        }
        public static void WyswietlListy_SpisDruzyn(List<Team> listaDruzyn, int wybranaLinia)
        {
            Console.Clear();
            for (int i = 0; i < listaDruzyn.Count(); i++)
            {
                if (wybranaLinia == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(listaDruzyn.ElementAt(i));
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(listaDruzyn.ElementAt(i));
            }
        }

        public static void StworzDruzyne(List<Team> listaDruzyn, string nazwa)
        {
            listaDruzyn.Add(new Team(nazwa, 23));
        }
        public static void UsunDruzyne(List<Team> listaDruzyn, int pozycja)
        {
            listaDruzyn.RemoveAt(pozycja);
        }
        public static void WyswietlDruzyny(List<Team> listaDruzyn)
        {
            int nr = 0;
            foreach (Team asd in listaDruzyn)
                Console.WriteLine(++nr + ".\t" + asd.name);
        }
        public static void DodajZawodnikaDoDruzyny(List<Team> listaDruzyn, int pozycja)
        {
            listaDruzyn.ElementAt(pozycja).AddPlayer("Kapitan", "Hak");
        }
        public static void DodajSedziego(List<Referee> listaSedziow, string imie, string nazwisko)
        {
            listaSedziow.Add(new Referee(imie, nazwisko));
        }
        public static void UsunSedziego(List<Referee> listaSedziow, int pozycja)
        {
            listaSedziow.RemoveAt(pozycja);
        }
        public static void WyswietlSedziow(List<Referee> listaSedziow)
        {
            int nr = 0;
            foreach (Referee sedzia in listaSedziow)
                Console.WriteLine(++nr + ".\t" + sedzia.GetName + " " + sedzia.GetSurname);
        }
        public static int DodajDruzyneDoTurnieju(List<Team> listaDruzyn, List<Rozgrywki> listaTurniejowa)
        {
            if (listaDruzyn.Any() == true)
            {
                int wybranaLinia = 0;
                while (true)
                {
                    WyswietlListy_SpisDruzyn(listaDruzyn, wybranaLinia);
                    ConsoleKeyInfo cki2 = Console.ReadKey();
                    switch (cki2.Key)
                    {
                        case ConsoleKey.Escape:
                            return 0;
                        case ConsoleKey.UpArrow:
                            if ((wybranaLinia - 1) < 0)
                                wybranaLinia = listaDruzyn.Count() - 1;
                            else
                                wybranaLinia--;
                            break;
                        case ConsoleKey.DownArrow:
                            if ((wybranaLinia + 1) > listaDruzyn.Count() - 1)
                                wybranaLinia = 0;
                            else
                                wybranaLinia++;
                            break;
                        case ConsoleKey.Enter:
                            if (listaTurniejowa.Exists(x => x.nazwa == listaDruzyn.ElementAt(wybranaLinia).name) == false)
                            {
                                Console.Clear();
                                for (int i = 0; i < listaDruzyn.Count(); i++)
                                {
                                    if (wybranaLinia == i)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine("Dodano do turnieju pomyslnie");
                                        Console.ResetColor();
                                    }
                                    else
                                        Console.WriteLine(listaDruzyn.ElementAt(i));
                                }
                                listaTurniejowa.Add(new Rozgrywki(listaDruzyn.ElementAt(wybranaLinia).name));//nazwaTu));
                            }
                            else
                                Console.WriteLine("***\nJuz dodane");
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Pusto, nie ma zadnych druzyn");
            }
            Thread.Sleep(1000);
            return 0;
        }

        public static string GenerujTurniejSiatkowki(List<Rozgrywki> listaTurniejowa, List<Referee> listaSedziow)
        {
            Console.Clear();
            int g = listaTurniejowa.Count, obieg = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  ***\t    Turniej siatkowki rozpoczety! \t***");
            Console.ResetColor();
            Random rnd = new Random();
            Rozgrywki jeden, dwa;
            Referee glowny, boczny;
            int dlugosc = listaTurniejowa.Count;
            Rozgrywki zwyciesca = listaTurniejowa.ElementAt(dlugosc - 1);
            List<Rozgrywki> poczatkowa = new List<Rozgrywki>();
            List<Rozgrywki> turniej = new List<Rozgrywki>();
            foreach (Rozgrywki rozgrywka in listaTurniejowa)
                poczatkowa.Add(rozgrywka);
            while (dlugosc > 0)
            {
                if (poczatkowa.Count == 2 && turniej.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("_____________________________________________________");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Final:");
                    Console.ResetColor();
                }
                else if ((poczatkowa.Count == 4 || poczatkowa.Count == 3) && (turniej.Count == 0 || turniej.Count == 1))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("_____________________________________________________");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Polfinaly:");
                    Console.ResetColor();
                }
                if (obieg == 0)
                {
                    if (g % 2 == 0)
                        obieg = g / 2;
                    else
                        obieg = g / 2 + 1;
                }
                if (poczatkowa.Count % 2 == 0 && poczatkowa.Count > 1)
                {
                    jeden = poczatkowa.ElementAt(poczatkowa.Count - 2);
                    dwa = poczatkowa.ElementAt(poczatkowa.Count - 1);
                    int x = rnd.Next(0, listaSedziow.Count / 2 - 1);
                    int y = rnd.Next(listaSedziow.Count / 2, listaSedziow.Count - 1);
                    glowny = listaSedziow.ElementAt(x);
                    boczny = listaSedziow.ElementAt(y);
                    Siatkowka siata = new Siatkowka(jeden, dwa, glowny, boczny);
                    zwyciesca = siata.MeczSiatkowki();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("_____________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine("Mecz pomiedzy: " + jeden + " i " + dwa + "\nSedziuja: " + glowny + " wraz z: " + boczny +
                                        "\nZakonczony zwyciestwem: " + zwyciesca);
                    turniej.Add(zwyciesca);
                    poczatkowa.RemoveAt(poczatkowa.Count - 1);
                    poczatkowa.RemoveAt(poczatkowa.Count - 1);
                }
                else if (poczatkowa.Count % 2 != 0 && poczatkowa.Count > 2)
                {
                    jeden = poczatkowa.ElementAt(poczatkowa.Count - 2);
                    dwa = poczatkowa.ElementAt(poczatkowa.Count - 1);
                    int x = rnd.Next(0, listaSedziow.Count / 2 - 1);
                    int y = rnd.Next(listaSedziow.Count / 2, listaSedziow.Count - 1);
                    glowny = listaSedziow.ElementAt(x);
                    boczny = listaSedziow.ElementAt(y);
                    Siatkowka siata = new Siatkowka(jeden, dwa, glowny, boczny);
                    zwyciesca = siata.MeczSiatkowki();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("_____________________________________________________");
                    Console.ResetColor();
                    Console.WriteLine("Mecz pomiedzy: " + jeden + " i " + dwa + "\nSedziuja: " + glowny + " wraz z: " + boczny +
                                        "\nZakonczony zwyciestwem: " + zwyciesca);
                    turniej.Add(zwyciesca);
                    if (poczatkowa.Count == 2)
                        turniej.Add(poczatkowa.ElementAt(2));
                    poczatkowa.RemoveAt(poczatkowa.Count - 1);
                    poczatkowa.RemoveAt(poczatkowa.Count - 1);
                }
                else if (poczatkowa.Count == 1)
                {
                    turniej.Add(poczatkowa.ElementAt(0));
                    poczatkowa.RemoveAt(0);
                }
                if (poczatkowa.Count == 0 && turniej.Count > 1)
                {
                    poczatkowa.Clear();
                    foreach (Rozgrywki asd in turniej)
                        if (poczatkowa.Exists(x => x.ToString() == asd.ToString()) == false)
                            poczatkowa.Add(asd);
                    turniej.Clear();
                    dlugosc = poczatkowa.Count;
                }
                else if (poczatkowa.Count == 0 && turniej.Count == 0)
                {
                    if (zwyciesca != null) return zwyciesca.ToString();
                    dlugosc = poczatkowa.Count;
                }
                else
                    dlugosc = poczatkowa.Count;
                obieg--;
            }
            zwyciesca.pkty++;
            return zwyciesca.ToString();
        }

        public static int WybierzZListyDruzyneIWykonajNaNiejOperacje(List<Team> listaDruzyn, string czynnosc)
        {
            int wybranaLinia = 0;
            while (true)
            {
                WyswietlListy_SpisDruzyn(listaDruzyn, wybranaLinia);
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.UpArrow:
                        if ((wybranaLinia - 1) < 0)
                            wybranaLinia = listaDruzyn.Count() - 1;
                        else
                            wybranaLinia--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((wybranaLinia + 1) > listaDruzyn.Count() - 1)
                            wybranaLinia = 0;
                        else
                            wybranaLinia++;
                        break;
                    case ConsoleKey.Enter:
                        if (czynnosc.ToLower() == "usun")
                        {
                            if (listaDruzyn.Any() == true)
                            {
                                Console.Clear();
                                for (int i = 0; i < listaDruzyn.Count(); i++)
                                {
                                    if (wybranaLinia == i)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Usunieto pomyslnie");
                                        Console.ResetColor();
                                    }
                                    else
                                        Console.WriteLine(listaDruzyn.ElementAt(i));
                                }
                                if (wybranaLinia < listaDruzyn.Count)
                                {
                                    UsunDruzyne(listaDruzyn, wybranaLinia);
                                    Thread.Sleep(1000);
                                }
                                else
                                    wybranaLinia--;
                            }
                            else
                            {
                                Console.WriteLine("Pusto, nie ma czego usuwac");
                                Thread.Sleep(1000);
                                return 0;
                            }
                        }
                        else if (czynnosc.ToLower() == "zwrocnr")
                            return wybranaLinia;
                        break;
                }
                Console.Clear();
            }
        }
        public static int WybierzZListySedziowIWykonajNaNiejOperacje(List<Referee> listaSedziow, string czynnosc)
        {
            int wybranaLinia = 0;
            while (true)
            {
                WyswietlListy_SpisSedziow(listaSedziow, wybranaLinia);
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.UpArrow:
                        if ((wybranaLinia - 1) < 0)
                            wybranaLinia = listaSedziow.Count() - 1;
                        else
                            wybranaLinia--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((wybranaLinia + 1) > listaSedziow.Count() - 1)
                            wybranaLinia = 0;
                        else
                            wybranaLinia++;
                        break;
                    case ConsoleKey.Enter:
                        if (czynnosc.ToLower() == "usun")
                        {
                            if (listaSedziow.Any() == true)
                            {
                                Console.Clear();
                                for (int i = 0; i < listaSedziow.Count(); i++)
                                {
                                    if (wybranaLinia == i)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Usunieto pomyslnie");
                                        Console.ResetColor();
                                    }
                                    else
                                        Console.WriteLine(listaSedziow.ElementAt(i));
                                }
                                if (wybranaLinia < listaSedziow.Count)
                                {
                                    UsunSedziego(listaSedziow, wybranaLinia);
                                    Thread.Sleep(1000);
                                }
                                else
                                    wybranaLinia--;
                            }
                            else
                            {
                                Console.WriteLine("Pusto, nie ma czego usuwac");
                                Thread.Sleep(1000);
                                return 0;
                            }
                        }
                        else if (czynnosc.ToLower() == "zwrocnr")
                            return wybranaLinia;
                        break;
                }
                Console.Clear();
            }
        }
        public static int WybierzZListyRozgrywekIWykonajNaNiejOperacje(List<Rozgrywki> listaRozgrywek, string czynnosc)
        {
            int wybranaLinia = 0;
            while (true)
            {
                WyswietlListy_SpisDruzynWTurnieju(listaRozgrywek, wybranaLinia);
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.Escape:
                        return 0;
                    case ConsoleKey.UpArrow:
                        if ((wybranaLinia - 1) < 0)
                            wybranaLinia = listaRozgrywek.Count() - 1;
                        else
                            wybranaLinia--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((wybranaLinia + 1) > listaRozgrywek.Count() - 1)
                            wybranaLinia = 0;
                        else
                            wybranaLinia++;
                        break;
                    case ConsoleKey.Enter:
                        if (czynnosc.ToLower() == "usun")
                        {
                            if (listaRozgrywek.Any() == true)
                            {
                                Console.Clear();
                                for (int i = 0; i < listaRozgrywek.Count(); i++)
                                {
                                    if (wybranaLinia == i)
                                    {
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Usunieto pomyslnie");
                                        Console.ResetColor();
                                    }
                                    else
                                        Console.WriteLine(listaRozgrywek.ElementAt(i));
                                }
                                if (wybranaLinia < listaRozgrywek.Count)
                                {
                                    listaRozgrywek.RemoveAt(wybranaLinia);
                                    Thread.Sleep(1000);
                                }
                                else
                                    wybranaLinia--;
                            }
                            else
                            {
                                Console.WriteLine("Pusto, nie ma czego usuwac");
                                Thread.Sleep(1000);
                                return 0;
                            }
                        }
                        else if (czynnosc.ToLower() == "zwrocnr")
                            return wybranaLinia;
                        break;
                }
                Console.Clear();
            }
        }
        public static void WyswietlListy_SpisSedziow(List<Referee> listaSedziow, int wybranaLinia)
        {
            Console.Clear();
            for (int i = 0; i < listaSedziow.Count(); i++)
            {
                if (wybranaLinia == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(listaSedziow.ElementAt(i));
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(listaSedziow.ElementAt(i));
            }
        }
        public static void WyswietlListy_SpisDruzynWTurnieju(List<Rozgrywki> listaTurniejowa, int wybranaLinia)
        {
            Console.Clear();
            for (int i = 0; i < listaTurniejowa.Count(); i++)
            {
                if (wybranaLinia == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkMagenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(listaTurniejowa.ElementAt(i));
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(listaTurniejowa.ElementAt(i));
            }
        }

        public static void Zapisz(List<Team> druzynyLista, List<Referee> sedziowieLista, List<Rozgrywki> turniejLista)
        {

        }
        public static void Wczytaj()
        {
            StringBuilder sb = new StringBuilder();
            StreamReader sr_druzyny = new StreamReader("zapisz_druzyny.txt");
        }
        public static void TabelaWynikow(List<Rozgrywki> listaTurniejow)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("| Druzyny:\t   Pkty:\t|");
            Console.ResetColor();
            for (int i = 0; i < listaTurniejow.Count; i++)
            {
                List<Rozgrywki> SortedList = listaTurniejow.OrderByDescending(o => o.pkty).ToList();
                Console.WriteLine("| " + SortedList.ElementAt(i).nazwa + "        \t" + SortedList.ElementAt(i).pkty + "\t|");
            }
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|_______________________________|");
            Console.ResetColor();
        }

        public static int RysujMenu(List<Team> listaDruzyn, List<Referee> listaSedziow, List<Rozgrywki> listaTurniejowa, string[] menuOpcji)
        {
            int wybranaOpcja = 0, nrDruzyny;
            while (true)
            {
                WyswietlMenu_Spis(menuOpcji, wybranaOpcja);
                ConsoleKeyInfo cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.Escape:
                        wybranaOpcja = menuOpcji.Length - 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (wybranaOpcja - 1 < 0)
                            wybranaOpcja = menuOpcji.Length - 1;
                        else
                            wybranaOpcja--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (wybranaOpcja + 1 > menuOpcji.Length - 1)
                            wybranaOpcja = 0;
                        else
                            wybranaOpcja++;
                        break;
                    case ConsoleKey.Enter:
                        if (menuOpcji[wybranaOpcja] == "Exit")
                            Environment.Exit(0);
                        else if (menuOpcji[wybranaOpcja] == "Stworz druzyne")
                        {
                            StworzDruzyne(listaDruzyn, "nazwa");
                            Console.WriteLine("Dodano pomyslnie!");
                            Thread.Sleep(1000);
                        }
                        else if (menuOpcji[wybranaOpcja] == "Usun druzyne")
                        {
                            WybierzZListyDruzyneIWykonajNaNiejOperacje(listaDruzyn, "Usun");
                        }
                        else if (menuOpcji[wybranaOpcja] == "Podglad druzyn")
                        {
                            Console.Clear();
                            Console.WriteLine("Aktualne wszystkie druzyny:");
                            if (listaDruzyn.Any() == true)
                                WyswietlDruzyny(listaDruzyn);
                            else
                                Console.WriteLine("Pusto, nie ma zadnej istniejacej druzyny");
                            Console.ReadKey();
                        }
                        else if (menuOpcji[wybranaOpcja] == "\nDodaj zawodnika")
                        {
                            Console.Clear();
                            nrDruzyny = WybierzZListyDruzyneIWykonajNaNiejOperacje(listaDruzyn, "ZwrocNr");
                            if (listaDruzyn.Count <= stalaZawodnikow && listaDruzyn.Any() == true)
                                DodajZawodnikaDoDruzyny(listaDruzyn, nrDruzyny);
                            else if (listaDruzyn.Any() == false)
                                Console.WriteLine("Nie ma zadnej istniejacej druzyny");
                            else
                                Console.WriteLine("***\nTa druzyna jest juz pelna");
                            Thread.Sleep(1000);
                        }
                        else if (menuOpcji[wybranaOpcja] == "Usun zawodnika")
                        {
                            Console.Clear();
                            if (listaDruzyn.Any() == true)
                            {
                                nrDruzyny = WybierzZListyDruzyneIWykonajNaNiejOperacje(listaDruzyn, "ZwrocNr");
                                listaDruzyn.ElementAt(nrDruzyny).RemovePlayer(nrDruzyny);
                            }
                            else
                                Console.WriteLine("Pusto, nie ma zadnej druzyny, ani zawodnikow");
                            Thread.Sleep(500);
                        }
                        else if (menuOpcji[wybranaOpcja] == "Podglad zawodnikow")
                        {
                            Console.Clear();
                            if (listaDruzyn.Any() == true)
                            {
                                nrDruzyny = WybierzZListyDruzyneIWykonajNaNiejOperacje(listaDruzyn, "ZwrocNr");
                                Console.Clear();
                                Console.WriteLine("Zawodnicy w druzynie \"" + listaDruzyn.ElementAt(nrDruzyny).name + "\": ");
                                if (listaDruzyn.ElementAt(nrDruzyny).ReturnPlayers().Any() == true)
                                    foreach (Player zawodnik in listaDruzyn.ElementAt(nrDruzyny).ReturnPlayers())
                                        Console.WriteLine($"{zawodnik.GetName} {zawodnik.GetSurname} rozegrane spotkania: {zawodnik.matchesPlayed}");
                                else
                                    Console.WriteLine("Pusto, nie ma aktualnie zadnych zawodnikow");
                                Console.ReadKey();
                            }
                            else
                                Console.WriteLine("Pusto, nie ma tutaj druzyn");
                            Thread.Sleep(1000);
                        }
                        else if (menuOpcji[wybranaOpcja] == "\nDodaj sedziego")
                        {
                            DodajSedziego(listaSedziow, "Sedzia", "Kalosz");
                            Console.WriteLine("Dodano pomyslnie!");
                            Thread.Sleep(1000);
                        }
                        else if (menuOpcji[wybranaOpcja] == "Usun sedziego") WybierzZListySedziowIWykonajNaNiejOperacje(listaSedziow, "Usun");
                        else if (menuOpcji[wybranaOpcja] == "Podglad sedziow")
                        {
                            Console.Clear();
                            Console.WriteLine("Aktualni wszyscy sedziowie: ");
                            if (listaSedziow.Any() == true)
                                WyswietlSedziow(listaSedziow);
                            else
                                Console.WriteLine("Pusto, nie ma zadnego sedziego");
                            Console.ReadKey();
                        }
                        else if (menuOpcji[wybranaOpcja] == "\nDodaj druzyne do turnieju") DodajDruzyneDoTurnieju(listaDruzyn, listaTurniejowa);
                        else if (menuOpcji[wybranaOpcja] == "Usun druzyne z turnieju") WybierzZListyRozgrywekIWykonajNaNiejOperacje(listaTurniejowa, "Usun");
                        else if (menuOpcji[wybranaOpcja] == "Wyswoietl druzyny biorace udzial w turnieju")
                        {
                            Console.Clear();
                            Console.WriteLine("Aktualne druzyny biorace udzial:");
                            if (listaTurniejowa.Any() == true)
                            {
                                int nr = 0;
                                foreach (Rozgrywki rozgrywka in listaTurniejowa)
                                    Console.WriteLine(++nr + ".\t" + rozgrywka.nazwa);
                            }
                            //WyswietlRozgrywki(listaTurniejowa);
                            else
                                Console.WriteLine("Pusto, nie ma zadnej druzyny do turnieju");
                            Console.ReadKey();

                        }
                        else if (menuOpcji[wybranaOpcja] == "\nGeneruj turniej siatkowki")
                        {
                            if (listaTurniejowa.Count >= minimalnaIloscDruzynDoTurniejuSiatkowki && listaSedziow.Count >= 2)
                            {
                                Console.WriteLine("\nTurniej zwycieza: " + GenerujTurniejSiatkowki(listaTurniejowa, listaSedziow));
                            }
                            else
                            {
                                //Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Warunki rozpoczecia rozgrywek nie sa spelnione!");
                                Console.ResetColor();
                                Console.Write("Potrzeba co najmniej 4 gotowych druzyn i 2 sedziow."
                                                + "\nAktualny stan wymaganych druzyn: " + listaTurniejowa.Count + "/" + minimalnaIloscDruzynDoTurniejuSiatkowki);
                                if (listaTurniejowa.Count < minimalnaIloscDruzynDoTurniejuSiatkowki)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" - niespelnione");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(" - spelnione");
                                }
                                Console.ResetColor();
                                Console.Write("Aktualny stan wymaganych sedziow: " + listaSedziow.Count + "/" + minimalnaIloscSedziowDoTurniejuSiatkowki);
                                if (listaSedziow.Count < minimalnaIloscSedziowDoTurniejuSiatkowki)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" - niespelnione");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(" - spelnione");
                                }
                                Console.ResetColor();
                            }
                            Console.ReadKey();
                        }
                        else if (menuOpcji[wybranaOpcja] == "Generuj turniej przeciagania liny")
                        {
                            if (listaTurniejowa.Count >= minimalnaIloscDruzynDoTurniejuSiatkowki && listaSedziow.Count >= 2)
                            {
                                Console.WriteLine("\nTurniej zwycieza: " + GenerujTurniejSiatkowki(listaTurniejowa, listaSedziow));
                            }
                            else
                            {
                                //Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Warunki rozpoczecia rozgrywek nie sa spelnione!");
                                Console.ResetColor();
                                Console.Write("Potrzeba co najmniej 4 gotowych druzyn i 1 sedzia."
                                                + "\nAktualny stan wymaganych druzyn: " + listaTurniejowa.Count + "/" + 1);
                                if (listaTurniejowa.Count < minimalnaIloscDruzynDoTurniejuSiatkowki)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" - niespelnione");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(" - spelnione");
                                }
                                Console.ResetColor();
                                Console.Write("Aktualny stan wymaganych sedziow: " + listaSedziow.Count + "/" + 1);
                                if (listaSedziow.Count < 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" - niespelnione");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(" - spelnione");
                                }
                                Console.ResetColor();
                            }
                            Console.ReadKey();
                        }
                        else if (menuOpcji[wybranaOpcja] == "Generuj turniej dwoch ogni")
                        {
                            if (listaTurniejowa.Count >= minimalnaIloscDruzynDoTurniejuSiatkowki && listaSedziow.Count >= 2)
                                Console.WriteLine("\nTurniej zwycieza: " + GenerujTurniejSiatkowki(listaTurniejowa, listaSedziow));
                            else
                            {
                                //Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Warunki rozpoczecia rozgrywek nie sa spelnione!");
                                Console.ResetColor();
                                Console.Write("Potrzeba co najmniej 4 gotowych druzyn i 1 sedzia."
                                                + "\nAktualny stan wymaganych druzyn: " + listaTurniejowa.Count + "/" + 1);
                                if (listaTurniejowa.Count < minimalnaIloscDruzynDoTurniejuSiatkowki)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" - niespelnione");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(" - spelnione");
                                }
                                Console.ResetColor();
                                Console.Write("Aktualny stan wymaganych sedziow: " + listaSedziow.Count + "/" + 1);
                                if (listaSedziow.Count < 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(" - niespelnione");
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine(" - spelnione");
                                }
                                Console.ResetColor();
                            }
                            Console.ReadKey();
                        }
                        else if (menuOpcji[wybranaOpcja] == "Wyswietl tabele wynikow")
                        {
                            TabelaWynikow(listaTurniejowa);
                            Console.ReadKey();
                        }
                        else if (menuOpcji[wybranaOpcja] == "\nZapisz")
                        {
                            Zapisz(listaDruzyn, listaSedziow, listaTurniejowa);
                            Console.WriteLine("Zapisano pomyslnie!");
                            Thread.Sleep(1000);
                        }
                        else if (menuOpcji[wybranaOpcja] == "Wczytaj")
                        {
                            Wczytaj();
                        }
                        break;
                }
                Console.Clear();
            }
        }
    }
}
