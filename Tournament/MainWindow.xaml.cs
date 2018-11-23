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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tournament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TeamWindow teamWindow = new TeamWindow();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TeamMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-team-64.png", UriKind.Relative);
            TeamMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void TeamMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-team-bw-64.png", UriKind.Relative);
            TeamMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void PlayerMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-soccer-64.png", UriKind.Relative);
            PlayerMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void PlayerMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-soccer-bw-64.png", UriKind.Relative);
            PlayerMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void RefereeMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-referee-filled-80.png", UriKind.Relative);
            RefereeMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void RefereeMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-referee-80.png", UriKind.Relative);
            RefereeMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void CupMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-trophy-color-80.png", UriKind.Relative);
            CupMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void CupMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-trophy-bw-80.png", UriKind.Relative);
            CupMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void TournamentMenuItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-leaderboard-64.png", UriKind.Relative);
            TournamentMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void TournamentMenuItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-leaderboard-bw-64.png", UriKind.Relative);
            TournamentMenuItem.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void TeamMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentTitle.Content = "TEAM";
        }

        private void PlayerMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentTitle.Content = "PLAYER";
        }

        private void RefereeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentTitle.Content = "REFEREE";
        }

        private void CupMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentTitle.Content = "CUP";
        }

        private void TournamentMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentTitle.Content = "TOURNAMENT";
        }
    }
}
