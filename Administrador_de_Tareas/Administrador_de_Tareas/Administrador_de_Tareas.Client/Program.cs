using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Administrador_de_Tareas.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            await builder.Build().RunAsync();
        }
    }
}
