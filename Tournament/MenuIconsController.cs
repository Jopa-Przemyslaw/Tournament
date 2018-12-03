using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Tournament
{
    class MenuIconsController
    {
        readonly Uri playerUriOn = new Uri(@"/media/icons8-soccer-64.png", UriKind.Relative);
        readonly Uri playerUriOff = new Uri(@"/media/icons8-soccer-bw-64.png", UriKind.Relative);
        readonly Uri teamUriOn = new Uri(@"/media/icons8-team-64.png", UriKind.Relative);
        readonly Uri teamUriOff = new Uri(@"/media/icons8-team-bw-64.png", UriKind.Relative);
        readonly Uri refereeUriOn = new Uri(@"/media/icons8-referee-filled-80.png", UriKind.Relative);
        readonly Uri refereeUriOff = new Uri(@"/media/icons8-referee-80.png", UriKind.Relative);
        readonly Uri cupUriOn = new Uri(@"/media/icons8-trophy-color-80.png", UriKind.Relative);
        readonly Uri cupUriOff = new Uri(@"/media/icons8-trophy-bw-80.png", UriKind.Relative);
        readonly Uri tournamentUriOn = new Uri(@"/media/icons8-leaderboard-64.png", UriKind.Relative);
        readonly Uri tournamentUriOff = new Uri(@"/media/icons8-leaderboard-bw-64.png", UriKind.Relative);

        readonly ImageBrush playerImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-soccer-64.png", UriKind.Relative)).Stream));
        readonly ImageBrush playerImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-soccer-bw-64.png", UriKind.Relative)).Stream));
        readonly ImageBrush teamImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-team-64.png", UriKind.Relative)).Stream));
        readonly ImageBrush teamImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-team-bw-64.png", UriKind.Relative)).Stream));
        readonly ImageBrush refereeImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-referee-filled-80.png", UriKind.Relative)).Stream));
        readonly ImageBrush refereeImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-referee-80.png", UriKind.Relative)).Stream));
        readonly ImageBrush cupImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-trophy-color-80.png", UriKind.Relative)).Stream));
        readonly ImageBrush cupImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-trophy-bw-80.png", UriKind.Relative)).Stream));
        readonly ImageBrush tournamentImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-leaderboard-64.png", UriKind.Relative)).Stream));
        readonly ImageBrush tournamentImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(new Uri(@"/media/icons8-leaderboard-bw-64.png", UriKind.Relative)).Stream));

        MainWindow mainWindow;
        readonly Border[] borders;

        public MenuIconsController(ref Border[] borders, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.borders = borders;
        }

        public void SwitchMenuIconOn(ref MenuItem menuItem)
        {
            if (menuItem.Name == "PlayerMenuItem")
            {
                PlayerIconOn();
            }
            else if (menuItem.Name == "TeamMenuItem")
            {
                TeamIconOn();
            }
            else if (menuItem.Name == "RefereeMenuItem")
            {
                RefereeIconOn();
            }
            else if (menuItem.Name == "CupMenuItem")
            {
                CupIconOn();
            }
            else if (menuItem.Name == "TournamentMenuItem")
            {
                TournamentIconOn();
            }
        }
        public void SwitchMenuIconOn(Border border)
        {
            if (border == borders[0])
            {
                PlayerIconOn();
            }
            else if (border == borders[1])
            {
                TeamIconOn();
            }
            else if (border == borders[2])
            {
                RefereeIconOn();
            }
            else if (border == borders[3])
            {
                CupIconOn();
            }
            else if (border == borders[4])
            {
                TournamentIconOn();
            }
        }
        public void SwitchMenuIconOff(ref MenuItem menuItem)
        {
            if (menuItem.Name == "PlayerMenuItem")
            {
                PlayerIconOff();
            }
            else if (menuItem.Name == "TeamMenuItem")
            {
                TeamIconOff();
            }
            else if (menuItem.Name == "RefereeMenuItem")
            {
                RefereeIconOff();
            }
            else if (menuItem.Name == "CupMenuItem")
            {
                CupIconOff();
            }
            else if (menuItem.Name == "TournamentMenuItem")
            {
                TournamentIconOff();
            }
        }
        public void SwitchMenuIconOff(Border border)
        {
            if (border == borders[0])
            {
                PlayerIconOff();
            }
            else if (border == borders[1])
            {
                TeamIconOff();
            }
            else if (border == borders[2])
            {
                RefereeIconOff();
            }
            else if (border == borders[3])
            {
                CupIconOff();
            }
            else if (border == borders[4])
            {
                TournamentIconOff();
            }
        }
        
        public void SwitchOffMenuIcons()
        {
            if (borders[0].Visibility != System.Windows.Visibility.Collapsed)
            {
                PlayerIconOn();
            }
            else
            {
                PlayerIconOff();
            }
            if (borders[1].Visibility != System.Windows.Visibility.Collapsed)
            {
                TeamIconOn();
            }
            else
            {
                TeamIconOff();
            }
            if (borders[2].Visibility != System.Windows.Visibility.Collapsed)
            {
                RefereeIconOn();
            }
            else
            {
                RefereeIconOff();
            }
            if (borders[3].Visibility != System.Windows.Visibility.Collapsed)
            {
                CupIconOn();
            }
            else
            {
                CupIconOff();
            }
            if (borders[4].Visibility != System.Windows.Visibility.Collapsed)
            {
                TournamentIconOn();
            }
            else
            {
                TournamentIconOff();
            }
        }
        

        public void PlayerIconOn()
        {
            mainWindow.PlayerMenuItem.Background = playerImageOn;
        }
        public void PlayerIconOff()
        {
            mainWindow.PlayerMenuItem.Background = playerImageOff;
        }
        public void TeamIconOn()
        {
            mainWindow.TeamMenuItem.Background = teamImageOn;
        }
        public void TeamIconOff()
        {
            mainWindow.TeamMenuItem.Background = teamImageOff;
        }
        public void RefereeIconOn()
        {
            mainWindow.RefereeMenuItem.Background = refereeImageOn;
        }
        public void RefereeIconOff()
        {
            mainWindow.RefereeMenuItem.Background = refereeImageOff;
        }
        public void CupIconOn()
        {
            mainWindow.CupMenuItem.Background = cupImageOn;
        }
        public void CupIconOff()
        {
            mainWindow.CupMenuItem.Background = cupImageOff;
        }
        public void TournamentIconOff()
        {
            mainWindow.TournamentMenuItem.Background = tournamentImageOff;
        }
        public void TournamentIconOn()
        {
            mainWindow.TournamentMenuItem.Background = tournamentImageOn;
        }
    }
}
