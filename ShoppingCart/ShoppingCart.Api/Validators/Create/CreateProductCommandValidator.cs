// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Tiqri.CloudShoppingCart.Application.Product.Commands;

namespace ShoppingCart.Api.Validators.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            
            RuleFor(r => r.ProductName).NotNull().NotEmpty();
            RuleFor(r => r.ProductCategoryId).NotNull().NotEmpty();
            RuleFor(r => r.QuantityTypeId).NotNull().NotEmpty();
            RuleFor(r => r.Quantity).NotNull().NotEmpty();
            RuleFor(r => r.ProductPrice).NotNull().NotEmpty();
        }
    }
}
