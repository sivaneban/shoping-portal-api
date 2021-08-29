using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.ProductCategory> ProductCategory { get; set; }
        DbSet<Domain.Entities.Product> Product { get; set; }

        Task<int> SaveChangesAsync();
    }
}