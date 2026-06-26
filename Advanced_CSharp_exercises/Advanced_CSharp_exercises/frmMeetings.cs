using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_CSharp_exercises
{
    public partial class frmMeetings : Form
    {
        public frmMeetings()
        {
            InitializeComponent();
        }

        private void frmMeetings_Load(object sender, EventArgs e)
        {

            // create some venues
            Venue RedLion = new Venue("Red Lion, High Street");
            Venue CostaCoffee = new Venue("Costa Coffee, Market Street");
            Venue CatholicChurch = new Venue("Church of Immaculate Conception, Church Road");

            // create some people
            Customer c1 = new Customer("Rita", "Brown");
            Customer c2 = new Customer("Sue", "Jones");
            Customer c3 = new Customer("Bob", "Smith");

            // arrange some trysts between customers (Bob pessimistically meets 2 ladies)
            Tryst t1 = new Tryst(c1, c3, RedLion, new System.DateTime(2013, 11, 25, 11, 30, 0));
            Tryst t2 = new Tryst(c2, c3, CostaCoffee, new System.DateTime(2013, 11, 25, 12, 0, 0));

            // now add separate room hires for speed dating (2 running simultaneously, 
            // although the Catholic Church one doesn't last as long)
            DateTime whenStart  = new System.DateTime(2013, 11, 22, 10, 0, 0);
            RoomHire rh1 = new RoomHire(CostaCoffee, whenStart, whenStart.AddHours(2));
            RoomHire rh2 = new RoomHire(CatholicChurch, whenStart, whenStart.AddHours(1));

            // now create some happenings!
             List<I_Happening> happenings = new List<I_Happening>();

            happenings.Add(t1);
            happenings.Add(t2);
            happenings.Add(rh1);
            happenings.Add(rh2);

            // add the happenings to the list
            DataTable dtRequests = new DataTable();
            dtRequests.Columns.Add(new DataColumn("Description", typeof(string)));
            dtRequests.Columns.Add(new DataColumn("Addressee", typeof(string)));
            dtRequests.Columns.Add(new DataColumn("Invitation", typeof(string)));

            // add in one row just to show how it's done
		    DataRow drRequest = dtRequests.NewRow();
            drRequest["Description"] = "Personal";
            drRequest["Addressee"] = "Mum";
		    drRequest["Invitation"] = "Fancy dinner on Saturday night?";
		    dtRequests.Rows.Add(drRequest);

            // add in the room hires and trysts
            foreach (I_Happening happening in happenings)
            {
                foreach (Request r in happening.Requests) {

                    DataRow dr = dtRequests.NewRow();
                    dr["Description"] = r.Description;
                    dr["Addressee"] = r.Addressee;
                    dr["Invitation"] = r.Invitation;
                    dtRequests.Rows.Add(dr);
                }
            }

            dgvHappenings.DataSource = dtRequests;
        }
    }
}
