// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MediatR;

namespace Tiqri.CloudShoppingCart.Application.AccountCQ.Commands
{
    public class UpdateAccountCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountType { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
}
}
