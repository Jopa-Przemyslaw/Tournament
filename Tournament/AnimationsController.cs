using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Tournament
{
    class AnimationsController
    {
        readonly Thickness outsideScreen;
        readonly Thickness insideScreen;
        readonly MainWindow mainWindow;

        Storyboard storyboard;
        ThicknessAnimation thicknessAnimation;


        public AnimationsController(PropertyPath propertyPath, MainWindow mainWindow)
        {
            this.mainWindow= mainWindow;
            this.storyboard = new Storyboard();
            this.thicknessAnimation = new ThicknessAnimation();

            outsideScreen = new Thickness(1000, 80, -875, 15);
            insideScreen = new Thickness(5, 80, 120, 15);

            thicknessAnimation.BeginTime = new TimeSpan(0);
            thicknessAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            Storyboard.SetTargetProperty(thicknessAnimation, propertyPath);
        }

        public void RollIn(ref object sender, string borderName)
        {
            thicknessAnimation.SetValue(Storyboard.TargetNameProperty, borderName);

            thicknessAnimation.From = outsideScreen;
            thicknessAnimation.To = insideScreen;

            storyboard.Children.Add(thicknessAnimation);
            storyboard.Begin(mainWindow);
        }

        public Task<Visibility> RollOut(Border sender)
        {

            thicknessAnimation.SetValue(Storyboard.TargetNameProperty, sender.Name);

            thicknessAnimation.From = insideScreen;
            thicknessAnimation.To = outsideScreen;

            storyboard.Children.Add(thicknessAnimation);
            storyboard.Begin(mainWindow);

            return Task.Run(() =>
             {
                 System.Threading.Thread.Sleep(500);
                 return Visibility.Collapsed;
             });
        }
    }
}
