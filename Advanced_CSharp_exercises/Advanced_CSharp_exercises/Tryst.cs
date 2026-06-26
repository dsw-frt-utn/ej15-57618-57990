using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_CSharp_exercises
{
    class Tryst : I_Happening
    {

        // fields for who's meeting who, when, where
        private Customer partner1;
        private Customer partner2;
        private DateTime when;
        private Venue where;

        // public properties exposing fields
        public Customer Partner1 {
            get { return partner1; }
            set { partner1 = value; }
        }

        public Customer Partner2 {
            get { return partner2; }
            set { partner2 = value; }
        }

        public DateTime When {
            get { return when; }
            set { when = value; }
        }

        public Venue Where {
            get { return where; }
            set { where = value; }
        }

        // creating a tryst between two partners
        public Tryst(Customer who1, Customer who2, Venue location, DateTime dateAndTime)
        {
            partner1 = who1;
            partner2 = who2;
            where = location;
            when = dateAndTime;
        }

        // as required by interface, return a collection of requests
        public List<Request> Requests
        {
            get
            {
                List<Request> requests = new List<Request>();

                // invite first partner
                Request request1 = new Request("Tryst invitation", 
                    partner1.FirstName + " " + partner1.LastName,
                    "Come and meet " + partner2.FirstName + " " + partner2.LastName + " at the " +
                    where.Name + " at " + when.ToString("HH:mm:ss") + " on " +
                    when.ToString("dd/MM/yyyy"));
                requests.Add(request1);

                // invite second partner
                Request request2 = new Request("Tryst invitation",
                    partner2.FirstName + " " + partner2.LastName,
                    "Come and meet " + partner1.FirstName + " " + partner1.LastName + " at the " +
                    where.Name + " at " + when.ToString("HH:mm:ss") + " on " +
                    when.ToString("dd/MM/yyyy"));
                requests.Add(request2);
                
                return requests;
            }
        }

    }
}
