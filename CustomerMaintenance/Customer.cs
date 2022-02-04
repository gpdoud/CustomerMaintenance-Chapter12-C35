using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerMaintenance {
    public class Customer {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string GetDisplayText(string sep = "\t") => $"{FirstName}{sep}{LastName}{sep}{Email}";

        public Customer() { }

        //public Customer(string firstName, string lastName, string email) => 
        //    (FirstName, LastName, Email) = (FirstName, lastName, email);

        public Customer(string firstName, string lastName, string email) {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
