﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookDomain.Entities
{
	public class FooterAddress
	{
		public int FooterAddressID { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
	}
}
