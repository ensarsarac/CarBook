using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.BannerCommand
{
	public class RemoveBannerCommand
	{
		public RemoveBannerCommand(int id)
		{
			Id = id;
		}

		public int Id { get; set; }
    }
}
