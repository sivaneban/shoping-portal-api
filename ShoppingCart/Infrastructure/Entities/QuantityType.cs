using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Entities
{
    public partial class QuantityType
    {
        public int QuantityTypeId { get; set; }
        public string QuantityTypeName { get; set; }
        public string QuantityDetail { get; set; }
    }
}
