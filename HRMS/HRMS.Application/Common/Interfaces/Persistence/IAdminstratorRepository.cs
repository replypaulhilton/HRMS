using HRMS.HRMS.Domain.Entities;

namespace HRMS.HRMS.Application.Common.Interfaces.Persistence
{
    public interface IAdminstratorRepository
    {
        Task<User?> CreateUser(string Email, string Password, string Role);
        Task<IEnumerable<User>> GetUsers();
    }
}
