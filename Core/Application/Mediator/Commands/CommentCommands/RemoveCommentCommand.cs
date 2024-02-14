using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Commands.CommentCommands
{
    public class RemoveCommentCommand:IRequest
    {
        public RemoveCommentCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
