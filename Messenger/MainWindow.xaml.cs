﻿using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace Messenger
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private WindowState PrevWindowState = WindowState.Normal;
        private NotifyIcon notify;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowsCloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowsMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            PrevWindowState = WindowState;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(0.3));
            anim.Completed += (s, _) =>
            {
                this.WindowState = WindowState.Minimized;
                TrayInit();

            };

            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void WindowsMaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState temp = (this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal);
            DoubleAnimation anim1 = new DoubleAnimation(1, 0, (Duration)TimeSpan.FromSeconds(0.33));
            DoubleAnimation anim2 = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.33));

            anim1.Completed += (s, _) =>
            {
                this.WindowState = temp;
                this.BeginAnimation(OpacityProperty, anim2);
            };

            this.BeginAnimation(OpacityProperty, anim1);
        }

        private void WindowsTitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void WindowsMaximizeButton_Click(object sender, MouseButtonEventArgs e)
        {

        }

        #region Tray Mode

        private void TrayInit()
        {
            ContextMenu menu = new ContextMenu();
            MenuItem item1 = new MenuItem();
            menu.MenuItems.Add(item1);

            item1.Index = 0;
            item1.Text = "Close App";
            item1.Click += (s, _) =>
            {
                notify.Dispose();
                Environment.Exit(0);
            };

            notify = new NotifyIcon();
            notify.DoubleClick += new EventHandler(Window_Activated);
            notify.Icon = Properties.Resources.icons8_facebook_messenger_512;
            notify.Visible = true;
            notify.ContextMenu = menu;
        }

        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var anim = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(1));
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closing -= Window_Closing;
            e.Cancel = true;
            var anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
            anim.Completed += (s, _) => Environment.Exit(0);
            this.BeginAnimation(UIElement.OpacityProperty, anim);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
            {
                this.WindowState = PrevWindowState;
                var anim = new DoubleAnimation(0, 1, (Duration)TimeSpan.FromSeconds(0.3));
                anim.Completed += (s, _) =>
                {
                    notify.Dispose();

                };
                this.BeginAnimation(UIElement.OpacityProperty, anim);
            }
            else
            {
                Opacity = 1.0;
            }
        }
    }
}
