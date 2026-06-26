using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_CSharp_exercises
{
    class Customer
    {

        // fields
        private string firstName;
        private string lastName;

        // public exposure of same
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Customer(string first, string last)
        {

            // create a new customer
            firstName = first;
            lastName = last;
        }

    }
}
