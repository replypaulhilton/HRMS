using System.Security.Principal;

namespace HRMS.HRMS.Presentation.WebApi.Contracts.NewUserAccount
{
    public record NewUserAccountResponse
    (int UserId,
    User User);

    public record User(
        Guid UserId,
        string Email,
        string Password,
        string Role);
}
