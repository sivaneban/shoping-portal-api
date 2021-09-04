// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;
using FluentValidation.Results;

namespace ShoppingCart.Api.Models
{
    public class ValidateRequest<T>
    {
        /// <summary>
        ///     The deserialized value of the request.
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     Whether or not the deserialized value was found to be valid.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        ///     The collection of validation errors.
        /// </summary>
        public IList<ValidationFailure> Errors { get; set; }
    }
}
