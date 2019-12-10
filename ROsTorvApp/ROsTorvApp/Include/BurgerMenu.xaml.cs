using ROsTorvApp.View;
using System;
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
using ROsTorvApp.Helpers;
using ROsTorvApp.ViewModel.Collections;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ROsTorvApp.Include
{
    public sealed partial class BurgerMenu : UserControl
    {
        public BurgerMenu()
        {
            this.InitializeComponent();
            this.DataContext = new StoreCollectionVM();
        }
        
        private void Button_AdminPanel(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(AdminPanel));
        }

        private void Button_Logout(object sender, RoutedEventArgs e)
        {
            ((Frame)Window.Current.Content).Navigate(typeof(LoginPage));
        }
    }
}
