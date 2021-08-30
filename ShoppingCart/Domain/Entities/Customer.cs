﻿#nullable disable

namespace Tiqri.CloudShoppingCart.Domain.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
    }
}
