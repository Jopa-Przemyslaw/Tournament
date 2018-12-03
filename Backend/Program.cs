using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using static Backend.ConsoleCommunication.ConsoleDisplayOld;
using static Backend.ConsoleCommunication.ConsoleDisplaySystem;

namespace Backend
{
    class Program
    {
        public static List<Player> listOfPlayers = new List<Player>();
        public static List<Team> listOfTeams = new List<Team>();
        public static List<Referee> listOfReferees = new List<Referee>();
        public static List<Cup> listOfCups = new List<Cup>();
        static void Main(string[] args)
        {

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
            listOfTeams.Add(new Team("teamM", 23));
            listOfTeams.Add(new Team("teamN", 23));
            listOfTeams.Add(new Team("teamO", 23));
            listOfTeams.Add(new Team("teamP", 23));

            listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameA"));
            listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameB"));
            listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameC"));
            try
            {
                listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameD", listOfTeams.ElementAt(0)));
                listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameE", listOfTeams.Find(x => x.name == "teamE")));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            listOfTeams.ElementAt(1).AddPlayer(listOfPlayers.ElementAt(1));

            listOfReferees.Add(new Referee("Referee", "Noname0"));
            listOfReferees.Add(new Referee("Referee", "Noname1"));
            listOfReferees.Add(new Referee("Referee", "Noname2"));
            listOfReferees.Add(new Referee("Referee", "Noname3"));
            listOfReferees.Add(new Referee("Referee", "Noname4"));

            Cup cup = new Cup(listOfTeams, listOfReferees, "New Cup");
            listOfCups.Add(cup);
            foreach (Team team in listOfTeams)
                listOfCups.ElementAt(0).AddTeam(team);
            foreach (Referee referee in listOfReferees)
                listOfCups.ElementAt(0).AddReferee(referee);

            try
            {
                DrawMenu(ref listOfPlayers, ref listOfTeams, ref listOfReferees, ref listOfCups);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

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
