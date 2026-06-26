using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_CSharp_exercises 
{
    class RoomHire : I_Happening
    {
        // fields for which room, when
        private DateTime whenStart;
        private DateTime whenEnd;
        private Venue where;
        private Venue venue;

        // public properties exposing fields
        public Venue Venue
        {
            get { return venue; }
            set { venue = value; }
        }

        public DateTime WhenStart
        {
            get { return whenStart; }
            set { whenStart = value; }
        }

        public DateTime WhenEnd
        {
            get { return whenEnd; }
            set { whenEnd = value; }
        }

        // creating a tryst between two partners
        public RoomHire(Venue v, DateTime startTime, DateTime endTime)
        {
            {
                whenStart = startTime;
                whenEnd = endTime;
                venue = v;
            }
        }

        // properties required by interface
        string Description
        {
            get
            {
                return "Room hire";
            }
        }

        string Attendee
        {
            get
            {
                return venue.Name;
            }
        }

        // as required by interface, return a collection of requests
        public List<Request> Requests
        {
            get
            {
                List<Request> requests = new List<Request>();
                Request request = new Request("Room hire", venue.Name,
                    "Please book the usual room from " +
                    whenStart.ToString("HH:mm:ss") + " to " +
                    whenEnd.ToString("HH:mm:ss") + " on " +
                    whenStart.ToString("dd/MM/yyyy"));
                requests.Add(request);
                return requests;
            }
        }

    }
}
