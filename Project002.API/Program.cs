
using Microsoft.EntityFrameworkCore;
using Project002.Repository.Models;

namespace Project002.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region add features
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //var constr = @"Server=TEC-8220-LA0025;Database=cinema2023; Trusted_Connection=true";
            //builder.Services.AddDbContext<DatabaseContext>(o => o.UseSqlServer(constr));

            string conStr = @"Server=TEC-8220-LA0025;Database=Project002; Trusted_Connection=true";
            builder.Services.AddDbContext<Dbcontext>(obj => obj.UseSqlServer(conStr));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion add features












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
