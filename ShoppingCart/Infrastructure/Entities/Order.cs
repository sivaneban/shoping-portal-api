﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}