using Microsoft.EntityFrameworkCore;
using MVC_2024.Models; // Para acessar seu DbContext
using MVC_2024.Services; // Para acessar seus serviços
using MVC_2024.Repositories; // Para acessar os repositórios

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar o DbContext para usar a string de conexão do appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar a classe Connection como IConnectionInterface
// Isso separa a lógica de conexão da lógica de ORM
builder.Services.AddSingleton<IConnectionInterface, Connection>();

// Adicionar os repositórios e serviços
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<EstoqueService>();

// Registrar o DashboardService e IDashboardService
builder.Services.AddScoped<IDashboardService, DashboardService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Mapear uma rota específica para o EstoqueController
app.MapControllerRoute(
    name: "estoque",
    pattern: "Estoque/{action=Index}/{id?}",
    defaults: new { controller = "Estoque" } // Isso garante que a rota Estoque seja sempre direcionada para o EstoqueController
);

// Rota padrão para outros controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
