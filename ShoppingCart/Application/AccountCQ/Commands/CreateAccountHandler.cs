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
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, int>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateAccountHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Account account;
                account = await _applicationDbContext.Account.FindAsync(request.Email);
                if (account != null)
                {
                    return Constants.Error;
                }
                else
                {
                    account = new Account()
                    {
                        FirstName = request.FirstName,
                        LastName = account.LastName,
                        Email = account.Email,
                        AccountType = account.AccountType,
                        ContactNumber = account.ContactNumber
                    };

                    await _applicationDbContext.Account.AddAsync(account);
                    return await _applicationDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return Constants.Exception;
            }
        }
    }
}
