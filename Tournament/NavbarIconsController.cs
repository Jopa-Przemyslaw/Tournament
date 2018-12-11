using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Tournament
{
    class NavbarIconsController
    {
        readonly static Uri addUriOn = new Uri(@"/media/icons8-plus-512.png", UriKind.Relative);
        readonly static Uri addUriOff = new Uri(@"/media/icons8-plus-bw-512.png", UriKind.Relative);
        readonly static Uri assignTeamUriOn = new Uri(@"/media/icons8-to-team-64.png", UriKind.Relative);
        readonly static Uri assignTeamUriOff = new Uri(@"/media/icons8-to-team-bw-64.png", UriKind.Relative);
        readonly static Uri leaveTeamUriOn = new Uri(@"/media/icons8-out-of-team-64.png", UriKind.Relative);
        readonly static Uri leaveTeamUriOff = new Uri(@"/media/icons8-out-of-team-bw-64.png", UriKind.Relative);
        readonly static Uri removeUriOn = new Uri(@"/media/icons8-delete-64.png", UriKind.Relative);
        readonly static Uri removeUriOff = new Uri(@"/media/icons8-delete-80.png", UriKind.Relative);
        readonly static Uri previewUriOn = new Uri(@"/media/icons8-preview-pane-100.png", UriKind.Relative);
        readonly static Uri previewUriOff = new Uri(@"/media/icons8-preview-pane-bw-100.png", UriKind.Relative);
        readonly static Uri refereeUriOn = new Uri(@"/media/icons8-in-referee-80.png", UriKind.Relative);
        readonly static Uri refereeUriOff = new Uri(@"/media/icons8-in-referee-bw-80.png", UriKind.Relative);
        readonly static Uri assignRefereeUriOn = new Uri(@"/media/icons8-in-referee-80.png", UriKind.Relative);
        readonly static Uri assignRefereeUriOff = new Uri(@"/media/icons8-in-referee-bw-80.png", UriKind.Relative);
        readonly static Uri playUriOn = new Uri(@"/media/icons8-next-80.png", UriKind.Relative);
        readonly static Uri playUriOff = new Uri(@"/media/icons8-next-bw-80.png", UriKind.Relative);
        readonly static Uri daisUriOn = new Uri(@"/media/icons8-leaderboard-64.png", UriKind.Relative);
        readonly static Uri daisUriOff = new Uri(@"/media/icons8-leaderboard-bw-64.png", UriKind.Relative);

        readonly ImageBrush addImageOn =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(addUriOn).Stream));
        readonly ImageBrush addImageOff =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(addUriOff).Stream));
        readonly ImageBrush assignTeamImageOn =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(assignTeamUriOn).Stream));
        readonly ImageBrush assignTeamImageOff =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(assignTeamUriOff).Stream));
        readonly ImageBrush leaveTeamImageOn =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(leaveTeamUriOn).Stream));
        readonly ImageBrush leaveTeamImageOff =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(leaveTeamUriOff).Stream));
        readonly ImageBrush removeImageOn =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(removeUriOn).Stream));
        readonly ImageBrush removeImageOff =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(removeUriOff).Stream));
        readonly ImageBrush previewImageOn =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(previewUriOn).Stream));
        readonly ImageBrush previewImageOff =  new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(previewUriOff).Stream));
        readonly ImageBrush refereeImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(refereeUriOn).Stream));
        readonly ImageBrush refereeImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(refereeUriOff).Stream));
        readonly ImageBrush assignRefereeImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(assignRefereeUriOn).Stream));
        readonly ImageBrush assignRefereeImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(assignRefereeUriOff).Stream));
        readonly ImageBrush playImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(playUriOn).Stream));
        readonly ImageBrush playImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(playUriOff).Stream));
        readonly ImageBrush daisImageOn = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(daisUriOn).Stream));
        readonly ImageBrush daisImageOff = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(daisUriOff).Stream));

        MainWindow mainWindow;

        public NavbarIconsController()
        {
        }

        public void SwitchNavbarIconOn(ref MenuItem menuItem)
        {
            if (menuItem.Name == "NavBarItem_Player" || menuItem.Name == "NavBarItem_Team" || menuItem.Name == "NavBarItem_Referee" || menuItem.Name == "NavBarItem_Cup")
            {
                AddIconOn(ref menuItem);
            }
            else if (menuItem.Name == "NavBarItem2_Player" || menuItem.Name == "NavBarItem1_Team" || menuItem.Name == "NavBarItem1_Cup")
            {
                AssignIconOn(ref menuItem);
            }
            else if (menuItem.Name == "NavBarItem3_Player" || menuItem.Name == "NavBarItem2_Team" || menuItem.Name == "NavBarItem3_Cup")
            {
                LeaveTeamIconOn(ref menuItem);
            }
            else if (menuItem.Name == "NavBarItem4_Player" || menuItem.Name == "NavBarItem3_Team" || menuItem.Name == "NavBarItem1_Referee")
            {
                RemoveIconOn(ref menuItem);
            }
            else if (menuItem.Name == "NavBarItem5_Player" || menuItem.Name == "NavBarItem4_Team" || menuItem.Name == "NavBarItem2_Referee" || menuItem.Name == "NavBarItem4_Cup" || menuItem.Name == "NavBarItem5_Cup")
            {
                PreviewIconOn(ref menuItem);
            }
            else if(menuItem.Name == "NavBarItem2_Cup")
            {
                AssignRefereeIconOn(ref menuItem);
            }
            else if (menuItem.Name == "NavBarItem_Tournament")
            {
                PlayIconOn(ref menuItem);
            }
            else if (menuItem.Name == "NavBarItem1_Tournament")
            {
                DaisIconOn(ref menuItem);
            }
        }

        public void SwitchNavbarIconsOff(ref MenuItem[] menuItems)
        {
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (menuItems[i].Name == "NavBarItem_Player" || menuItems[i].Name == "NavBarItem_Team" || menuItems[i].Name == "NavBarItem_Referee" || menuItems[i].Name == "NavBarItem_Cup")
                {
                    AddIconOff(ref menuItems[i]);
                }
                else if (menuItems[i].Name == "NavBarItem2_Player" || menuItems[i].Name == "NavBarItem1_Team" || menuItems[i].Name == "NavBarItem1_Cup")
                {
                    AssignIconOff(ref menuItems[i]);
                }
                else if (menuItems[i].Name == "NavBarItem3_Player" || menuItems[i].Name == "NavBarItem2_Team" || menuItems[i].Name == "NavBarItem3_Cup")
                {
                    LeaveTeamIconOff(ref menuItems[i]);
                }
                else if (menuItems[i].Name == "NavBarItem4_Player" || menuItems[i].Name == "NavBarItem3_Team" || menuItems[i].Name == "NavBarItem1_Referee")
                {
                    RemoveIconOff(ref menuItems[i]);
                }
                else if (menuItems[i].Name == "NavBarItem5_Player" || menuItems[i].Name == "NavBarItem4_Team" || menuItems[i].Name == "NavBarItem2_Referee" || menuItems[i].Name == "NavBarItem4_Cup" || menuItems[i].Name == "NavBarItem5_Cup")
                {
                    PreviewIconOff(ref menuItems[i]);
                }
                else if(menuItems[i].Name == "NavBarItem2_Cup")
                {
                    AssignRefereeIconOff(ref menuItems[i]);
                }
                else if(menuItems[i].Name == "NavBarItem_Tournament")
                {
                    PlayIconOff(ref menuItems[i]);
                }
                else if (menuItems[i].Name == "NavBarItem1_Tournament")
                {
                    DaisIconOff(ref menuItems[i]);
                }
            }
        }

        public void AddIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = addImageOn;
        }
        public void AddIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = addImageOff;
        }
        public void AssignIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = assignTeamImageOn;
        }
        public void AssignIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = assignTeamImageOff;
        }
        public void LeaveTeamIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = leaveTeamImageOn;
        }
        public void LeaveTeamIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = leaveTeamImageOff;
        }
        public void RemoveIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = removeImageOn;
        }
        public void RemoveIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = removeImageOff;
        }
        public void PreviewIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = previewImageOn;
        }
        public void PreviewIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = previewImageOff;
        }
        public void RefereeIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = refereeImageOn;
        }
        public void RefereeIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = refereeImageOff;
        }
        public void AssignRefereeIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = assignRefereeImageOn;
        }
        public void AssignRefereeIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = assignRefereeImageOff;
        }
        public void PlayIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = playImageOn;
        }
        public void PlayIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = playImageOff;
        }
        public void DaisIconOn(ref MenuItem menuItem)
        {
            menuItem.Background = daisImageOn;
        }
        public void DaisIconOff(ref MenuItem menuItem)
        {
            menuItem.Background = daisImageOff;
        }
    }
}
