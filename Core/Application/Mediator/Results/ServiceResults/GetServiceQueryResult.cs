using MediatR;

namespace Application.Mediator.Results.ServiceResults
{
	public class GetServiceQueryResult:IRequest<List<GetServiceQueryResult>>
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
