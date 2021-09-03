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
using Tiqri.CloudShoppingCart.Application.Product.Commands;
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace Tiqri.CloudShoppingCart.Application.AccountCQ.Commands
{
    public class AccountDeleteHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AccountDeleteHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Account account = await _applicationDbContext.Account.FindAsync(request.Id);
                if (account == null)
                {
                    return Constants.Error;
                }
                else
                {
                    _applicationDbContext.Account.Remove(account);
                    return  await _applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return Constants.Exception;
            }
        }
    }
}
