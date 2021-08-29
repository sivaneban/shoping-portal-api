using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.ProductCategory> ProductCategory { get; set; }

        Task<int> SaveChangesAsync();
    }
}