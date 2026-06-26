using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_CSharp_exercises
{
    interface I_Happening
    {
        // a happening must support a list of invitations
        List<Request> Requests { get; }

    }
}
