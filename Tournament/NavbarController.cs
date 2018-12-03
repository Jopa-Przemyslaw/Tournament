using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tournament
{
    class NavbarController
    {
        public NavbarIconsController navbarIconsController;

        MenuItem[] playerNavItems, teamNavItems, refereeNavItems, cupNavItems, tournamentNavItems;

        public NavbarController(/*ref MenuItem[] playerNavItems, ref MenuItem[] teamNavItems, ref MenuItem[] refereeNavItems, ref MenuItem[] cupNavItems, ref MenuItem[] tournamentNavItems*/)
        {
            navbarIconsController = new NavbarIconsController();

            //this.playerNavItems = playerNavItems;
            //this.teamNavItems = teamNavItems;
            //this.refereeNavItems = refereeNavItems;
            //this.cupNavItems = cupNavItems;
            //this.tournamentNavItems = tournamentNavItems;
        }


        public void NavbarItemOnClick(object sender, Border clickedBorder, Border[] otherBorders)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                foreach (var border in otherBorders)
                {
                    border.Visibility = Visibility.Collapsed;
                }
                navbarIconsController.SwitchNavbarIconsOff(otherBorders);
                clickedBorder.Visibility = Visibility.Visible;
            }
            else
            {
                clickedBorder.Visibility = Visibility.Collapsed;
            }
        }
    }
}
