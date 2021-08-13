using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IDataAccess
    {
        List<Domain.Entities.Product> GetProducts();
        Domain.Entities.Product AddProduct(string name, string category);
    }
}
