using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend
{
    class ConsoleDisplaySystem
    {
        /// <summary>
        /// The <see cref="string"/> <see cref="Array"/> of options in menu.
        /// </summary>
        private static readonly string[] optionsMenu = new string[] { "Create team", "Delete team", "Teams preview",
                "\nCreate player", "Create player with team", "Add player to a team", "Remove player from team", "Remove player", "Players preview",
                "\nAdd referee", "Remove referee", "Referee preview",
                "\nCreate new cup", "Sign up team for a cup", "Sign up referee for a cup", "Check out teams of a cup", "Cup teams preview", "Cup referees preview", "Cup's referees preview",
                "\nStart a football cup", "Show cups scoreboard",
                "\nComing soon...", "Coming soon...", "Exit" };
        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="listOfTeams">The list of <see cref="Team"/>s.</param>
        /// <returns>Nothing. Endless true while loop. Exits on command 'Environment.Exit(0);'.</returns>
        public static int DrawMenu(ref List<Player> listOfPlayers, ref List<Team> listOfTeams, ref List<Referee> listOfReferees, ref List<Cup> listOfCups)
        {
            Console.CursorVisible = false;
            int choosenOption = 0;
            while (true)
            {
                DisplayMenuHeader("MENU", "Choose your options. Use arrows to navigate.");
                DisplayMenu(optionsMenu, choosenOption);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        choosenOption = optionsMenu.Length - 1;
                        break;
                    case ConsoleKey.UpArrow:
                        if (choosenOption - 1 < 0)
                            choosenOption = optionsMenu.Length - 1;
                        else
                            choosenOption--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (choosenOption + 1 > optionsMenu.Length - 1)
                            choosenOption = 0;
                        else
                            choosenOption++;
                        break;
                    case ConsoleKey.Enter:
                        if (optionsMenu[choosenOption] == "Exit")
                            Environment.Exit(0);
                        //*********************** TEAM PARAGRAPH ***********************\\
                        else if (optionsMenu[choosenOption] == "Create team")
                        {
                            CreateTeamInMenu(ref listOfTeams);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Delete team")
                        {
                            int x = SelectTeamIndex(listOfTeams);
                            if (x >= 0)
                            {
                                foreach(Player player in listOfTeams.ElementAt(x).playersList)
                                {
                                    player.SetTeam(null);
                                }
                                foreach(Cup cup in listOfCups)
                                {
                                    cup.RemoveTeam(listOfTeams.ElementAt(x));
                                }
                                listOfTeams.RemoveAt(x);
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Teams preview")
                        {
                            int w = -1;
                            while (w == -1)
                            {
                                int x = SelectTeamIndex(listOfTeams);
                                if (x >= 0)
                                {
                                    try
                                    {
                                        w = DisplayTeamStats(listOfTeams.ElementAt(x));
                                    }
                                    catch (Exception e)
                                    {
                                        Debug.WriteLine(e.Message);
                                    }
                                }
                                else
                                {
                                    w = -2;
                                }
                                Thread.Sleep(500);
                            }
                        }
                        //*********************** PLAYER PARAGRAPH ***********************\\
                        else if (optionsMenu[choosenOption] == "\nCreate player")
                        {
                            CreatePlayerInMenu(ref listOfPlayers);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Create player with team")
                        {
                            int x = SelectTeamIndex(listOfTeams);
                            if (x >= 0)
                            {
                                CreatePlayerInTeamInMenu(ref listOfPlayers, ref listOfTeams, x);
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Add player to a team")
                        {
                            int w = -1;
                            while (w == -1)
                            {
                                int x = SelectPlayerIndex(listOfPlayers);
                                if (x >= 0)
                                {
                                    if (listOfPlayers.ElementAt(x).playerTeam == null)
                                    {
                                        int y = SelectTeamIndex(listOfTeams);
                                        if (y >= 0)
                                        {
                                            listOfPlayers.ElementAt(x).SetTeam(listOfTeams.ElementAt(y));
                                        }
                                    }
                                    else
                                    {
                                        DisplayFailure(listOfPlayers.Count + 4, "This player already has a team.");
                                    }
                                }
                                else
                                {
                                    w = -2;
                                }
                                Thread.Sleep(500);
                            }
                        }
                        else if (optionsMenu[choosenOption] == "Remove player from team")
                        {
                            int w = -1;
                            while (w == -1)
                            {
                                int x = SelectPlayerIndex(listOfPlayers);
                                if (x >= 0)
                                {
                                    if (listOfPlayers.ElementAt(x).playerTeam != null)
                                    {
                                        listOfPlayers.ElementAt(x).playerTeam.playersList.Remove(listOfPlayers.ElementAt(x));
                                        listOfPlayers.ElementAt(x).SetTeam(null);
                                    }
                                    else
                                    {
                                        DisplayFailure(listOfPlayers.Count + 4, "This player has no team.");
                                    }
                                }
                                else
                                {
                                    w = -2;
                                }
                                Thread.Sleep(500);
                            }
                        }
                        else if (optionsMenu[choosenOption] == "Remove player")
                        {
                            int w = -1;
                            while (w == -1)
                            {
                                int x = SelectPlayerIndex(listOfPlayers);
                                if (x >= 0)
                                {
                                    if (listOfPlayers.ElementAt(x).playerTeam != null)
                                    {
                                        listOfPlayers.ElementAt(x).playerTeam.playersList.Remove(listOfPlayers.ElementAt(x));
                                    }
                                    listOfPlayers.RemoveAt(x);
                                }
                                else
                                {
                                    w = -2;
                                }
                                Thread.Sleep(500);
                            }
                        }
                        else if (optionsMenu[choosenOption] == "Players preview")
                        {
                            int x = SelectPlayerIndex(listOfPlayers);
                            Thread.Sleep(500);
                        }
                        //*********************** REFEREE PARAGRAPH ***********************\\
                        else if (optionsMenu[choosenOption] == "\nAdd referee")
                        {
                            CreateRefereeInMenu(ref listOfReferees);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Remove referee")
                        {
                            int x = SelectRefereeIndex(listOfReferees);
                            if (x >= 0)
                            {
                                foreach(Cup cup in listOfCups)
                                {
                                    cup.RemoveReferee(listOfReferees.ElementAt(x));
                                }
                                listOfReferees.RemoveAt(x);
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Referee preview")
                        {
                            SelectRefereeIndex(listOfReferees);
                            Thread.Sleep(500);
                        }
                        //*********************** CUP PARAGRAPH ***********************\\
                        else if (optionsMenu[choosenOption] == "\nCreate new cup")
                        {
                            CreateCupInMenu(ref listOfCups);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Sign up team for a cup")
                        {
                            int x = SelectCupIndex(listOfCups);
                            if (x >= 0 && !listOfCups.ElementAt(x).isFinished)
                            {
                                int y = SelectTeamIndex(listOfTeams);
                                if (y >= 0)
                                {
                                    listOfCups.ElementAt(x).AddTeam(listOfTeams.ElementAt(y));
                                }
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Sign up referee for a cup")
                        {
                            int x = SelectCupIndex(listOfCups);
                            if (x >= 0 && !listOfCups.ElementAt(x).isFinished)
                            {
                                int y = SelectRefereeIndex(listOfReferees);
                                if (y >= 0)
                                {
                                    listOfCups.ElementAt(x).AddReferee(listOfReferees.ElementAt(y));
                                }
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Check out teams of a cup")
                        {
                            int x = SelectCupIndex(listOfCups);
                            if (x >= 0 && !listOfCups.ElementAt(x).isFinished)
                            {
                                int y = SelectTeamIndex(listOfCups.ElementAt(x).listOfTeamsInCup);
                                if (y >= 0)
                                {
                                    listOfCups.ElementAt(x).RemoveTeam(listOfCups.ElementAt(x).listOfTeamsInCup.ElementAt(y));
                                }
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Cup teams preview")
                        {
                            int w = -1;
                            while (w == -1)
                            {
                                int x = SelectCupIndex(listOfCups);
                                if (x >= 0)
                                {
                                    w = SelectTeamIndex(listOfCups.ElementAt(x).listOfTeamsInCup);
                                }
                                else
                                {
                                    w = -2;
                                }
                                Thread.Sleep(500);
                            }
                        }
                        else if (optionsMenu[choosenOption] == "Cup referees preview")
                        {
                            int w = -1;
                            while (w == -1)
                            {
                                int x = SelectCupIndex(listOfCups);
                                if (x >= 0)
                                {
                                    w = SelectRefereeIndex(listOfCups.ElementAt(x).listOfRefereesInCup);
                                }
                                else
                                {
                                    w = -2;
                                }
                                Thread.Sleep(500);
                            }
                        }
                        //*********************** TOURNAMENT PARAGRAPH ***********************\\
                        else if (optionsMenu[choosenOption] == "\nStart a football cup")
                        {
                            int x = SelectCupIndex(listOfCups);
                            if (x >= 0)
                            {
                                try
                                {
                                    var xd = listOfCups.ElementAt(x).StartFootballCup();
                                }
                                catch (Exception e)
                                {
                                    DisplayFailure(1, e.Message);
                                    Debug.WriteLine(e.Message + " | " + e.GetType() + " | " + e.TargetSite);
                                    Thread.Sleep(500);
                                    Console.ReadKey();
                                }
                            }
                        }
                        else if (optionsMenu[choosenOption] == "Show cups scoreboard")
                        {
                            DisplayCupsScoreboard(listOfTeams);
                            Thread.Sleep(500);
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// Displays the menu header.
        /// </summary>
        /// <param name="menuHeader">The menu header title.</param>
        /// <param name="legend">The short legend.</param>
        private static void DisplayMenuHeader(string menuHeader, string legend)
        {
            Console.Clear();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t    ");
            Console.SetCursorPosition(23 - menuHeader.Length / 2 - 1, 0);
            Console.WriteLine(menuHeader);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(legend + "\n" + "............................................");
            Console.ResetColor();
        }
        /// <summary>
        /// Displays the menu footer.
        /// </summary>
        private static void DisplayMenuFooter()
        {
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("............................................");
            Console.ResetColor();
        }
        /// <summary>
        /// Displays the chooseable menu with options.
        /// </summary>
        /// <param name="optionsMenu">The <see cref="string"/> <see cref="Array"/> of menu options.</param>
        /// <param name="choosenOption">Currently highlighted option.</param>
        private static void DisplayMenu(string[] optionsMenu, int choosenOption)
        {
            for (int i = 0; i < optionsMenu.Length; i++)
            {
                if (choosenOption == i)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(optionsMenu[i]);
                    Console.ResetColor();
                }
                else
                    Console.WriteLine(optionsMenu[i]);
            }
        }
        /// <summary>
        /// Displays the success info.
        /// </summary>
        /// <param name="y">The y parameter describes location in vertical axis. For eg. '0' is the top, '1' is first line in console window.</param>
        /// <param name="successDescription">The success description.</param>
        private static void DisplaySuccess(int y, string successDescription)
        {
            Console.SetCursorPosition(0, y);
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t    ");
            Console.SetCursorPosition(23 - successDescription.Length / 2 - 1, y);
            Console.WriteLine(successDescription);
            Console.ResetColor();
        }
        /// <summary>
        /// Displays the failure info.
        /// </summary>
        /// <param name="y">The y parameter describes location in vertical axis. For eg. '0' is the top, '1' is first line in console window.</param>
        /// <param name="failureDescription">The failure description.</param>
        private static void DisplayFailure(int y, string failureDescription)
        {
            Console.SetCursorPosition(0, y);
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t\t\t\t    ");
            Console.SetCursorPosition(23 - failureDescription.Length / 2 - 1, y);
            Console.WriteLine(failureDescription);
            Console.ResetColor();
        }
        /// <summary>
        /// Displays the <see cref="Team"/> stats.
        /// </summary>
        /// <param name="team">The <see cref="Team"/>.</param>
        /// <returns>Returns 1 in the end.</returns>
        private static int DisplayTeamStats(Team team)
        {
            int choosen = 0;
            string[] teamStats = new string[8];
            teamStats[0] = "Matches played:\t\t" + team.matchesPlayed;
            teamStats[1] = "Matches won:\t\t" + team.wins;
            teamStats[2] = "Matches lost:\t\t" + team.lost;
            teamStats[3] = "Matches drawn:\t\t" + team.draws;
            teamStats[4] = "Goals scored:\t\t" + team.goalsScored;
            teamStats[5] = "Goals lost:\t\t" + team.goalsLost;
            teamStats[6] = "Tournaments won:\t" + team.tournamentsWon;
            teamStats[7] = "Players in team:\t" + team.ReturnTeamCount() + "/" + team.playersList.Capacity;
            while (true)
            {
                DisplayMenuHeader($"{team.name} statistics", "Use 'Enter' to leave 'Esc' to go back.");
                DisplayMenu(teamStats, choosen);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(teamStats.Length + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = teamStats.Length - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > teamStats.Length - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(teamStats.Length + 4, "action successfull");
                        return choosen;
                }
            }

        }
        /// <summary>
        /// Displays the <see cref="Cup" />s scoreboard of <see cref="Team"/>s and numbers of tournaments they have won. List sorted by tournament points.
        /// </summary>
        /// <param name="listOfTeams">The list of <see cref="Team" />s.</param>
        /// <returns>
        /// Returns 1 in the end.
        /// </returns>
        private static int DisplayCupsScoreboard(List<Team> listOfTeams)
        {
            int choosen = 0, i = 0;
            List<Team> sortedListOfTeams = new List<Team>(listOfTeams.OrderByDescending(raw => raw.tournamentsWon));

            string[] cupScoreboard = new string[listOfTeams.Count()];
            string[,] xd = new string[listOfTeams.Count(), 2];

            foreach (Team team in sortedListOfTeams)
            {
                xd[i, 0] = team.name;
                xd[i, 1] = team.tournamentsWon.ToString();
                i++;
            }
            for (i = 0; i < listOfTeams.Count(); i++)
                cupScoreboard[i] = xd[i, 0] + ":\t" + xd[i, 1];

            while (true)
            {
                DisplayMenuHeader($"Cups scoreboard", "Use 'Enter' or 'Esc' to go back.");
                DisplayMenu(cupScoreboard, choosen);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(cupScoreboard.Length + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = cupScoreboard.Length - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > cupScoreboard.Length - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(cupScoreboard.Length + 4, "action successfull");
                        return choosen;
                }
            }
        }
        /// <summary>
        /// Creates the <see cref="Team"/> in menu.
        /// </summary>
        /// <param name="listOfTeams">The list of <see cref="Team"/>s.</param>
        /// <returns>Returns 1 in the end.</returns>
        private static int CreateTeamInMenu(ref List<Team> listOfTeams)
        {
            DisplayMenuHeader("Create Team Menu", "Type new name and confirm by 'Enter'.");
            Console.WriteLine("Team name: ");
            DisplayMenuFooter();
            Console.SetCursorPosition(11, 3);
            string newName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newName))
            {
                DisplayFailure(5, "can not be null or white spaced");
                Console.SetCursorPosition(11, 3);
                newName = Console.ReadLine();
            }
            listOfTeams.Add(new Team(newName, 11));
            DisplaySuccess(5, "action successfull");
            return 1;
        }
        /// <summary>
        /// Creates the <see cref="Referee"/> in menu.
        /// </summary>
        /// <param name="listOfReferees">The list of <see cref="Referee"/>s.</param>
        /// <returns>Returns 1 in the end.</returns>
        private static int CreateRefereeInMenu(ref List<Referee> listOfReferees)
        {
            DisplayMenuHeader("Create Referee Menu", "Type new name and surname. Confirm by 'Enter'.");
            Console.WriteLine("Referee name: ");
            Console.WriteLine("Referee surname: ");
            DisplayMenuFooter();
            Console.SetCursorPosition(14, 3);
            string newName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newName))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(14, 3);
                newName = Console.ReadLine();
            }
            Console.SetCursorPosition(17, 4);
            string newSurname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newSurname))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(17, 4);
                newSurname = Console.ReadLine();
            }
            listOfReferees.Add(new Referee(newName, newSurname));
            DisplaySuccess(6, "action successfull");
            return 1;
        }
        /// <summary>
        /// Creates the new <see cref="Player"/> in menu.
        /// </summary>
        /// <param name="listOfPlayers">The list of <see cref="Player"/>s.</param>
        /// <returns>Returns 1 in the end.</returns>
        private static int CreatePlayerInMenu(ref List<Player> listOfPlayers)
        {
            DisplayMenuHeader("Create Player Menu", "Type new name and surname. Confirm by 'Enter'.");
            Console.WriteLine("Player name: ");
            Console.WriteLine("Player surname: ");
            DisplayMenuFooter();
            Console.SetCursorPosition(13, 3);
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(13, 3);
                name = Console.ReadLine();
            }
            Console.SetCursorPosition(16, 4);
            string surname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(surname))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(16, 4);
                surname = Console.ReadLine();
            }

            listOfPlayers.Add(new Player(name, surname));
            DisplaySuccess(6, "action successfull");
            return 1;
        }
        /// <summary>
        /// Creates the <see cref="Player" /> in selected <see cref="Team" /> in menu.
        /// </summary>
        /// <param name="listOfPlayers">The list of <see cref="Player"/>s.</param>
        /// <param name="listOfTeams">The list of <see cref="Team" />s.</param>
        /// <param name="teamIndex">Index of the <see cref="Team" /> in list.</param>
        /// <returns>
        /// Returns 1 in the end.
        /// </returns>
        private static int CreatePlayerInTeamInMenu(ref List<Player> listOfPlayers, ref List<Team> listOfTeams, int teamIndex)
        {
            DisplayMenuHeader("Create Player with Team Menu", "Type new name and surname. Confirm by 'Enter'.");
            Console.WriteLine("Player name: ");
            Console.WriteLine("Player surname: ");
            DisplayMenuFooter();
            Console.SetCursorPosition(13, 3);
            string name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(13, 3);
                name = Console.ReadLine();
            }
            Console.SetCursorPosition(16, 4);
            string surname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(surname))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(16, 4);
                surname = Console.ReadLine();
            }
            listOfPlayers.Add(new Player(name, surname, listOfTeams.ElementAt(teamIndex)));
            DisplaySuccess(6, "action successfull");
            return 1;
        }
        /// <summary>
        /// Creates the new <see cref="Cup"/> in menu.
        /// </summary>
        /// <param name="listOfCups">The list of <see cref="Cup"/>s.</param>
        /// <returns>Returns 1 in the end.</returns>
        private static int CreateCupInMenu(ref List<Cup> listOfCups)
        {
            DisplayMenuHeader("Create Cup Menu", "Type new name and confirm by 'Enter'");
            Console.WriteLine("Cup name: ");
            DisplayMenuFooter();
            Console.SetCursorPosition(10, 3);
            string newName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newName))
            {
                DisplayFailure(5, "can not be null or white spaced");
                Console.SetCursorPosition(11, 3);
                newName = Console.ReadLine();
            }
            listOfCups.Add(new Cup(newName));
            DisplaySuccess(5, "action successfull");
            return 1;
        }
        /// <summary>
        /// Selects the index of the <see cref="Player"/>.
        /// </summary>
        /// <param name="listOfPlayers">The list of <see cref="Player"/>s.</param>
        /// <returns>Returns <see cref="Player"/>'s index in the list.</returns>
        private static int SelectPlayerIndex(List<Player> listOfPlayers)
        {
            int choosen = 0, i = 0;
            string[] players = new string[listOfPlayers.Count()];
            foreach (Player player in listOfPlayers)
            {
                players[i] = player.GetName + " " + player.GetSurname + " | "
                    + ((player.playerTeam != null) ? player.playerTeam.name : "no team");
                i++;
            }
            while (true)
            {
                DisplayMenuHeader("Players List", "Use 'Enter' to select and 'Esc' to go back.");
                DisplayMenu(players, choosen);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(listOfPlayers.Count() + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = listOfPlayers.Count() - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > listOfPlayers.Count() - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(listOfPlayers.Count() + 4, "action successfull");
                        return choosen;
                }
            }
        }
        /// <summary>
        /// Selects the index of the <see cref="Team"/>.
        /// </summary>
        /// <param name="listOfTeams">The list of <see cref="Team"/>s.</param>
        /// <returns>Returns <see cref="Team"/>'s index in the list.</returns>
        private static int SelectTeamIndex(List<Team> listOfTeams)
        {
            int choosen = 0, i = 0;
            string[] teams = new string[listOfTeams.Count()];
            foreach (Team team in listOfTeams)
            {
                teams[i] = team.name;
                i++;
            }
            while (true)
            {
                DisplayMenuHeader("Team List", "Use 'Enter' to select and 'Esc' to go back.");
                DisplayMenu(teams, choosen);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(listOfTeams.Count() + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = listOfTeams.Count() - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > listOfTeams.Count() - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(listOfTeams.Count() + 4, "action successfull");
                        return choosen;
                }
            }
        }
        /// <summary>
        /// Selects the index of the <see cref="Player"/>.
        /// </summary>
        /// <param name="team">The <see cref="Team"/>.</param>
        /// <returns>Returns <see cref="Player"/>'s index in the list.</returns>
        private static int SelectPlayerIndex(Team team)
        {
            int choosen = 0, i = 0;
            string[] players = new string[team.GetPlayers().Count()];
            foreach (Player player in team.GetPlayers())
            {
                players[i] = player.GetName + " " + player.GetSurname + "\t" + player.matchesPlayed + " " + player.goalsScored + " " + player.trophiesWon;
                i++;
            }
            while (true)
            {
                DisplayMenuHeader($"Players of {team.name}", "Names and sunames\t\tMP / GS / TS");
                DisplayMenu(players, choosen);
                DisplayMenuFooter();
                //Console.WriteLine("Name\t\tsurname\t\tMP / GS / TG");
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(team.GetPlayers().Count() + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = team.GetPlayers().Count() - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > team.GetPlayers().Count() - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(team.GetPlayers().Count() + 4, "action successfull");
                        return choosen;
                }
            }
        }
        /// <summary>
        /// Selects the index of the <see cref="Referee"/>.
        /// </summary>
        /// <param name="listOfReferees">The list of <see cref="Referee"/>s.</param>
        /// <returns>Returns <see cref="Referee"/>'s index in the list.</returns>
        private static int SelectRefereeIndex(List<Referee> listOfReferees)
        {
            int choosen = 0, i = 0;
            string[] referees = new string[listOfReferees.Count()];
            foreach (Referee referee in listOfReferees)
            {
                referees[i] = referee.GetName + " " + referee.GetSurname;
                i++;
            }
            while (true)
            {
                DisplayMenuHeader("Team List", "Use 'Enter' to select and 'Esc' to go back.");
                DisplayMenu(referees, choosen);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(listOfReferees.Count() + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = listOfReferees.Count() - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > listOfReferees.Count() - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(listOfReferees.Count() + 4, "action successfull");
                        return choosen;
                }
            }
        }
        /// <summary>
        /// Selects the index of the <see cref="Cup"/>.
        /// </summary>
        /// <param name="listOfCups">The list of <see cref="Cup"/>s.</param>
        /// <returns>Returns <see cref="Cup"/>'s index in the list.</returns>
        private static int SelectCupIndex(List<Cup> listOfCups)
        {
            int choosen = 0, i = 0;
            string[] cups = new string[listOfCups.Count()];
            foreach (Cup cup in listOfCups)
            {
                if (cup.isFinished)
                    cups[i] = cup.name + " | cup finished";
                else
                    cups[i] = cup.name;
                i++;
            }
            while (true)
            {
                DisplayMenuHeader("Cup List", "Use 'Enter' to select and 'Esc' to go back.");
                DisplayMenu(cups, choosen);
                DisplayMenuFooter();
                ConsoleKeyInfo CKI = Console.ReadKey();
                switch (CKI.Key)
                {
                    case ConsoleKey.Escape:
                        DisplayFailure(listOfCups.Count() + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = listOfCups.Count() - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > listOfCups.Count() - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(listOfCups.Count() + 4, "action successfull");
                        return choosen;
                }
            }
        }
    }
}
