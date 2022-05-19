﻿using FoodDeliveryDomain.Models;

namespace OrderService.Graphql
{
    public class OrderData
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public int UserId { get; set; }
        public int CourierId { get; set; }
        public List<OrderDetailData> Details { get; set; }

    }
}
