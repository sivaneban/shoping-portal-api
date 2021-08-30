using Domain.Entities;
//using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class ApplicationDbContext : ShoppingCartContext, Application.Common.Interfaces.IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {
        }

        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<Product> Product { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            var result = await base.SaveChangesAsync();
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

        }
    }
}
