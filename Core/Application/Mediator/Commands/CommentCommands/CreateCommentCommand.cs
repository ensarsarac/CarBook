using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Commands.CommentCommands
{
    public class CreateCommentCommand:IRequest
    {
        public string AuthorName { get; set; }
        public string AuthorImage { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public string BlogName { get; set; }
        public DateTime Date { get; set; }
    }
}
