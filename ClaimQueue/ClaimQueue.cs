using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimAdjuster
{
    public class ClaimQueue
    {
        private Queue<ClaimItem> _listOfClaims = new Queue<ClaimItem>();

        //public void ListOfCurrentClaims()
        //{
        //   //foreach (KeyValuePair<int, ClaimItem> kvp in _listOfClaims)
        //    {
        //        ClaimItem x = (ClaimItem)kvp.Value;
        //        Console.WriteLine("ClaimID = " + x.ClaimID + "  ClaimType = " + x.ClaimType + "  Description = " + x.Description + "  ClaimAmouint = " + x.ClaimAmount + "  DateOfIncident = " + x.DateOfIncident + " DateOfClaim = " + x.DateOfClaim);
        //    }

        //}
        //public bool RemoveClaimFromQueue();
    }
}
