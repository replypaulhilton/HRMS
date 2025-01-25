using HRMS.HRMS.Application.Adminstrator.Response;
using HRMS.HRMS.Application.Common.Interfaces.Persistence;
using MediatR;

namespace HRMS.HRMS.Application.Adminstrator.Queries
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserListResults>
    {
        private readonly IAdminstratorRepository _adminstratorRepository;
        public GetUserQueryHandler(IAdminstratorRepository adminstratorRepository)
        {
            _adminstratorRepository = adminstratorRepository;
        }

        public async Task<GetUserListResults> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var result = await _adminstratorRepository.GetUsers();
            return new GetUserListResults((List<Domain.Entities.User>)result);
        }
    }
}
