using Microsoft.EntityFrameworkCore;

namespace Lesson39_Web_API_Crud.Database
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration= builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:SwaggerConnection"]);
        }

        public DbSet<Product> Products { get; set; }
    }
}
