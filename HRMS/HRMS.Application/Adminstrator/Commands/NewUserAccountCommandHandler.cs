using HRMS.HRMS.Application.Adminstrator.Response;
using HRMS.HRMS.Application.Common.Interfaces.Persistence;
using HRMS.HRMS.Domain.Entities;
using MediatR;

namespace HRMS.HRMS.Application.Adminstrator.Commands
{
    public class NewUserAccountCommandHandler : IRequest<NewUserAccountCommand>
    {
        private readonly IAdminstratorRepository _adminstratorRepository;
        public NewUserAccountCommandHandler(IAdminstratorRepository adminstratorRepository)
        {
            _adminstratorRepository = adminstratorRepository;
        }

        public async Task<User> Handle(NewUserAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await _adminstratorRepository.CreateUser(request.Email, request.Role, request.Password);

            return result;

        }
    }
}
