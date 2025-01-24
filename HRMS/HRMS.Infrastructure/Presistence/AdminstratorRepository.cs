using Dapper;
using System.Data;
using HRMS.HRMS.Application.Common.Interfaces.Persistence;
using HRMS.HRMS.Domain.Entities;
using HRMS.HRMS.Presentation.WebApi.Contracts.NewUserAccount;
using HRMS.Infrastructure;
using User = HRMS.HRMS.Domain.Entities.User;

namespace BankApplication.Infrastructure.Presistence;

public class AdminstratorRepository : IAdminstratorRepository
{
    private readonly DapperContext _context;

    public AdminstratorRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<User?> CreateUser(string Email, string Password, string Role)
    {
        using (var db = _context.CreateConnection())
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@customerId", Email);
                parameters.Add("@userId", Password);
                parameters.Add("@frequency", Role);
               
                var result = await db.QuerySingleAsync<User>("CreateUser", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public async Task<IEnumerable<User>> GetUsers() { 
      using (var db = _context.CreateConnection())
        {
            return await db.QueryAsync<User>("GetUsers", commandType: CommandType.StoredProcedure);
        }
    }
}

