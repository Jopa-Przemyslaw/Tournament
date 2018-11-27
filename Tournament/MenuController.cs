using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Tournament
{
    class MenuController
    {
        readonly string mainTitle;
        readonly Border[] otherBordersInMenu;

        MainWindow mainWindow;
        Label labelWithContentTitle;
        public MenuIconsController menuIconsController;
        AnimationsController animationsController;

        public MenuController(ref Border[] otherBordersInMenu, MainWindow mainWindow, Label labelWithContentTitle, PropertyPath propertyPath)
        {
            mainTitle = "TOURNAMENT MAIN";
            this.otherBordersInMenu = otherBordersInMenu;

            this.mainWindow = mainWindow;
            this.labelWithContentTitle = labelWithContentTitle;
            menuIconsController = new MenuIconsController(ref otherBordersInMenu, mainWindow);
            animationsController = new AnimationsController(propertyPath, mainWindow);
        }

        public async Task MenuItemOnClick(object sender, Border clickedBorder)
        {
            if (clickedBorder.Visibility == Visibility.Collapsed)
            {
                foreach (var border in otherBordersInMenu)
                {
                    if (border != clickedBorder)
                    {
                        if (border.Visibility == Visibility.Visible)
                        {
                            border.Visibility = await animationsController.RollOut(border);
                            menuIconsController.SwitchMenuIconOff(border);
                        }
                    }
                    else
                    {
                        clickedBorder.Visibility = Visibility.Visible;
                        menuIconsController.SwitchMenuIconOn(clickedBorder);
                        animationsController.RollIn(ref sender, clickedBorder.Name);
                        labelWithContentTitle.Content = clickedBorder.Tag;
                    }
                }
            }
            else
            {
                clickedBorder.Visibility = await animationsController.RollOut(clickedBorder);
                labelWithContentTitle.Content = mainTitle;
                menuIconsController.SwitchMenuIconOff(clickedBorder);

                // ContainerContent_Player.Visibility = await AsyncCollapsed();
            }
        }
    }
}
