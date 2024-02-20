using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.RentACar
{
	public class ResultRentACarDto
	{
        public int LocationID { get; set; }
		public DateOnly PickUpDate { get; set; }
		public DateOnly DropOffDate { get; set; }
		public TimeOnly PickUpTime { get; set; }
		public TimeOnly DropOffTime { get; set; }
	}
}
