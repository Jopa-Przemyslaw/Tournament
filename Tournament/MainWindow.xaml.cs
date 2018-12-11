using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Backend;
using Backend.AuxiliaryClasses;

namespace Tournament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TODO: anulowac wszystkie akcje tak, zeby razem z animacja chowania zamykaly sie tez otworzone opcje
        //TODO: wykluczyc wprowadzanie duplikatow graczy, druzyn, sedziow, pucharow
        public static List<Player> listOfPlayers;
        public static List<Team> listOfTeams;
        public static List<Referee> listOfReferees;
        public static List<Cup> listOfCups;

        Border[] borders;
        Border[] playerContentItems, teamContentItems, refereeContentItems, cupContentItems, tournamentContentItems;
        MenuItem[] playerNavItems, teamNavItems, refereeNavItems, cupNavItems, tournamentNavItems;

        DispatcherTimer dispatcherTimer;
        MenuController menuController;
        NavbarController navbarController;
        AnimationsController animationsController;


        private int? selectedPlayerNb, selectedTeamNb, selectedRefereeNb, selectedCupNb;

        public MainWindow()
        {
            InitializeComponent();
            Style = (Style)FindResource(typeof(Window));
        }

        /// <summary>
        /// Handles the Loaded event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            borders = new Border[5];
            playerContentItems = new Border[6];
            teamContentItems = new Border[7];
            refereeContentItems = new Border[3];
            cupContentItems = new Border[11];
            tournamentContentItems = new Border[3];

            playerNavItems = new MenuItem[5];
            teamNavItems = new MenuItem[5];
            refereeNavItems = new MenuItem[3];
            cupNavItems = new MenuItem[6];
            tournamentNavItems = new MenuItem[2];


            dispatcherTimer = new DispatcherTimer();
            menuController = new MenuController(ref borders, this, this.ContentTitle, new PropertyPath(MarginProperty));
            navbarController = new NavbarController(ref playerNavItems);
            animationsController = new AnimationsController(new PropertyPath(MarginProperty), this);
            //Initiation of lists of Players nd Teams nd Refs nd Cups.
            listOfPlayers = new List<Player>();
            //listOfPlayers.Add(new Player("Jan", "Nowak"));
            //listOfPlayers.Add(new Player("Juan", "Cech"));
            listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameA"));
            listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameB"));
            listOfPlayers.Add(new Player("PlayerName", "PlayerSurnameC"));
            listOfTeams = new List<Team>();
            //listOfTeams.Add(new Team("FC Porto", 23));
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
            listOfReferees = new List<Referee>();
            //listOfReferees.Add(new Referee("Ben", "Sprawiedliwy"));
            listOfReferees.Add(new Referee("Referee", "Noname0"));
            listOfReferees.Add(new Referee("Referee", "Noname1"));
            listOfReferees.Add(new Referee("Referee", "Noname2"));
            listOfReferees.Add(new Referee("Referee", "Noname3"));
            listOfReferees.Add(new Referee("Referee", "Noname4"));
            listOfCups = new List<Cup>();
            Cup cup = new Cup(listOfTeams, listOfReferees, "New Cup");
            listOfCups.Add(cup);
            foreach (Team team in listOfTeams)
                listOfCups.ElementAt(0).AddTeam(team);
            foreach (Referee referee in listOfReferees)
                listOfCups.ElementAt(0).AddReferee(referee);
            //Assign borders of right bar menu (PLAYER, TEAM, REFEREE, CUP, TOURNAMENT).
            borders[0] = ContainerContent_Player;
            borders[1] = ContainerContent_Team;
            borders[2] = ContainerContent_Referee;
            borders[3] = ContainerContent_Cup;
            borders[4] = ContainerContent_Tournament;
            //Initiation of contents' Borders.
            //Assign borders of Player content.
            playerContentItems[0] = PlayerContent_Add;
            playerContentItems[1] = PlayerContent_ChoosePlayer;
            playerContentItems[2] = PlayerContent_LeaveTeam;
            playerContentItems[3] = PlayerContent_Remove;
            playerContentItems[4] = PlayerContent_Preview;
            playerContentItems[5] = PlayerContent_AssignTeam;
            //Assign borders of Team content.
            teamContentItems[0] = TeamContent_Add;
            teamContentItems[1] = TeamContent_ChooseTeam;
            teamContentItems[2] = TeamContent_AssignPlayer;
            teamContentItems[3] = TeamContent_ChooseTeam2;
            teamContentItems[4] = TeamContent_KickFromTeam;
            teamContentItems[5] = TeamContent_Remove;
            teamContentItems[6] = TeamContent_Preview;
            //Assign borders of Referee content.
            refereeContentItems[0] = RefereeContent_Add;
            refereeContentItems[1] = RefereeContent_Remove;
            refereeContentItems[2] = RefereeContent_Preview;
            //Assign borders of Cup content.
            cupContentItems[0] = CupContent_Add;
            cupContentItems[1] = CupContent_ChooseCup;
            cupContentItems[2] = CupContent_AssignTeam;
            cupContentItems[3] = CupContent_ChooseCup2;
            cupContentItems[4] = CupContent_AssignReferee;
            cupContentItems[5] = CupContent_ChooseCup3;
            cupContentItems[6] = CupContent_RemoveTeam;
            cupContentItems[7] = CupContent_ChooseCup4;
            cupContentItems[8] = CupContent_PreviewTeam;
            cupContentItems[9] = CupContent_ChooseCup5;
            cupContentItems[10] = CupContent_PreviewReferee;
            //Assign borders of Tournament content.
            tournamentContentItems[0] = TournamentContent_ChooseTournament;
            tournamentContentItems[1] = TournamentContent_Start;
            tournamentContentItems[2] = TournamentContent_Dais;
            //Initiation of navbars' MenuItems.
            //Assign items from Player navbar.
            playerNavItems[0] = NavBarItem_Player;
            playerNavItems[1] = NavBarItem2_Player;
            playerNavItems[2] = NavBarItem3_Player;
            playerNavItems[3] = NavBarItem4_Player;
            playerNavItems[4] = NavBarItem5_Player;
            //Assign items from Team navbar.
            teamNavItems[0] = NavBarItem_Team;
            teamNavItems[1] = NavBarItem1_Team;
            teamNavItems[2] = NavBarItem2_Team;
            teamNavItems[3] = NavBarItem3_Team;
            teamNavItems[4] = NavBarItem4_Team;
            //Assign items from Referee navbar.
            refereeNavItems[0] = NavBarItem_Referee;
            refereeNavItems[1] = NavBarItem1_Referee;
            refereeNavItems[2] = NavBarItem2_Referee;
            //Assign items from Cup navbar.
            cupNavItems[0] = NavBarItem_Cup;
            cupNavItems[1] = NavBarItem1_Cup;
            cupNavItems[2] = NavBarItem2_Cup;
            cupNavItems[3] = NavBarItem3_Cup;
            cupNavItems[4] = NavBarItem4_Cup;
            cupNavItems[5] = NavBarItem5_Cup;
            //Assign items from Tournament navbar.
            tournamentNavItems[0] = NavBarItem_Tournament;
            tournamentNavItems[1] = NavBarItem1_Tournament;


            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1);
            dispatcherTimer.Start();

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            //menuIconsController.CheckMenuIcons(ref borders);

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        #region MENU methods
        private void PlayerMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (borders[0].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.PlayerIconOn();
            }
        }

        private void PlayerMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (borders[0].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.PlayerIconOff();
            }
        }

        private void TeamMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (borders[1].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.TeamIconOn();
            }
        }

        private void TeamMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (borders[1].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.TeamIconOff();
            }
        }

        private void RefereeMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (borders[2].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.RefereeIconOn();
            }
        }

        private void RefereeMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (borders[2].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.RefereeIconOff();
                //menuIconsController.RefereeIconOff();
            }
        }

        private void CupMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (borders[3].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.CupIconOn();
            }
        }

        private void CupMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (borders[3].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.CupIconOff();
            }
        }

        private void TournamentMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if (borders[4].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.TournamentIconOn();
            }
        }

        private void TournamentMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            if (borders[4].Visibility == Visibility.Collapsed)
            {
                menuController.menuIconsController.TournamentIconOff();
            }
        }

        private async void PlayerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            await menuController.MenuItemOnClick(sender, ContainerContent_Player);
        }

        private async void TeamMenuItem_Click(object sender, RoutedEventArgs e)
        {
            await menuController.MenuItemOnClick(sender, ContainerContent_Team);
        }

        private async void RefereeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            await menuController.MenuItemOnClick(sender, ContainerContent_Referee);
        }

        private async void CupMenuItem_Click(object sender, RoutedEventArgs e)
        {
            await menuController.MenuItemOnClick(sender, ContainerContent_Cup);
        }

        private async void TournamentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            await menuController.MenuItemOnClick(sender, ContainerContent_Tournament);
        }

        #endregion

        #region PLAYER methods
        #region mouse enter/leave events
        private void NavBarItem_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PlayerContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOn(ref NavBarItem_Player);
            }
        }

        private void NavBarItem_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PlayerContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOff(ref NavBarItem_Player);
            }
        }

        private void NavBarItem2_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PlayerContent_AssignTeam.Visibility == Visibility.Collapsed && PlayerContent_ChoosePlayer.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignIconOn(ref NavBarItem2_Player);
            }
        }

        private void NavBarItem2_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PlayerContent_AssignTeam.Visibility == Visibility.Collapsed && PlayerContent_ChoosePlayer.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignIconOff(ref NavBarItem2_Player);
            }
        }

        private void NavBarItem3_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PlayerContent_LeaveTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.LeaveTeamIconOn(ref NavBarItem3_Player);
            }
        }

        private void NavBarItem3_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PlayerContent_LeaveTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.LeaveTeamIconOff(ref NavBarItem3_Player);
            }
        }

        private void NavBarItem4_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PlayerContent_Remove.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.RemoveIconOn(ref NavBarItem4_Player);
            }
        }

        private void NavBarItem4_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PlayerContent_Remove.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.RemoveIconOff(ref NavBarItem4_Player);
            }
        }

        private void NavBarItem5_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            if (PlayerContent_Preview.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOn(ref NavBarItem5_Player);
            }
        }

        private void NavBarItem5_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            if (PlayerContent_Preview.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOff(ref NavBarItem5_Player);
            }
        }
        #endregion mouse enter/leave events
        //Click events
        private void NavBarItem_Player_Click(object sender, RoutedEventArgs e)
        {
            navbarController.NavbarItemOnClick(sender, PlayerContent_Add, playerContentItems, ref playerNavItems, ref NavBarItem_Player);
        }

        private void PlayerContent_AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(PlayerName.Text) && !string.IsNullOrWhiteSpace(PlayerSurame.Text))
            {
                var playerName = PlayerName.Text;
                var playerSurname = PlayerSurame.Text;

                listOfPlayers.Add(new Player(playerName, playerSurname));
                MessageBox.Show($"{playerName} {playerSurname} joins this party as a new player.");
            }
            else
            {
                MessageBox.Show("Name and surname can not be nulls or white spaces.");
            }

            PlayerName.Text = null;
            PlayerSurame.Text = null;
        }

        private void NavBarItem2_Player_Click(object sender, RoutedEventArgs e)
        {
            selectedPlayerNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, PlayerContent_ChoosePlayer, playerContentItems, ref playerNavItems, ref NavBarItem2_Player, ref listOfPlayers, ref PlayerContent_PlayerListBox);
        }

        private void PlayerContent_PlayerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayerNb = PlayerContent_PlayerListBox.SelectedIndex;
            navbarController.NavbarItemOnClick(sender, PlayerContent_AssignTeam, playerContentItems, ref playerNavItems, ref NavBarItem2_Player, ref listOfTeams, ref PlayerContent_AssignTeam_ListBox);
        }

        private void PlayerContent_AssignTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = PlayerContent_AssignTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedPlayerNb != null & selectedTeamNb != null)
                {
                    listOfPlayers.ElementAt((int)selectedPlayerNb).SetTeam(listOfTeams.ElementAt((int)selectedTeamNb));
                    MessageBox.Show($"{listOfPlayers.ElementAt((int)selectedPlayerNb).GetName} {listOfPlayers.ElementAt((int)selectedPlayerNb).GetSurname} " +
                        $"has just joined {listOfTeams.ElementAt((int)selectedTeamNb).name}. That's a good news.");
                }
                else
                {
                    throw new Exception("No selected player or team while assigning team for player.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            //navbarController.SwitchNavbarItemsOff(ref playerContentItems, ref playerNavItems);
            selectedPlayerNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, PlayerContent_ChoosePlayer, playerContentItems, ref playerNavItems, ref NavBarItem2_Player, ref listOfPlayers, ref PlayerContent_PlayerListBox);

            //PlayerContent_AssignTeam_ListBox.ItemsSource = null;
            //selectedPlayerNb = selectedTeamNb = null;
        }

        private void NavBarItem3_Player_Click(object sender, RoutedEventArgs e)
        {
            selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, PlayerContent_LeaveTeam, playerContentItems, ref playerNavItems, ref NavBarItem3_Player, ref listOfPlayers, ref PlayerContent_LeaveTeam_ListBox);
        }

        private void PlayerContent_LeaveTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayerNb = PlayerContent_LeaveTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedPlayerNb != null)
                {
                    listOfPlayers.ElementAt((int)selectedPlayerNb).playerTeam.playersList.Remove(listOfPlayers.ElementAt((int)selectedPlayerNb));
                    //listOfPlayers.ElementAt((int)selectedPlayerNb).SetTeam(null);
                    MessageBox.Show($"{listOfPlayers.ElementAt((int)selectedPlayerNb).GetName} {listOfPlayers.ElementAt((int)selectedPlayerNb).GetSurname} " +
                        $"has just left his team. That's a shocking news.");
                }
                else
                {
                    throw new Exception("No selected player while removing team for player.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            //navbarController.SwitchNavbarItemsOff(ref playerContentItems, ref playerNavItems);
            //selectedPlayerNb = selectedTeamNb = null;
            //PlayerContent_LeaveTeam_ListBox.ItemsSource = null;
            PlayerContent_LeaveTeam_ListBox.Items.Refresh();
        }

        private void NavBarItem4_Player_Click(object sender, RoutedEventArgs e)
        {
            selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, PlayerContent_Remove, playerContentItems, ref playerNavItems, ref NavBarItem4_Player, ref listOfPlayers, ref PlayerContent_RemovePlayer_ListBox);
        }

        private void PlayerContent_RemovePlayer_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayerNb = PlayerContent_RemovePlayer_ListBox.SelectedIndex;
            try
            {
                if (selectedPlayerNb != null)
                {
                    var name = listOfPlayers.ElementAt((int)selectedPlayerNb).GetName;
                    var surname = listOfPlayers.ElementAt((int)selectedPlayerNb).GetSurname;
                    listOfPlayers.ElementAt((int)selectedPlayerNb).playerTeam.playersList.Remove(listOfPlayers.ElementAt((int)selectedPlayerNb));
                    //listOfPlayers.ElementAt((int)selectedPlayerNb).SetTeam(null);
                    listOfPlayers.RemoveAt((int)selectedPlayerNb);
                    MessageBox.Show($"{name} {surname} " +
                        $"has just gone into retirement. That's a hughe relieve for him.");
                }
                else
                {
                    throw new Exception("No selected player while removing player.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            PlayerContent_RemovePlayer_ListBox.Items.Refresh();
        }

        private void NavBarItem5_Player_Click(object sender, RoutedEventArgs e)
        {
            selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, PlayerContent_Preview, playerContentItems, ref playerNavItems, ref NavBarItem5_Player, ref listOfPlayers, ref PlayerContent_PreviewPlayers_ListBox);
        }

        private void PlayerContent_PreviewPlayers_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayerNb = PlayerContent_PreviewPlayers_ListBox.SelectedIndex;
            try
            {
                if (selectedPlayerNb != null)
                {
                    MessageBox.Show($"Name: {listOfPlayers.ElementAt((int)selectedPlayerNb).GetName}\n" +
                        $"Surname: {listOfPlayers.ElementAt((int)selectedPlayerNb).GetSurname}\n" +
                        $"Team: {((listOfPlayers.ElementAt((int)selectedPlayerNb).playerTeam == null) ? "no contract assigned" : (listOfPlayers.ElementAt((int)selectedPlayerNb).playerTeam.name))}\n" +
                        $"Statistics: " +
                        $"{listOfPlayers.ElementAt((int)selectedPlayerNb).matchesPlayed} / {listOfPlayers.ElementAt((int)selectedPlayerNb).goalsScored} / {listOfPlayers.ElementAt((int)selectedPlayerNb).trophiesWon}" +
                        $"\n\t(MP / GS / TW)\n");
                }
                else
                {
                    throw new Exception("No selected player while previewing player.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            PlayerContent_PreviewPlayers_ListBox.Items.Refresh();
        }

        #endregion

        #region TEAM methods
        #region mouse enter/leave events
        private void NavBarItem_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TeamContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOn(ref NavBarItem_Team);
            }
        }

        private void NavBarItem_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TeamContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOff(ref NavBarItem_Team);
            }
        }

        private void NavBarItem1_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TeamContent_ChooseTeam.Visibility == Visibility.Collapsed && TeamContent_AssignPlayer.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignIconOn(ref NavBarItem1_Team);
            }
        }

        private void NavBarItem1_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TeamContent_ChooseTeam.Visibility == Visibility.Collapsed && TeamContent_AssignPlayer.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignIconOff(ref NavBarItem1_Team);
            }
        }

        private void NavBarItem2_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TeamContent_ChooseTeam2.Visibility == Visibility.Collapsed && TeamContent_KickFromTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.LeaveTeamIconOn(ref NavBarItem2_Team);
            }
        }

        private void NavBarItem2_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TeamContent_ChooseTeam2.Visibility == Visibility.Collapsed && TeamContent_KickFromTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.LeaveTeamIconOff(ref NavBarItem2_Team);
            }
        }

        private void NavBarItem3_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TeamContent_Remove.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.RemoveIconOn(ref NavBarItem3_Team);
            }
        }

        private void NavBarItem3_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TeamContent_Remove.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.RemoveIconOff(ref NavBarItem3_Team);
            }
        }

        private void NavBarItem4_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            if (TeamContent_Preview.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOn(ref NavBarItem4_Team);
            }
        }

        private void NavBarItem4_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TeamContent_Preview.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOff(ref NavBarItem4_Team);
            }
        }
        #endregion mouse enter/leave events
        private void NavBarItem_Team_Click(object sender, RoutedEventArgs e)
        {
            navbarController.NavbarItemOnClick(sender, TeamContent_Add, teamContentItems, ref teamNavItems, ref NavBarItem_Team);
        }

        private void TeamContent_AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TeamName.Text))
            {
                var teamName = TeamName.Text;

                listOfTeams.Add(new Team(teamName, 23));
                MessageBox.Show($"{teamName} joins this party as a new team.");
            }
            else
            {
                MessageBox.Show("Name can not be null or white space.");
            }

            TeamName.Text = null;
        }

        private void NavBarItem1_Team_Click(object sender, RoutedEventArgs e)
        {
            selectedTeamNb = selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, TeamContent_ChooseTeam, teamContentItems, ref teamNavItems, ref NavBarItem1_Team, ref listOfTeams, ref TeamContent_TeamListBox);
        }

        private void TeamContent_TeamListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = TeamContent_TeamListBox.SelectedIndex;
            navbarController.NavbarItemOnClick(sender, TeamContent_AssignPlayer, teamContentItems, ref teamNavItems, ref NavBarItem1_Team, ref listOfPlayers, ref TeamContent_AssignPlayer_ListBox);
        }

        private void TeamContent_AssignPlayer_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayerNb = TeamContent_AssignPlayer_ListBox.SelectedIndex;
            try
            {
                if (selectedTeamNb != null & selectedPlayerNb != null)
                {
                    listOfPlayers.ElementAt((int)selectedPlayerNb).SetTeam(listOfTeams.ElementAt((int)selectedTeamNb));
                    MessageBox.Show($"{listOfPlayers.ElementAt((int)selectedPlayerNb).GetName} {listOfPlayers.ElementAt((int)selectedPlayerNb).GetSurname} " +
                        $"has just joined {listOfTeams.ElementAt((int)selectedTeamNb).name}. That's a good news.");
                }
                else
                {
                    throw new Exception("No selected player or team while assigning team for player.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedTeamNb = selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, TeamContent_ChooseTeam, teamContentItems, ref teamNavItems, ref NavBarItem1_Team, ref listOfTeams, ref TeamContent_TeamListBox);
        }

        private void NavBarItem2_Team_Click(object sender, RoutedEventArgs e)
        {
            selectedTeamNb = selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, TeamContent_ChooseTeam2, teamContentItems, ref teamNavItems, ref NavBarItem2_Team, ref listOfTeams, ref TeamContent_TeamListBox2);
        }

        private void TeamContent_TeamListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = TeamContent_TeamListBox2.SelectedIndex;
            navbarController.NavbarItemOnClick(sender, TeamContent_KickFromTeam, teamContentItems, ref teamNavItems, ref NavBarItem2_Team, ref listOfPlayers, ref TeamContent_KickFromTeam_ListBox);
        }

        private void TeamContent_KickFromTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPlayerNb = TeamContent_KickFromTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedPlayerNb != null)
                {
                    listOfPlayers.ElementAt((int)selectedPlayerNb).SetTeam(null);
                    listOfTeams.ElementAt((int)selectedTeamNb).RemovePlayer(listOfPlayers.FindIndex(x => x.GetPlayer == listOfPlayers.ElementAt((int)selectedPlayerNb)));
                    MessageBox.Show($"{listOfPlayers.ElementAt((int)selectedPlayerNb).GetName} {listOfPlayers.ElementAt((int)selectedPlayerNb).GetSurname} " +
                        $"has just been kicked outta his team. That's a shocking news.");
                }
                else
                {
                    throw new Exception("No selected player while removing team for player.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedTeamNb = selectedPlayerNb = null;
            navbarController.NavbarItemOnClick(sender, TeamContent_ChooseTeam2, teamContentItems, ref teamNavItems, ref NavBarItem2_Team, ref listOfTeams, ref TeamContent_TeamListBox2);
        }

        private void NavBarItem3_Team_Click(object sender, RoutedEventArgs e)
        {
            selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, TeamContent_Remove, teamContentItems, ref teamNavItems, ref NavBarItem3_Team, ref listOfTeams, ref TeamContent_RemoveTeam_ListBox);
        }

        private void TeamContent_RemoveTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = TeamContent_RemoveTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedTeamNb != null)
                {
                    var name = listOfTeams.ElementAt((int)selectedTeamNb).name;
                    //foreach (var item in listOfTeams.ElementAt((int)selectedTeamNb).playersList)
                    //{
                    //    item.SetTeam(null);
                    //}
                    for (int i = 0; i < listOfTeams.ElementAt((int)selectedTeamNb).playersList.Count();)
                    {
                        listOfPlayers.Find(x => x.GetPlayer == listOfTeams.ElementAt((int)selectedTeamNb).playersList.ElementAt(0)).SetTeam(null);
                    }
                    listOfTeams.RemoveAt((int)selectedTeamNb);
                    MessageBox.Show($"{name} " + $"has been just disbanded. That's the end of their career.");
                }
                else
                {
                    throw new Exception("No selected team while removing team.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            TeamContent_RemoveTeam_ListBox.Items.Refresh();
        }

        private void NavBarItem4_Team_Click(object sender, RoutedEventArgs e)
        {
            selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, TeamContent_Preview, teamContentItems, ref teamNavItems, ref NavBarItem4_Team, ref listOfTeams, ref TeamContent_PreviewTeams_ListBox);
        }

        private void TeamContent_PreviewTeams_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = TeamContent_PreviewTeams_ListBox.SelectedIndex;
            try
            {
                if (selectedTeamNb != null)
                {
                    string players = "";
                    foreach (var item in listOfTeams.ElementAt((int)selectedTeamNb).playersList)
                    {
                        players += "\n\t" + item.GetName + " " + item.GetSurname;
                    }
                    MessageBox.Show($"Name: {listOfTeams.ElementAt((int)selectedTeamNb).name}\n" +
                        $"Players:\t{listOfTeams.ElementAt((int)selectedTeamNb).playersList.Count}/{listOfTeams.ElementAt((int)selectedTeamNb).playersList.Capacity}{players}\n" +
                        $"Statistics: " +
                        $"{listOfTeams.ElementAt((int)selectedTeamNb).matchesPlayed} / {listOfTeams.ElementAt((int)selectedTeamNb).goalsScored} / {listOfTeams.ElementAt((int)selectedTeamNb).goalsLost}" +
                        $" / {listOfTeams.ElementAt((int)selectedTeamNb).wins} / {listOfTeams.ElementAt((int)selectedTeamNb).lost} / {listOfTeams.ElementAt((int)selectedTeamNb).draws}" +
                        $" / {listOfTeams.ElementAt((int)selectedTeamNb).tournamentsWon}" +
                        $"\n\t(MP / GS / GL / W / L / D / TW)\n");
                }
                else
                {
                    throw new Exception("No selected team while previewing team.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            PlayerContent_PreviewPlayers_ListBox.Items.Refresh();
        }

        #endregion

        #region REFEREE methods
        #region mouse enter/leave events
        private void NavBarItem_Referee_MouseEnter(object sender, MouseEventArgs e)
        {
            if (RefereeContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOn(ref NavBarItem_Referee);
            }
        }

        private void NavBarItem_Referee_MouseLeave(object sender, MouseEventArgs e)
        {
            if (RefereeContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOff(ref NavBarItem_Referee);
            }
        }

        private void NavBarItem1_Referee_MouseEnter(object sender, MouseEventArgs e)
        {
            if (RefereeContent_Remove.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.RemoveIconOn(ref NavBarItem1_Referee);
            }
        }

        private void NavBarItem1_Referee_MouseLeave(object sender, MouseEventArgs e)
        {
            if (RefereeContent_Remove.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.RemoveIconOff(ref NavBarItem1_Referee);
            }
        }

        private void NavBarItem2_Referee_MouseEnter(object sender, MouseEventArgs e)
        {
            if (RefereeContent_Preview.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOn(ref NavBarItem2_Referee);
            }
        }

        private void NavBarItem2_Referee_MouseLeave(object sender, MouseEventArgs e)
        {
            if (RefereeContent_Preview.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOff(ref NavBarItem2_Referee);
            }
        }
        #endregion mouse enter/leave events

        private void NavBarItem_Referee_Click(object sender, RoutedEventArgs e)
        {
            navbarController.NavbarItemOnClick(sender, RefereeContent_Add, refereeContentItems, ref refereeNavItems, ref NavBarItem_Referee);
        }

        private void RefereeContent_AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RefereeName.Text) && !string.IsNullOrWhiteSpace(RefereeSurame.Text))
            {
                var refereeName = RefereeName.Text;
                var refereeSurname = RefereeSurame.Text;

                listOfReferees.Add(new Referee(refereeName, refereeSurname));
                MessageBox.Show($"{refereeName} {refereeSurname} joins this party as a new referee.");
            }
            else
            {
                MessageBox.Show("Name and surname can not be nulls or white spaces.");
            }

            RefereeName.Text = null;
            RefereeSurame.Text = null;
        }

        private void NavBarItem1_Referee_Click(object sender, RoutedEventArgs e)
        {
            selectedRefereeNb = null;
            navbarController.NavbarItemOnClick(sender, RefereeContent_Remove, refereeContentItems, ref refereeNavItems, ref NavBarItem1_Referee, ref listOfReferees, ref RefereeContent_RemoveReferee_ListBox);
        }

        private void RefereeContent_RemoveReferee_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRefereeNb = RefereeContent_RemoveReferee_ListBox.SelectedIndex;
            try
            {
                if (selectedRefereeNb != null)
                {
                    var name = listOfReferees.ElementAt((int)selectedRefereeNb).GetName;
                    var surname = listOfReferees.ElementAt((int)selectedRefereeNb).GetSurname;
                    listOfReferees.RemoveAt((int)selectedRefereeNb);
                    MessageBox.Show($"{name} {surname} " +
                        $"has just gone into retirement. That's a hughe relieve for him.");
                }
                else
                {
                    throw new Exception("No selected referee while removing referee.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            RefereeContent_RemoveReferee_ListBox.Items.Refresh();
        }

        private void NavBarItem2_Referee_Click(object sender, RoutedEventArgs e)
        {
            selectedRefereeNb = null;
            navbarController.NavbarItemOnClick(sender, RefereeContent_Preview, refereeContentItems, ref refereeNavItems, ref NavBarItem2_Referee, ref listOfReferees, ref RefereeContent_PreviewReferee_ListBox);
        }

        private void RefereeContent_PreviewReferee_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRefereeNb = RefereeContent_PreviewReferee_ListBox.SelectedIndex;
            try
            {
                if (selectedRefereeNb != null)
                {
                    MessageBox.Show($"Name: {listOfReferees.ElementAt((int)selectedRefereeNb).GetName}\n" +
                        $"Surname: {listOfReferees.ElementAt((int)selectedRefereeNb).GetSurname}\n");
                }
                else
                {
                    throw new Exception("No selected referee while previewing referee.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            RefereeContent_PreviewReferee_ListBox.Items.Refresh();
        }

        #endregion

        #region CUP methods
        #region mouse enter/leave events
        private void NavBarItem_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CupContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOn(ref NavBarItem_Cup);
            }
        }

        private void NavBarItem_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CupContent_Add.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AddIconOff(ref NavBarItem_Cup);
            }
        }

        private void NavBarItem1_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup.Visibility == Visibility.Collapsed && CupContent_AssignTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignIconOn(ref NavBarItem1_Cup);
            }
        }

        private void NavBarItem1_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup.Visibility == Visibility.Collapsed && CupContent_AssignTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignIconOff(ref NavBarItem1_Cup);
            }
        }

        private void NavBarItem2_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup2.Visibility == Visibility.Collapsed && CupContent_AssignReferee.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignRefereeIconOn(ref NavBarItem2_Cup);
            }
        }

        private void NavBarItem2_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup2.Visibility == Visibility.Collapsed && CupContent_AssignReferee.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.AssignRefereeIconOff(ref NavBarItem2_Cup);
            }
        }

        private void NavBarItem3_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup3.Visibility == Visibility.Collapsed && CupContent_RemoveTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.LeaveTeamIconOn(ref NavBarItem3_Cup);
            }
        }

        private void NavBarItem3_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup3.Visibility == Visibility.Collapsed && CupContent_RemoveTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.LeaveTeamIconOff(ref NavBarItem3_Cup);
            }
        }

        private void NavBarItem4_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup4.Visibility == Visibility.Collapsed && CupContent_PreviewTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOn(ref NavBarItem4_Cup);
            }
        }

        private void NavBarItem4_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup4.Visibility == Visibility.Collapsed && CupContent_PreviewTeam.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOff(ref NavBarItem4_Cup);
            }
        }

        private void NavBarItem5_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup5.Visibility == Visibility.Collapsed && CupContent_PreviewReferee.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOn(ref NavBarItem5_Cup);
            }
        }

        private void NavBarItem5_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            if (CupContent_ChooseCup5.Visibility == Visibility.Collapsed && CupContent_PreviewReferee.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PreviewIconOff(ref NavBarItem5_Cup);
            }
        }
        #endregion mouse enter/leave events

        private void NavBarItem_Cup_Click(object sender, RoutedEventArgs e)
        {
            navbarController.NavbarItemOnClick(sender, CupContent_Add, cupContentItems, ref cupNavItems, ref NavBarItem_Cup);
        }

        private void CupContent_AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CupName.Text))
            {
                string cupName = CupName.Text;
                if (!listOfCups.Exists(x => x.name == cupName))
                {
                    listOfCups.Add(new Cup(cupName));
                    MessageBox.Show($"{cupName} created. Let the tournament begin.");
                }
                else
                {
                    MessageBox.Show($"Cup with name \"{cupName}\" already exists.");
                }
            }
            else
            {
                MessageBox.Show("Name and surname can not be nulls or white spaces.");
            }

            CupName.Text = null;
        }

        private void NavBarItem1_Cup_Click(object sender, RoutedEventArgs e)
        {
            selectedCupNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup, cupContentItems, ref cupNavItems, ref NavBarItem1_Cup, ref listOfCups, ref CupContent_CupListBox);
        }

        private void CupContent_CupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCupNb = CupContent_CupListBox.SelectedIndex;
            navbarController.NavbarItemOnClick(sender, CupContent_AssignTeam, cupContentItems, ref cupNavItems, ref NavBarItem1_Cup, ref listOfTeams, ref CupContent_AssignTeam_ListBox);
        }

        private void CupContent_AssignTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = CupContent_AssignTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedCupNb != null & selectedTeamNb != null)
                {
                    listOfCups.ElementAt((int)selectedCupNb).AddTeam(listOfTeams.ElementAt((int)selectedTeamNb));
                    MessageBox.Show($"{listOfTeams.ElementAt((int)selectedTeamNb).name} " +
                        $"has just assigned for {listOfCups.ElementAt((int)selectedCupNb)}. Wish them good luck.");
                }
                else
                {
                    throw new Exception("No selected cup or team while assigning team for cup.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedCupNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup, cupContentItems, ref cupNavItems, ref NavBarItem1_Cup, ref listOfCups, ref CupContent_CupListBox);
        }

        private void NavBarItem2_Cup_Click(object sender, RoutedEventArgs e)
        {
            selectedCupNb = selectedRefereeNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup2, cupContentItems, ref cupNavItems, ref NavBarItem2_Cup, ref listOfCups, ref CupContent_CupListBox2);
        }

        private void CupContent_CupListBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCupNb = CupContent_CupListBox2.SelectedIndex;
            navbarController.NavbarItemOnClick(sender, CupContent_AssignReferee, cupContentItems, ref cupNavItems, ref NavBarItem2_Cup, ref listOfReferees, ref CupContent_AssignReferee_ListBox);
        }

        private void CupContent_AssignReferee_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRefereeNb = CupContent_AssignReferee_ListBox.SelectedIndex;
            try
            {
                if (selectedRefereeNb != null & selectedCupNb != null)
                {
                    listOfCups.ElementAt((int)selectedCupNb).AddReferee(listOfReferees.ElementAt((int)selectedRefereeNb));
                    MessageBox.Show($"{listOfReferees.ElementAt((int)selectedRefereeNb).GetName} {listOfReferees.ElementAt((int)selectedRefereeNb).GetSurname} " +
                        $"has just assigned for {listOfCups.ElementAt((int)selectedCupNb).name}. He surely will judge well.");
                }
                else
                {
                    throw new Exception("No selected cup or referee while assigning referee for cup.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedCupNb = selectedRefereeNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup2, cupContentItems, ref cupNavItems, ref NavBarItem2_Cup, ref listOfCups, ref CupContent_CupListBox2);
        }

        private void NavBarItem3_Cup_Click(object sender, RoutedEventArgs e)
        {
            selectedCupNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup3, cupContentItems, ref cupNavItems, ref NavBarItem3_Cup, ref listOfCups, ref CupContent_CupListBox3);
        }

        private void CupContent_CupListBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCupNb = CupContent_CupListBox3.SelectedIndex;
            List<Team> listOfTeamsInCup = new List<Team>();
            if (selectedCupNb >= 0)
            {
                if (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup != null)
                {
                    listOfTeamsInCup = listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))));
                }
            }
            navbarController.NavbarItemOnClick(sender, CupContent_RemoveTeam, cupContentItems, ref cupNavItems, ref NavBarItem3_Cup, ref listOfTeamsInCup, ref CupContent_RemoveTeam_ListBox);
        }

        private void CupContent_RemoveTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = CupContent_RemoveTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedCupNb != null & selectedTeamNb != null)
                {
                    string name = listOfTeams.ElementAt((int)selectedTeamNb).name;
                    listOfCups.ElementAt((int)selectedCupNb).RemoveTeam(listOfTeams.ElementAt((int)selectedTeamNb));
                    MessageBox.Show($"{name} " +
                        $"has just resigned from {listOfCups.ElementAt((int)selectedCupNb).name}. This cup will be played without them.");
                }
                else
                {
                    throw new Exception("No selected cup or team while removing team from cup.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedCupNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup3, cupContentItems, ref cupNavItems, ref NavBarItem3_Cup, ref listOfCups, ref CupContent_CupListBox3);
        }

        private void NavBarItem4_Cup_Click(object sender, RoutedEventArgs e)
        {
            selectedCupNb = selectedTeamNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup4, cupContentItems, ref cupNavItems, ref NavBarItem4_Cup, ref listOfCups, ref CupContent_CupListBox4);
        }

        private void CupContent_CupListBox4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCupNb = CupContent_CupListBox4.SelectedIndex;
            List<Team> listOfTeamsInCup = new List<Team>();
            if (selectedCupNb >= 0)
            {
                if (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup != null)
                {
                    listOfTeamsInCup = listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))));
                }
            }
            navbarController.NavbarItemOnClick(sender, CupContent_PreviewTeam, cupContentItems, ref cupNavItems, ref NavBarItem4_Cup, ref listOfTeamsInCup, ref CupContent_PreviewTeam_ListBox);
        }

        private void CupContent_PreviewTeam_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedTeamNb = CupContent_PreviewTeam_ListBox.SelectedIndex;
            try
            {
                if (selectedCupNb != null && selectedTeamNb != null)
                {
                    string players = "";
                    foreach (var item in (listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).playersList)
                    {
                        players += "\n\t" + item.GetName + " " + item.GetSurname;
                    }
                    MessageBox.Show($"Name: {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).name}\n" +
                        $"Players:\t{(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).playersList.Count}" +
                        $"/{(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).playersList.Capacity}{players}\n" +
                        $"Statistics: " +
                        $"{(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).matchesPlayed}" +
                        $" / {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).goalsScored}" +
                        $" / {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).goalsLost}" +
                        $" / {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).wins}" +
                        $" / {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).lost}" +
                        $" / {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).draws}" +
                        $" / {(listOfTeams.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Find(a => a.name == (x.name))))).ElementAt((int)selectedTeamNb).tournamentsWon}" +
                        $"\n\t(MP / GS / GL / W / L / D / TW)\n");
                }
                else
                {
                    throw new Exception("No selected team while previewing team.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedTeamNb = null;
            CupContent_PreviewTeam_ListBox.Items.Refresh();
            //navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup4, cupContentItems, ref cupNavItems, ref NavBarItem4_Cup, ref listOfCups, ref CupContent_CupListBox4);
        }

        private void NavBarItem5_Cup_Click(object sender, RoutedEventArgs e)
        {
            selectedCupNb = selectedRefereeNb = null;
            navbarController.NavbarItemOnClick(sender, CupContent_ChooseCup5, cupContentItems, ref cupNavItems, ref NavBarItem5_Cup, ref listOfCups, ref CupContent_CupListBox5);
        }

        private void CupContent_CupListBox5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCupNb = CupContent_CupListBox5.SelectedIndex;
            List<Referee> listOfRefereesInCup = new List<Referee>();
            if (selectedCupNb >= 0)
            {
                if (listOfCups.ElementAt((int)selectedCupNb).listOfRefereesInCup != null)
                {
                    listOfRefereesInCup = listOfReferees.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfRefereesInCup.Find(a => a.GetName == (x.GetName) && a.GetSurname == (x.GetSurname))));
                }
            }
            navbarController.NavbarItemOnClick(sender, CupContent_PreviewReferee, cupContentItems, ref cupNavItems, ref NavBarItem5_Cup, ref listOfRefereesInCup, ref CupContent_PreviewReferee_ListBox);
        }

        private void CupContent_PreviewReferee_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedRefereeNb = CupContent_PreviewReferee_ListBox.SelectedIndex;
            try
            {
                if (selectedCupNb != null && selectedRefereeNb != null)
                {
                    Referee refereeToDisplay= listOfReferees.FindAll(x => x == (listOfCups.ElementAt((int)selectedCupNb).listOfRefereesInCup.Find(a => a.GetName == (x.GetName) && a.GetSurname == (x.GetSurname)))).ElementAt((int)selectedRefereeNb);

                    MessageBox.Show($"Name: {refereeToDisplay.GetName}\n" +
                        $"Surname: {refereeToDisplay.GetSurname}\n");
                }
                else
                {
                    throw new Exception("No selected referee while previewing referee.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            selectedRefereeNb = null;
            CupContent_PreviewReferee_ListBox.Items.Refresh();
        }

        #endregion

        #region TOURNAMENT methods
        #region mouse enter/leave events
        private void NavBarItem_Tournament_MouseEnter(object sender, MouseEventArgs e)
        {
            if(TournamentContent_ChooseTournament.Visibility==Visibility.Collapsed && TournamentContent_Start.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PlayIconOn(ref NavBarItem_Tournament);
            }
        }

        private void NavBarItem_Tournament_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TournamentContent_ChooseTournament.Visibility == Visibility.Collapsed && TournamentContent_Start.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.PlayIconOff(ref NavBarItem_Tournament);
            }
        }

        private void NavBarItem1_Tournament_MouseEnter(object sender, MouseEventArgs e)
        {
            if(TournamentContent_Dais.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.DaisIconOn(ref NavBarItem1_Tournament);
            }
        }

        private void NavBarItem1_Tournament_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TournamentContent_Dais.Visibility == Visibility.Collapsed)
            {
                navbarController.navbarIconsController.DaisIconOff(ref NavBarItem1_Tournament);
            }
        }
        #endregion mouse enter/leave events
        private void NavBarItem_Tournament_Click(object sender, RoutedEventArgs e)
        {
            selectedCupNb = null;
            navbarController.NavbarItemOnClick(sender, TournamentContent_ChooseTournament, tournamentContentItems, ref tournamentNavItems, ref NavBarItem_Tournament, ref listOfCups, ref TournamentContent_TournamentListBox);
        }

        private void TournamentContent_TournamentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCupNb = TournamentContent_TournamentListBox.SelectedIndex;
            navbarController.NavbarItemOnClick(sender, TournamentContent_Start, tournamentContentItems, ref tournamentNavItems, ref NavBarItem_Tournament);
        }

        private void TournamentContent_StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCupNb >= 0)
            {
                try
                {
                    //Team teamA = new Team("HOST TEAM",23), teamB = new Team("GUEST TEAM",23);
                    //Referee mainReferee = new Referee(), suppRef1 = new Referee(), suppRef2 = new Referee();
                    //var x = HostTeamName.Content;
                    //var y = GuestTeamName.Content;
                    //string winn;

                    if (listOfCups.ElementAt((int)selectedCupNb).isFinished)
                        throw new Exception("Cup already played out.");
                    int teamsInCup = listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Count();
                    int refereesInCup = listOfCups.ElementAt((int)selectedCupNb).listOfRefereesInCup.Count();
                    if (teamsInCup < 8 && refereesInCup < 3)
                        throw new Exception("Not enough teams or referees in a cup.");
                    if (teamsInCup % 2 != 0)
                        throw new Exception("Not even number of teams in a cup.");
                    if (teamsInCup != 8 & teamsInCup != 16 & teamsInCup != 24)
                        throw new Exception("Need to be 8, 16 or 24 teams for a cup.");
                    int xx = 1;
                    int yy = listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Count();
                    while ((yy / 2) > 1)
                    {
                        xx++;
                        yy /= 2;
                    }
                    for (int h = 0; h < xx; h++)
                    {
                        List<Team> tempList = new List<Team>(listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup);
                        for (int i = 0; i < teamsInCup / 2; i++)
                        {
                            TwoTeams twoTeams = listOfCups.ElementAt((int)selectedCupNb).RandomTeamsForMatch(tempList);
                            Team teamA = twoTeams.GetHostTeam;
                            Team teamB = twoTeams.GetGuestTeam;


                            HostTeamName.Content = teamA.name;
                            GuestTeamName.Content = teamB.name;

                            System.Threading.Thread.Sleep(1);


                            ThreeReferees referees = listOfCups.ElementAt((int)selectedCupNb).RandomRefereesForMatch();

                            Referee mainReferee = referees.GetMainReferee;
                            Referee suppRef1 = referees.GetSupportingReferee1;
                            Referee suppRef2 = referees.GetSupportingReferee2;

                            FootballMatch footballMatch = new FootballMatch(mainReferee, teamA, teamB, suppRef1, suppRef2);
                            listOfCups.ElementAt((int)selectedCupNb).matchEngine.SimulateFootballMatchAsync(footballMatch, true);
                            if (footballMatch.GetScoreOfTeamA() > footballMatch.GetScoreOfTeamB())
                            {
                                listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Remove(teamB);
                                Winner.Content = "WINNER\n" + footballMatch.ReturnTeamA().name;
                            }
                            else if (footballMatch.GetScoreOfTeamB() > footballMatch.GetScoreOfTeamA())
                            {
                                listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.Remove(teamA);
                                Winner.Content = "WINNER\n" + footballMatch.ReturnTeamB().name;
                            }
                            tempList.Remove(teamA);
                            tempList.Remove(teamB);
                            HostScore.Content = footballMatch.GetScoreOfTeamA();
                            GuestScore.Content = footballMatch.GetScoreOfTeamB();
                            MessageBox.Show("Match ended.");
                        }
                        teamsInCup /= 2;
                    }
                    listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.ElementAt(0).AddTournamentWon();
                    listOfCups.ElementAt((int)selectedCupNb).isFinished = true;
                    Winner.Content = listOfCups.ElementAt((int)selectedCupNb).listOfTeamsInCup.ElementAt(0).name;
                    MessageBox.Show("Tournament ended.");
                }
                catch (Exception ex)
                {
                    //DisplayFailure(1, ex.Message);
                    Debug.WriteLine(ex.Message + " | " + ex.GetType() + " | " + ex.TargetSite);
                    //Thread.Sleep(500);
                    //Console.ReadKey();
                }
            }
        }

        private void NavBarItem1_Tournament_Click(object sender, RoutedEventArgs e)
        {
            List<Team> sortedListOfTeams = new List<Team>(listOfTeams.OrderByDescending(raw => raw.tournamentsWon));
            navbarController.NavbarItemOnClick(sender, TournamentContent_Dais, tournamentContentItems, ref tournamentNavItems, ref NavBarItem1_Tournament, ref sortedListOfTeams, ref TournamentContent_DaisListBox);
        }


        #endregion TOURNAMENT methods
    }
}
