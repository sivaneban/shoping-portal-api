// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MediatR;
using Tiqri.CloudShoppingCart.Application.Common.DTO;
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace Tiqri.CloudShoppingCart.Application.AccountCQ.Queries
{
    public class GetAccountDetailsQuery : IRequest<AccountDTO>
    {
        public int Id { get; set; }
    }
}
