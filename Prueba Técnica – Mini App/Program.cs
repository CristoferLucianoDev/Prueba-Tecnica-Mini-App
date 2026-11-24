using Microsoft.EntityFrameworkCore;
using Prueba_Técnica___Mini_App.Datos;
using Prueba_Técnica___Mini_App.Services;

namespace Prueba_Técnica___Mini_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IBookServices, BookServices>();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    if (app.Environment.IsDevelopment())
                    {
                        options.SwaggerEndpoint("/openapi/v1.json", "v1");
                        options.RoutePrefix = "swagger";
                    }
                });
            }

            app.UseHttpsRedirection();
            app.UseCors();

            // Sirve wwwroot/index.html en "/" (misma origen que la API, sin CORS).
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
