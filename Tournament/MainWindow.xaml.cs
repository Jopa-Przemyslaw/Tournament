using System;
using System.Collections.Generic;
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

namespace Tournament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Border[] borders;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        MenuController menuController;
        AnimationsController animationsController;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            borders = new Border[5];
            menuController = new MenuController(ref borders, this, this.ContentTitle, new PropertyPath(MarginProperty));
            
            animationsController = new AnimationsController(new PropertyPath(MarginProperty), this);



            borders[0] = ContainerContent_Player;
            borders[1] = ContainerContent_Team;
            borders[2] = ContainerContent_Referee;
            borders[3] = ContainerContent_Cup;
            borders[4] = ContainerContent_Tournament;

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
        private void NavBarItem_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-512.png", UriKind.Relative);
            NavBarItem_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-bw-512.png", UriKind.Relative);
            NavBarItem_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-to-team-64.png", UriKind.Relative);
            NavBarItem2_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-to-team-bw-64.png", UriKind.Relative);
            NavBarItem2_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem3_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-out-of-team-64.png", UriKind.Relative);
            NavBarItem3_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem3_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-out-of-team-bw-64.png", UriKind.Relative);
            NavBarItem3_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem4_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-64.png", UriKind.Relative);
            NavBarItem4_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem4_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-80.png", UriKind.Relative);
            NavBarItem4_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem5_Player_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-100.png", UriKind.Relative);
            NavBarItem5_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem5_Player_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-bw-100.png", UriKind.Relative);
            NavBarItem5_Player.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        #endregion

        #region TEAM methods
        private void NavBarItem_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-512.png", UriKind.Relative);
            NavBarItem_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-bw-512.png", UriKind.Relative);
            NavBarItem_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem1_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-to-team-64.png", UriKind.Relative);
            NavBarItem1_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem1_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-to-team-bw-64.png", UriKind.Relative);
            NavBarItem1_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-out-of-team-64.png", UriKind.Relative);
            NavBarItem2_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-out-of-team-bw-64.png", UriKind.Relative);
            NavBarItem2_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem3_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-64.png", UriKind.Relative);
            NavBarItem3_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem3_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-80.png", UriKind.Relative);
            NavBarItem3_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem4_Team_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-100.png", UriKind.Relative);
            NavBarItem4_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem4_Team_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-bw-100.png", UriKind.Relative);
            NavBarItem4_Team.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        #endregion

        #region REFEREE methods
        private void NavBarItem_Referee_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-512.png", UriKind.Relative);
            NavBarItem_Referee.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem_Referee_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-bw-512.png", UriKind.Relative);
            NavBarItem_Referee.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem1_Referee_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-64.png", UriKind.Relative);
            NavBarItem1_Referee.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem1_Referee_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-80.png", UriKind.Relative);
            NavBarItem1_Referee.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Referee_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-100.png", UriKind.Relative);
            NavBarItem2_Referee.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Referee_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-bw-100.png", UriKind.Relative);
            NavBarItem2_Referee.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        #endregion

        #region CUP methods
        private void NavBarItem_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-512.png", UriKind.Relative);
            NavBarItem_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-plus-bw-512.png", UriKind.Relative);
            NavBarItem_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem1_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-to-team-64.png", UriKind.Relative);
            NavBarItem1_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem1_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-to-team-bw-64.png", UriKind.Relative);
            NavBarItem1_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-in-referee-80.png", UriKind.Relative);
            NavBarItem2_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem2_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-in-referee-bw-80.png", UriKind.Relative);
            NavBarItem2_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem3_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-out-of-team-64.png", UriKind.Relative);
            NavBarItem3_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem3_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-out-of-team-bw-64.png", UriKind.Relative);
            NavBarItem3_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem4_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-100.png", UriKind.Relative);
            NavBarItem4_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem4_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-bw-100.png", UriKind.Relative);
            NavBarItem4_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem5_Cup_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-100.png", UriKind.Relative);
            NavBarItem5_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void NavBarItem5_Cup_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-preview-pane-bw-100.png", UriKind.Relative);
            NavBarItem5_Cup.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        #endregion
    }
}
