using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Infra.IoC;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BankingDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDbConnection")));

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new() { Title = "Banking Microservice", Version = "v1" });
            });

            // Add MediatR FIX THIS
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));


            DependencyContianer.RegisterServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1"));

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
