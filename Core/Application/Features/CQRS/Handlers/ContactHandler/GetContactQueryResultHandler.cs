using Application.Features.CQRS.Commands.ContactCommand;
using Application.Features.CQRS.Results.ContactResult;
using Application.Interfaces;
using CarBookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.ContactHandler
{
    public class GetContactQueryResultHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryResultHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResult()
            {
                ContactID = x.ContactID,
                Email=x.Email,
                Message = x.Message,
                Name = x.Name,
                Subject = x.Subject,
                SendDate=DateTime.Now,
            }).ToList();
        }



    }
}
