using Galaxy.TomaPedido.AccesoDatos.Contexto;
using Galaxy.TomaPedido.Repositorios.Implementaciones;
using Galaxy.TomaPedido.Repositorios.Interfaces;
using Galaxy.TomaPedido.Servicio.Implementaciones;
using Galaxy.TomaPedido.Servicio.Interfaces;
using Galaxy.TomaPedido.UI.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<BdpedidosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdPedidos"));
});

builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IMaestroRepositorio, MaestroRepositorio>();

builder.Services.AddScoped<IClienteServicio, ClienteServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
