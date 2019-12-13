﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
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
        public ICommand AddCustomerCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        public ObservableCollection<Customer> CustomerCollection
        {
            get { return _customerCollection;}
        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }

        public CustomerCollectionVM()
        {
            _customerCollection = new ObservableCollection<Customer>();
            AddCustomerCommand = new RelayCommand(AddNewCustomer, null);
            GoBackCommand = new RelayCommand(StoreCollectionVM.GoBackMethod,null);
            //AddCustomer(new Customer("Customer","Email.com","password","20120100"));
        }

        public void AddNewCustomer()
        {
            List<string> infoCheckList = new List<string> { UserName, FirstName, LastName, Email, PhoneNo, Password };
            if (infoCheckList.Any(p => p == null || p == ""))
            {
                UserHandler.contentDialog("Mangler info", "Fejl");
            }
            else
            {
                if (UserHandler.UsernameAvailability(UserName))
                {
                    UserHandler.contentDialog("Brugernavn findes allerede", "Bruger findes");
                }
                else
                {
                    AddCustomer(new Customer(FirstName, LastName, Age, UserName, Email, Password, PhoneNo));
                    ((Frame)Window.Current.Content).Navigate(typeof(LoginPage));
                }
            }
        }

        //A method which adds a new Customer to the list of customers.
        public void AddCustomer(Customer customer)
        {
            //CustomerCollection.Add(customer);
            SingletonUsers.Instance.UserList.Add(customer);
            UserHandler.SaveUsersAsync();
        }
    }

}
