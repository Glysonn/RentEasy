using System.Data;

namespace RentEasy.Application.Abstractions.Data;

internal interface ISqlConnectionFactory
{
    IDbConnection CreateConnection();
}
