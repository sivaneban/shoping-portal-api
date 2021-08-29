using Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ProductCategory.Commands
{
    public class CreateProductCategoryCommand: IRequest<int>
    {
        public string ProductCategoryName { get; set; }
    }

    public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
    {
        private readonly IDataAccess _dataAccess;
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateProductCategoryCommandHandler(IDataAccess dataAccess, IApplicationDbContext applicationDbContext)
        {
            _dataAccess = dataAccess;
            _applicationDbContext = applicationDbContext;
        }
        public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.ProductCategory()
            {
                ProductCategoryName = request.ProductCategoryName
            };
            _applicationDbContext.ProductCategory.Add(entity);
            int result = await _applicationDbContext.SaveChangesAsync();
            return result;
        }
    }
}
