using Backend;
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
        /// <summary>The navbar icons controller.</summary>
        public NavbarIconsController navbarIconsController;

        /// <summary>
        /// Initializes a new instance of the <see cref="NavbarController" /> class.
        /// </summary>
        /// <param name="playerNavItems">The player nav items.</param>
        public NavbarController()
        {
            navbarIconsController = new NavbarIconsController();
        }


        /// <summary>
        /// Methon called when navbar item is clicked. If item was opened before than it shuts off icon's illumination and collapses contnent. If wasn't than it illuminates its icon and displays content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="clickedBorder"><see cref="Border" /> that was clicked.</param>
        /// <param name="otherBorders">Other <see cref="Border"/>s in navbar.</param>
        /// <param name="navItems">The navbar <see cref="MenuItem"/>s.</param>
        /// <param name="clickedNavItem">The clicked navbar item.</param>
        public void NavbarItemOnClick(object sender, Border clickedBorder, Border[] otherBorders, ref MenuItem[] navItems, ref MenuItem clickedNavItem)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                SwitchNavbarItemsOff(ref otherBorders);
                navbarIconsController.SwitchNavbarIconsOff(ref navItems);

                clickedBorder.Visibility = Visibility.Visible;
                navbarIconsController.SwitchNavbarIconOn(ref clickedNavItem);
            }
            else
            {
                clickedBorder.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Methon called when navbar item is clicked. Displays list of <see cref="Player"/>s. If item was opened before than it shuts off icon's illumination and collapses contnent. If wasn't than it illuminates its icon and displays content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="clickedBorder">The clicked <see cref="Border"/>.</param>
        /// <param name="otherBorders">The other <see cref="Border"/>s.</param>
        /// <param name="navItems">The navbar <see cref="MenuItem"/>s.</param>
        /// <param name="clickedNavItem">The clicked navbar <see cref="MenuItem"/>.</param>
        /// <param name="players">The list of <see cref="Player"/>s to display.</param>
        /// <param name="listBox">The <see cref="ListBox"/> to display in.</param>
        public void NavbarItemOnClick(object sender, Border clickedBorder, Border[] otherBorders, ref MenuItem[] navItems, ref MenuItem clickedNavItem, ref List<Player> players, ref ListBox listBox)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                SwitchNavbarItemsOff(ref otherBorders);
                navbarIconsController.SwitchNavbarIconsOff(ref navItems);

                clickedBorder.Visibility = Visibility.Visible;
                navbarIconsController.SwitchNavbarIconOn(ref clickedNavItem);
                listBox.ItemsSource = null;
                listBox.ItemsSource = players;
                listBox.Items.Refresh();

            }
            else
            {
                clickedBorder.Visibility = Visibility.Collapsed;
                listBox.ItemsSource = null;
            }
        }

        /// <summary>
        /// Methon called when navbar item is clicked. Displays list of <see cref="Team"/>s. If item was opened before than it shuts off icon's illumination and collapses contnent. If wasn't than it illuminates its icon and displays content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="clickedBorder">The clicked <see cref="Border"/>.</param>
        /// <param name="otherBorders">The other <see cref="Border"/>s.</param>
        /// <param name="navItems">The navbar <see cref="MenuItem"/>s.</param>
        /// <param name="clickedNavItem">The clicked navbar <see cref="MenuItem"/>.</param>
        /// <param name="teams">The list of <see cref="Team"/>s to display.</param>
        /// <param name="listBox">The <see cref="ListBox"/> to display in.</param>
        public void NavbarItemOnClick(object sender, Border clickedBorder, Border[] otherBorders, ref MenuItem[] navItems, ref MenuItem clickedNavItem, ref List<Team> teams, ref ListBox listBox)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                SwitchNavbarItemsOff(ref otherBorders);
                navbarIconsController.SwitchNavbarIconsOff(ref navItems);

                clickedBorder.Visibility = Visibility.Visible;
                navbarIconsController.SwitchNavbarIconOn(ref clickedNavItem);
                listBox.ItemsSource = null;
                listBox.ItemsSource = teams;
                listBox.Items.Refresh();
            }
            else
            {
                clickedBorder.Visibility = Visibility.Collapsed;
                listBox.ItemsSource = null;
            }
        }

        /// <summary>
        /// Methon called when navbar item is clicked. Displays list of <see cref="Referee"/>s. If item was opened before than it shuts off icon's illumination and collapses contnent. If wasn't than it illuminates its icon and displays content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="clickedBorder">The clicked <see cref="Border"/>.</param>
        /// <param name="otherBorders">The other <see cref="Border"/>s.</param>
        /// <param name="navItems">The nav <see cref="MenuItem"/>s.</param>
        /// <param name="clickedNavItem">The clicked nav <see cref="MenuItem"/>.</param>
        /// <param name="referees">The list of <see cref="Referee"/>s to display.</param>
        /// <param name="listBox">The <see cref="ListBox"/> to display in.</param>
        public void NavbarItemOnClick(object sender, Border clickedBorder, Border[] otherBorders, ref MenuItem[] navItems, ref MenuItem clickedNavItem, ref List<Referee> referees, ref ListBox listBox)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                SwitchNavbarItemsOff(ref otherBorders);
                navbarIconsController.SwitchNavbarIconsOff(ref navItems);

                clickedBorder.Visibility = Visibility.Visible;
                navbarIconsController.SwitchNavbarIconOn(ref clickedNavItem);
                listBox.ItemsSource = null;
                listBox.ItemsSource = referees;
                listBox.Items.Refresh();
            }
            else
            {
                clickedBorder.Visibility = Visibility.Collapsed;
                listBox.ItemsSource = null;
            }
        }

        /// <summary>
        /// Methon called when navbar item is clicked. Displays list of <see cref="Cup"/>s. If item was opened before than it shuts off icon's illumination and collapses contnent. If wasn't than it illuminates its icon and displays content.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="clickedBorder">The clicked <see cref="Border"/>.</param>
        /// <param name="otherBorders">The other <see cref="Border"/>s.</param>
        /// <param name="navItems">The navbar <see cref="MenuItem"/>s.</param>
        /// <param name="clickedNavItem">The clicked navbar <see cref="MenuItem"/>.</param>
        /// <param name="teams">The list of <see cref="Cup"/>s to display.</param>
        /// <param name="listBox">The <see cref="ListBox"/> to display in.</param>
        public void NavbarItemOnClick(object sender, Border clickedBorder, Border[] otherBorders, ref MenuItem[] navItems, ref MenuItem clickedNavItem, ref List<Cup> cups, ref ListBox listBox)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                SwitchNavbarItemsOff(ref otherBorders);
                navbarIconsController.SwitchNavbarIconsOff(ref navItems);

                clickedBorder.Visibility = Visibility.Visible;
                navbarIconsController.SwitchNavbarIconOn(ref clickedNavItem);
                listBox.ItemsSource = null;
                listBox.ItemsSource = cups;
                listBox.Items.Refresh();
            }
            else
            {
                clickedBorder.Visibility = Visibility.Collapsed;
                listBox.ItemsSource = null;
            }
        }

        /// <summary>
        /// Switches the navbar items off. Only colapses the borders. Icons are left without changes.
        /// </summary>
        /// <param name="borders">The borders to collapse.</param>
        public void SwitchNavbarItemsOff(ref Border[] borders)
        {
            foreach (var border in borders)
            {
                border.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Switches the navbar items off. Colapses the borders and shuts off icon's illumination.
        /// </summary>
        /// <param name="borders">The borders to collapse.</param>
        /// <param name="menuItems">The menu items to switch off.</param>
        public void SwitchNavbarItemsOff(ref Border[] borders, ref MenuItem[] menuItems)
        {
            foreach (var border in borders)
            {
                border.Visibility = Visibility.Collapsed;
            }
            navbarIconsController.SwitchNavbarIconsOff(ref menuItems);
        }
    }
}
