using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetTagCloudListByIdWithBlog(int id);
    }
}
