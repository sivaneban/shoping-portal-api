// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;

namespace Tiqri.CloudShoppingCart.Application.ProductCategory.Commands
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, bool>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateProductCategoryCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.ProductCategory category = await _applicationDbContext.ProductCategory.FindAsync(request.Id);
            if(category is null)
            {
                return false;
            }
            else
            {
                category.ProductCategoryId = request.Id;
                category.ProductCategoryName = request.Name;
                _applicationDbContext.ProductCategory.Update(category);
                int result =await _applicationDbContext.SaveChangesAsync();
                return result == 1;
            }
        }
    }
}
