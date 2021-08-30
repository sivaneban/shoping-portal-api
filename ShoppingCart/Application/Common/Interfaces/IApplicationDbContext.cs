using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.ProductCategory> ProductCategory { get; set; }
        DbSet<Domain.Entities.Product> Product { get; set; }

        Task<int> SaveChangesAsync();
    }
}