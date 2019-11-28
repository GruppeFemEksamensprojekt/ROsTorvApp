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
    public class CustomerCollectionVM
    {
        
        public Customer Customer1;
        private ObservableCollection<Customer> _customerCollection;
        public static ObservableCollection<Customer> CustomerCollection { get; set; }

        public CustomerCollectionVM()
        {
            AddCustomer(Customer1 = new Customer("Customer","Email.com","password","20120100"));
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
