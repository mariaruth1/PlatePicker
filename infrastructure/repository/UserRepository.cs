using System.Data;
using infrastructure.repository.interfaces;

namespace infrastructure.repository;

public class UserRepository: IUserRepository
{
    private readonly IDbConnection _connection;
    
    public UserRepository(IDbConnection connection)
    {
        _connection = connection;
    }
}