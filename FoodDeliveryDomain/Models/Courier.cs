using System;
using System.Collections.Generic;

namespace FoodDeliveryDomain.Models
{
    public partial class Courier
    {
        public int Id { get; set; }
        public string CourierName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
