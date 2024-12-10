using Microsoft.EntityFrameworkCore;
using MVC_2024.Models;

public class ApplicationDbContext : DbContext
{
    private readonly IConnectionInterface _connectionStringProvider;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConnectionInterface connectionStringProvider)
        : base(options)
    {
        _connectionStringProvider = connectionStringProvider;
    }

    public DbSet<EstoqueModel> Estoques { get; set; }
    public DbSet<MovimentacaoModel> Movimentacao { get; set; }

    // Método para configurar o DbContext
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.GetConnectionString());
        }
    }
}
