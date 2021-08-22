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
    public class CommandHandler : IRequestHandler<CreateProductCategoryCommand, Domain.Entities.ProductCategory>
    {
        private readonly IDataAccess dataAccess;

        public CommandHandler(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess;
        }
        public Task<Domain.Entities.ProductCategory> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            //ProductCategory
            return Task.FromResult(dataAccess.Create(request));
        }
    }
}
