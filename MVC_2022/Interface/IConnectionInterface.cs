using Microsoft.Data.SqlClient;

public interface IConnectionInterface
{
    string GetConnectionString();  
    SqlConnection CreateConnection();  
}
