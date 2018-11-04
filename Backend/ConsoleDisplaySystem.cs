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
                "\nAdd player", "Remove player", "Players preview",
                "\nAdd referee", "Remove referee", "Referee preview",
                "\nSign up team for a cup", "Coming soon...", "Coming soon...",
                "\nComing soon...", "Coming soon...", "Coming soon...", "Coming soon...",
                "\nComing soon...", "Coming soon...", "Exit" };
        /// <summary>
        /// Draws the menu.
        /// </summary>
        /// <param name="listOfTeams">The list of <see cref="Team"/>s.</param>
        /// <returns>Nothing. Endless true while loop. Exits on command 'Environment.Exit(0);'.</returns>
        public static int DrawMenu(ref List<Team> listOfTeams, ref List<Referee> listOfReferees)
        {
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
                        //*********************** TEAM PARAGRAPH *****************************\\
                        else if (optionsMenu[choosenOption] == "Create team")
                        {
                            CreateTeamInMenu(ref listOfTeams);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Delete team")
                        {
                            int x = SelectTeamIndex(listOfTeams);
                            if (x >= 0)
                                listOfTeams.RemoveAt(x);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Teams preview")
                        {
                            SelectTeamIndex(listOfTeams);
                            Thread.Sleep(500);
                        }
                        //*********************** PLAYER PARAGRAPH *****************************\\
                        else if (optionsMenu[choosenOption] == "\nAdd player")
                        {
                            int x = SelectTeamIndex(listOfTeams);
                            if (x >= 0)
                            {
                                CreatePlayerInTeamInMenu(ref listOfTeams, x);
                            }
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Remove player")
                        {
                            int x = SelectTeamIndex(listOfTeams);
                            int y = SelectPlayerIndex(listOfTeams.ElementAt(x));
                            listOfTeams.ElementAt(x).RemovePlayer(y);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Players preview")
                        {
                            int x = SelectTeamIndex(listOfTeams);
                            if (x >= 0)
                                SelectPlayerIndex(listOfTeams.ElementAt(x));
                            Thread.Sleep(500);
                        }
                        //*********************** REFEREE PARAGRAPH *****************************\\
                        else if (optionsMenu[choosenOption] == "\nAdd referee")
                        {
                            CreateRefereeInMenu(ref listOfReferees);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Remove referee")
                        {
                            int x = SelectRefereeIndex(listOfReferees);
                            listOfReferees.RemoveAt(x);
                            Thread.Sleep(500);
                        }
                        else if (optionsMenu[choosenOption] == "Referee preview")
                        {
                            SelectRefereeIndex(listOfReferees);
                            Thread.Sleep(500);
                        }
                        //*********************** TOURNAMENT PARAGRAPH *****************************\\
                        else if(optionsMenu[choosenOption]=="\nSign up team for a cup")
                        {
                            
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
        /// <returns></returns>
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
        /// Creates the <see cref="Player"/> in selected <see cref="Team"/> in menu.
        /// </summary>
        /// <param name="listOfTeams">The list of <see cref="Team"/>s.</param>
        /// <param name="teamIndex">Index of the <see cref="Team"/> in list.</param>
        /// <returns>Returns 1 in the end.</returns>
        private static int CreatePlayerInTeamInMenu(ref List<Team> listOfTeams, int teamIndex)
        {
            DisplayMenuHeader("Create Player Menu", "Type new name and surname. Confirm by 'Enter'.");
            Console.WriteLine("Player name: ");
            Console.WriteLine("Player surname: ");
            DisplayMenuFooter();
            Console.SetCursorPosition(13, 3);
            string newName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newName))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(13, 3);
                newName = Console.ReadLine();
            }
            Console.SetCursorPosition(16, 4);
            string newSurname = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(newSurname))
            {
                DisplayFailure(6, "can not be null or white spaced");
                Console.SetCursorPosition(16, 4);
                newSurname = Console.ReadLine();
            }
            listOfTeams.ElementAt(teamIndex).AddPlayer(newName, newSurname);
            DisplaySuccess(6, "action successfull");
            return 1;
        }
        /// <summary>
        /// Chooses the index of the team.
        /// </summary>
        /// <param name="listOfTeams">The list of teams.</param>
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
        /// Chooses the index of the player.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <returns>Returns <see cref="Player"/>'s index in the list.</returns>
        private static int SelectPlayerIndex(Team team)
        {
            int choosen = 0, i = 0;
            string[] players = new string[team.ReturnPlayers().Count()];
            foreach (Player player in team.ReturnPlayers())
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
                        DisplayFailure(team.ReturnPlayers().Count() + 4, "cancelling...");
                        return -1;
                    case ConsoleKey.UpArrow:
                        if ((choosen - 1) < 0)
                            choosen = team.ReturnPlayers().Count() - 1;
                        else
                            choosen--;
                        break;
                    case ConsoleKey.DownArrow:
                        if ((choosen + 1) > team.ReturnPlayers().Count() - 1)
                            choosen = 0;
                        else
                            choosen++;
                        break;
                    case ConsoleKey.Enter:
                        DisplaySuccess(team.ReturnPlayers().Count() + 4, "action successfull");
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
    }
}
