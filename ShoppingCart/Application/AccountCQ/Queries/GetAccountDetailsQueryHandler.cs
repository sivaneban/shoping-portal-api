// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tiqri.CloudShoppingCart.Application.Common.DTO;
using Tiqri.CloudShoppingCart.Application.Common.Interfaces;
using Tiqri.CloudShoppingCart.Domain.Entities;

namespace Tiqri.CloudShoppingCart.Application.AccountCQ.Queries
{
    public class GetAccountDetailsQueryHandler : IRequestHandler<GetAccountDetailsQuery, AccountDTO>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public GetAccountDetailsQueryHandler(IApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<AccountDTO> Handle(GetAccountDetailsQuery request, CancellationToken cancellationToken)
        {
            Account account = await _applicationDbContext.Account.FindAsync(request.Id);
            return _mapper.Map<AccountDTO>(account);
        }
    }
}
