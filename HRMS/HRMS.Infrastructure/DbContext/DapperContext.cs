using System.Data;
using Dapper;
using HRMS.Infrastructure.Presistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace HRMS.Infrastructure;

public class DapperContext
{
    private readonly DapperSettings _dapperSettings;

    public DapperContext(IOptions<DapperSettings> DapperSettings)
    {
        _dapperSettings = DapperSettings.Value;
    }

    public IDbConnection CreateConnection()
        => new SqlConnection(_dapperSettings.SqlServer);

}



