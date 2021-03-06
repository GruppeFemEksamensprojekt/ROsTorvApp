﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ROsTorvApp.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ROsTorvApp.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public static PasswordBox PasswordBox { get; set; }
        public LoginPage()
        {
            this.InitializeComponent();
            PasswordBox = PasswordBoxDerp;
        }

        private void UIElement_OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.KeyStatus.ScanCode == 28)
            {
                ((dynamic) this.DataContext).LoginAction();
            }
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((dynamic) this.DataContext).Password = ((PasswordBox) sender).Password;
            }
        }
    }
}
