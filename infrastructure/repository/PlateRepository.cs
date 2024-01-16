using System.Data;
using infrastructure.repository.interfaces;

namespace infrastructure.repository;

public class PlateRepository: IPlateRepository
{
    private readonly IDbConnection _connection;
    
    public PlateRepository(IDbConnection connection)
    {
        _connection = connection;
    }
}