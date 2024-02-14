using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Commands.ContactCommand
{
    public class RemoveContactCommand
    {
        public RemoveContactCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
