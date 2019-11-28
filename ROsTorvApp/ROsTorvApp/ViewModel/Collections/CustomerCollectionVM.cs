using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using ROsTorvApp.Helpers;
using ROsTorvApp.Model.Users;
using ROsTorvApp.View;


namespace ROsTorvApp.ViewModel.Collections
{
    class CustomerCollectionVM
    {
        private RelayCommand _navigateToOpretBrugerCommand;
        public Customer Customer1;
        public ObservableCollection<Customer> CustomerCollection { get; set; }

        public CustomerCollectionVM()
        {
            _navigateToOpretBrugerCommand = new RelayCommand(Navigation, null);
           AddCustomer(Customer1 = new Customer("Customer","Email.com","password","20120100"));
        }

        public ICommand NavigateCommand
        {
            get { return _navigateToOpretBrugerCommand; }
        }

        private void Navigation()
        {
        }

        public void AddCustomer(Customer customer)
        {
            CustomerCollection.Add(customer);
        }
    }

}
