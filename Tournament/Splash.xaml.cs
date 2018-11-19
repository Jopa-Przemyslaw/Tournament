﻿using System;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Tournament
{
    /// <summary>
    /// Interaction logic for Splash.xaml
    /// </summary>
    public partial class Splash : Window
    {
        MainWindow mainWindow = new MainWindow();

        public Splash()
        {
            InitializeComponent();
        }

        private void Move(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnStartApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            mainWindow.Show();
        }

        private void BtnClose_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-64.png", UriKind.Relative);
            btnClose.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void BtnClose_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-delete-80.png", UriKind.Relative);
            btnClose.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void BtnMinimize_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-down-button-80.png", UriKind.Relative);
            btnMinimize.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void BtnMinimize_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-down-button-bw-80.png", UriKind.Relative);
            btnMinimize.Background = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream));
        }

        private void BtnStartApp_MouseEnter(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-next-80.png", UriKind.Relative);
            ImageBrush imageBrush = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream))
            {
                Stretch = Stretch.None
            };
            btnStartApp.Background = imageBrush;
        }

        private void BtnStartApp_MouseLeave(object sender, MouseEventArgs e)
        {
            Uri resourceUri = new Uri(@"/media/icons8-next-bw-80.png", UriKind.Relative);
            ImageBrush imageBrush = new ImageBrush(BitmapFrame.Create(Application.GetResourceStream(resourceUri).Stream))
            {
                Stretch = Stretch.None
            };
            btnStartApp.Background = imageBrush;
        }
    }
}
