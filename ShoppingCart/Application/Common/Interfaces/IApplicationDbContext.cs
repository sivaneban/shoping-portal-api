using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Tiqri.CloudShoppingCart.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Tiqri.CloudShoppingCart.Domain.Entities.ProductCategory> ProductCategory { get; set; }
        DbSet<Tiqri.CloudShoppingCart.Domain.Entities.Product> Product { get; set; }

        Task<int> SaveChangesAsync();
    }
}