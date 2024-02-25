using Application.Interfaces;
using Application.Mediator.Queries.AppUserQueries;
using Application.Mediator.Results.AppUserResults;
using CarBookDomain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mediator.Handlers.AppUserHandlers
{
	public class GetCheckAppUserQueryResultHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IAppUserRepository _appUserRepository;
		private readonly IRepository<AppRole> _appRole;

		public GetCheckAppUserQueryResultHandler(IAppUserRepository appUserRepository, IRepository<AppRole> appRole)
		{
			_appUserRepository = appUserRepository;
			_appRole = appRole;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserRepository.GetByFilterAsync(x=>x.Username == request.Username && x.Password==request.Password );
			var role = await _appRole.GetByIdAsync(user.AppRoleId);
			var roleName = role.AppRoleName;
            if (user == null)
            {
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.Username = request.Username;
				values.Role = roleName;
				values.Id = user.AppUserId;
			}
			return values;
        }
	}
}
