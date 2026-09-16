using Library.DBInfrastructure.Data;
using Library.DBInfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.API
{
    /// <summary>
    /// Punctul de intrare principal al aplicatiei Web API unde se configureaza serverul
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Inregistreaza serviciile necesare si stabileste ordinea de procesare a request-urilor
        /// </summary>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Conectam Entity Framework la SQL Server folosind adresa din appsettings.json
            builder.Services.AddDbContext<LibraryContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Inregistram Repository ul generic ca Scoped pentru a l putea injecta in controllere
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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