using HRMS.HRMS.Application.Adminstrator.Response;
using MediatR;
using Microsoft.Identity.Client;

namespace HRMS.HRMS.Application.Adminstrator.Queries
{


    public record GetUserQuery(
    string UserType
    ) : IRequest<GetUserListResults>;
}
