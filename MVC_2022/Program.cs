using Microsoft.EntityFrameworkCore;
using MVC_2024.Models; // Para acessar seu DbContext
using MVC_2024.Services; // Para acessar seus servi�os
using MVC_2024.Repositories; // Para acessar os reposit�rios

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configurar o DbContext para usar a string de conex�o do appsettings.json
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar a classe Connection como IConnectionInterface
// Isso separa a l�gica de conex�o da l�gica de ORM
builder.Services.AddSingleton<IConnectionInterface, Connection>();

// Adicionar os reposit�rios e servi�os
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

// Mapear uma rota espec�fica para o EstoqueController
app.MapControllerRoute(
    name: "estoque",
    pattern: "Estoque/{action=Index}/{id?}",
    defaults: new { controller = "Estoque" } // Isso garante que a rota Estoque seja sempre direcionada para o EstoqueController
);

// Rota padr�o para outros controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
