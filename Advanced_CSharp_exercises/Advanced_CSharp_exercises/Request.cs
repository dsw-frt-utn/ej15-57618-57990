using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_CSharp_exercises
{
    struct Request
    {

        // lazy programming - just use public fields
        public string Description;
        public string Addressee;
        public string Invitation;

        public Request(string what, string who, string invite)
        {
            Description = what;
            Addressee = who;
            Invitation = invite;
        }
    }
}
