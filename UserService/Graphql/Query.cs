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

        [Authorize]
        public IQueryable<Profile> GetProfilesbyToken([Service] FoodDeliveryContext context, ClaimsPrincipal claimsPrincipal)
        {
            var username = claimsPrincipal.Identity.Name;
            var user = context.Users.Where(o => o.Username == username).FirstOrDefault();
            if (user != null)
            {
                var profiles = context.Profiles.Where(o => o.UserId == user.Id);
                return profiles.AsQueryable();
            }
            return new List<Profile>().AsQueryable();
        }

        [Authorize] // dapat diakses kalau sudah login
        public IQueryable<Courier> GetCouriers([Service] FoodDeliveryContext context) =>
            context.Couriers.Select(p => new Courier()
            {
                CourierName = p.CourierName,
                PhoneNumber = p.PhoneNumber
            });
    }
}
