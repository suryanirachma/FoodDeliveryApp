using FoodDeliveryDomain.Models;
using HotChocolate.AspNetCore.Authorization;

namespace FoodService.Graphql
{
    public class Query
    {
            [Authorize(Roles = new[] { "Buyer" })]
            public IQueryable<Food> GetFoods([Service] FoodDeliveryContext context) =>
                context.Foods;
    }
}
