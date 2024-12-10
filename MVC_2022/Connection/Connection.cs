using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

public class Connection : IConnectionInterface
{
    private readonly string _connectionString;

    public Connection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
                            ?? throw new ArgumentNullException(nameof(configuration), "Connection string cannot be null");
    }

    // Retorna a string de conexão
    public string GetConnectionString()
    {
        return _connectionString;
    }

    // Cria e retorna uma instância de SqlConnection
    public SqlConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }

    // Método para abrir a conexão
    public void OpenConnection(SqlConnection connection)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection), "Connection cannot be null");
        }

        if (connection.State != System.Data.ConnectionState.Open)
        {
            connection.Open();
        }
    }

    // Método para fechar a conexão
    public void CloseConnection(SqlConnection connection)
    {
        if (connection == null)
        {
            throw new ArgumentNullException(nameof(connection), "Connection cannot be null");
        }

        if (connection.State == System.Data.ConnectionState.Open)
        {
            connection.Close();
        }
    }
}
