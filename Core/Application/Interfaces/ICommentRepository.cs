using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentListByBlog(int id);
    }
}
