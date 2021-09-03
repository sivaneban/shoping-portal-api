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
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace Tiqri.CloudShoppingCart.Application.AccountCQ.Commands
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public async Task<int> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Account account;
                account = await _applicationDbContext.Account.FindAsync(request.Id);
                if (account == null)
                {
                    return Constants.Error;
                }
                else
                {
                    account = new()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        ContactNumber = request.ContactNumber,
                        AccountType = request.AccountType
                    };

                    _applicationDbContext.Account.Update(account);

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
