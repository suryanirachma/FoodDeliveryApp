using FoodDeliveryDomain.Models;
using HotChocolate.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserService.Graphql
{
    public class Query
    {
        [Authorize]
        public async Task<IQueryable<User>> GetUsers([Service] FoodDeliveryContext context, ClaimsPrincipal claimsPrincipal)
        {
            var userName = claimsPrincipal.Identity.Name;

            // check admin role ?
            var adminRole = claimsPrincipal.Claims.Where(o => o.Type == ClaimTypes.Role && o.Value == "Admin").FirstOrDefault();
            var user = context.Users.Where(o => o.Username == userName).FirstOrDefault();
            if (user != null)
            {
                if (adminRole != null)
                    return context.Users;
            }
            return new List<User>().AsQueryable();
        }
    }
}
