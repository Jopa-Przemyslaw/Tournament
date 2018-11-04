using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Backend.ConsoleDisplay;
using static Backend.ConsoleDisplaySystem;

namespace Backend
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> listOfTeams = new List<Team>();
            List<Referee> listOfReferees = new List<Referee>();

            listOfTeams.Add(new Team("teamA", 23));
            listOfTeams.Add(new Team("teamB", 23));
            listOfTeams.Add(new Team("teamC", 23));
            listOfTeams.Add(new Team("teamD", 23));
            listOfTeams.Add(new Team("teamE", 23));
            listOfTeams.Add(new Team("teamF", 23));
            listOfTeams.Add(new Team("teamG", 23));
            listOfTeams.Add(new Team("teamH", 23));
            listOfTeams.Add(new Team("teamI", 23));
            listOfTeams.Add(new Team("teamJ", 23));
            listOfTeams.Add(new Team("teamK", 23));
            listOfTeams.Add(new Team("teamL", 23));

            listOfTeams.ElementAt(0).AddPlayer("PlayerName", "PlayerSurnameA");
            listOfTeams.ElementAt(0).AddPlayer("PlayerName", "PlayerSurnameB");
            listOfTeams.ElementAt(0).AddPlayer("PlayerName", "PlayerSurnameC");


            listOfReferees.Add(new Referee("Sedzia", "Kalosz0"));
            listOfReferees.Add(new Referee("Sedzia", "Kalosz1"));
            listOfReferees.Add(new Referee("Sedzia", "Kalosz2"));
            listOfReferees.Add(new Referee("Sedzia", "Kalosz3"));
            listOfReferees.Add(new Referee("Sedzia", "Kalosz4"));

            FootballMatch footballMatch = new FootballMatch(new Referee("sedzia", "Glowny"),
                                                            new Team("druzynaA", 23), (listOfTeams.ElementAt(0)),
                                                            new Referee("Sedzia", "Boczny1"), new Referee("Sedzia", "Boczny2"));
            
            MatchEngine matchEngine = new MatchEngine();
            //var watch = Stopwatch.StartNew();
            matchEngine.SymulateFootballMatch(ref footballMatch);
            //watch.Stop();
            //Debug.WriteLine($"It tooks: {watch.ElapsedMilliseconds/1000}s.");
            Debug.WriteLine($"{footballMatch.ReturnTeamA().name} {footballMatch.GetScoreOfTeamA()} : {footballMatch.GetScoreOfTeamB()} {footballMatch.ReturnTeamB().name}. ");

            DrawMenu(ref listOfTeams, ref listOfReferees);

            #region Console Display Old
            //List<Rozgrywki> listaTurniejowa = new List<Rozgrywki>();
            //for (int i = 0; i < listOfTeams.Count; i++)
            //{
            //    listaTurniejowa.Add(new Rozgrywki(listOfTeams.ElementAt(i).name));
            //    int k = 0;
            //    while (k < stalaZawodnikow)
            //    {
            //        listOfTeams.ElementAt(i).AddPlayer(("imie" + (i + 1)), "nazwisko" + (k + 1));
            //        k++;
            //    }
            //}
            //RysujMenu(listOfTeams, listOfReferees, listaTurniejowa, new string[] { "Stworz druzyne", "Usun druzyne", "Podglad druzyn",
            //    "\nDodaj zawodnika", "Usun zawodnika", "Podglad zawodnikow",
            //    "\nDodaj sedziego", "Usun sedziego", "Podglad sedziow",
            //    "\nDodaj druzyne do turnieju", "Usun druzyne z turnieju", "Wyswoietl druzyny biorace udzial w turnieju",
            //    "\nGeneruj turniej siatkowki", "Generuj turniej przeciagania liny", "Generuj turniej dwoch ogni", "Wyswietl tabele wynikow",
            //    "\nZapisz", "Wczytaj", "Exit"});
            #endregion

        }

    }
}
//TODO: Rozgrywki
//DONE: Mecz
//TODO: Siatkowka
//TODO: DwaOgnie
//TODO: PrzeciaganieLiny
//DONE: Druzyna
//DONE: Czlowiek
//DONE: Zawodnik
//DONE: Sedzia
