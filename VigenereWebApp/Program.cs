
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using VigenereWebApp;

namespace VigenereWebApp
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            // Register dependencies
            builder.Services.AddSingleton<KeyGenerator>(); // Singleton since it has no state
            builder.Services.AddTransient<VigenereCipher>(); // Transient since it processes data per request

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Vigenere API", Version = "v1" });
            });

            var app = builder.Build();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "My Vigenere API V1");
                options.RoutePrefix = string.Empty;
            });

            app.MapControllers();
            app.Run();
        }
    }
}
