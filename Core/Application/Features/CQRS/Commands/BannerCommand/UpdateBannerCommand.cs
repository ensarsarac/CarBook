using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BannerCommand
{
	public class UpdateBannerCommand
	{
		public int BannerID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string VideoDescription { get; set; }
		public string VideoUrl { get; set; }
	}
}
