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


        public NavbarIconsController()
        {
        }

        public void SwitchNavbarIconsOff(Border[] borders)
        {
            foreach (var item in borders)
            {
                item.Visibility = Visibility.Collapsed;
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
    }
}
