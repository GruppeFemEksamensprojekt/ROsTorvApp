﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROsTorvApp.Model.Center;

namespace ROsTorvApp.Model.Users
{
    public class Customer : UserAccount
    {
        public ObservableCollection<Store> FavoriteStores { get; set; }

        public Customer(string firstName, string lastName, int age, string userName, string email, string password, string phoneNo)
            : base(firstName,lastName,age, userName,email,password,phoneNo,false)
        {
        }
    }
}
