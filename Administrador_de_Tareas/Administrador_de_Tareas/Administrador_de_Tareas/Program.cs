using Administrador_de_Tareas.Client.Pages;
using Administrador_de_Tareas.Components;
using Administrador_de_Tareas.Infraestructure;
using Administrador_de_Tareas.Repository;
using Microsoft.EntityFrameworkCore;

namespace Administrador_de_Tareas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            builder.Services.AddScoped<IRepository, TODORepository>();

            string database = builder.Configuration.GetConnectionString("ConectionDB")!;

            builder.Services.AddDbContext<TODOListDbContext>(options =>
            {
                options.UseSqlServer(database);
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<TODOListDbContext>();
                dbContext.Database.EnsureCreated();
                dbContext.SaveChanges();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
