using System;
using Npgsql;

namespace Infrestucture.Data;

public class DataContext
{
    private const string ConnectionString = "Server=localhost;Database=dapperDB;Username=postgres;Password=m.613524";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(ConnectionString);
    }
}
