
using FinalDoctor_Api.Data;
using FinalDoctor_Api.Helper;
using FinalDoctor_Api.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalDoctor_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<db_context>(optiens => optiens.UseSqlServer(builder.Configuration.GetConnectionString("x")));

            builder.Services.AddScoped(typeof(IGeneric<>), typeof(Generic<>));
            builder.Services.AddScoped<Doctor_Repo>();
            builder.Services.AddAutoMapper(typeof(Profilemapping));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
          

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
