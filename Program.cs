using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Turicentro_Estructura_de_datos.Models;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios de sesión
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiración de la sesión
    options.Cookie.HttpOnly = true; // Seguridad adicional
    options.Cookie.IsEssential = true; // Requerido para cumplir con RGPD
});

// Agregar servicios al contenedor
builder.Services.AddControllersWithViews();
var conString = builder.Configuration.GetConnectionString("Conexion") ??
     throw new InvalidOperationException("Connection string 'BloggingContext'" +
    " not found.");
builder.Services.AddDbContext<DbTuricentroContext>(options =>
    options.UseSqlServer(conString));

var app = builder.Build();

// Configurar el middleware HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // El valor predeterminado de HSTS es 30 días. Puedes cambiarlo en producción.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Habilitar sesiones
app.UseAuthentication(); // Si estás utilizando autenticación
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TblUsuarios}/{action=Login}/{id?}");

app.Run();
