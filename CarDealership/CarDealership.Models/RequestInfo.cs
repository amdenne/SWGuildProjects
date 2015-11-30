using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models
{
    public class RequestInfo
    {
        public int RequestInfoID { get; set; }
        public int VehicleID { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BestTimeToCall { get; set; }
        public string PreferredContactMethod { get; set; }
        public DateTime TimeframeToPurchase { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime LastContactDate { get; set; }
        public int RequestStatus { get; set; }
    }
}
