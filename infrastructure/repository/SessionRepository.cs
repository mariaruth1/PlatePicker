using System.Data;
using infrastructure.repository.interfaces;

namespace infrastructure.repository;

public class SessionRepository: ISessionRepository
{
    private readonly IDbConnection _connection;
    
    public SessionRepository(IDbConnection connection)
    {
        _connection = connection;
    }
}