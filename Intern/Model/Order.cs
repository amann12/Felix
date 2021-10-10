using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intern.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string RecieverName { get; set; }
        public string DropLocation { get; set; }
        public string PickLocation { get; set; }
        public string OrderId { get; set; }
        public string Type { get; set; }
        public string Weight { get; set; }
        public string Dimensions { get; set; }
        public string TotalCost { get; set; }
        public string Status { get; set; }

        public string RecieverPinCode { get; set; }
        public string RecieverPhoneNumber { get; set; }
        public string ValueOfParcel { get; set; }
        public string UserName { get; set; }
        public string SenderPhoneNumber { get; set; }
        public string PinCode { get; set; }
        public string PickUpDate { get; set; }
        public string PickUpTime { get; set; }
        public string OrderAssignId { get; set; }
    }
}
