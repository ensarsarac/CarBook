using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookDomain.Entities
{
    public class RentACarProcess
    {
        public int RentACarProcessId { get; set; }
        public int CarID { get; set; }
        public Car Car{ get; set; }
        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }
        public DateOnly PickUpDate{ get; set; }
        public DateOnly DropOffDate{ get; set; }
        public TimeOnly PickUpTime{ get; set; }
        public TimeOnly DropOffTime{ get; set; }
        public int CustomerId{ get; set; }
        public Customer Customer{ get; set; }
        public string PickupDescription { get; set; }
        public string DropOffDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
