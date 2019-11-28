using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Users;


namespace ROsTorvApp.ViewModel.Collections
{
    class CustomerCollectionVM
    {
        private RelayCommand _NavigateCommand;
        public Customer Customer1;
        public ObservableCollection<Customer> CustomerCollection { get; set; }

        public CustomerCollectionVM()
        {
           AddCustomer(Customer1 = new Customer("Customer","Email.com","password","20120100"));
        }

        public void AddCustomer(Customer customer)
        {
            CustomerCollection.Add(customer);
        }
    }

}
