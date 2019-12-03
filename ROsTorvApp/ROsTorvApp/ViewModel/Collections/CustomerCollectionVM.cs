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
        public ObservableCollection<Customer> CustomerCollection
        {
            get { return _customerCollection;}
        }



        public CustomerCollectionVM()
        {
            _customerCollection = new ObservableCollection<Customer>();
            AddCustomer(new Customer("Customer","Email.com","password","20120100"));
        }
        //A method which adds a new Customer to the list of customers.
        public void AddCustomer(Customer customer)
        {
            CustomerCollection.Add(customer);
        }
    }

}
