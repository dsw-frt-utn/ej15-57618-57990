using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_CSharp_exercises
{
    class Venue
    {
        // the venue name
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Venue(string where)
        {

            // create a new venue
            name = where;

        }
    }
}
