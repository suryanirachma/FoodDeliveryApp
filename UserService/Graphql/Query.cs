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

        [Authorize(Roles = new[] { "Manager" })]
        public IQueryable<User> GetCouriers([Service] FoodDeliveryContext context)
        {
            var rolecourier = context.Roles.Where(c => c.Name == "Courier").FirstOrDefault();
            var couriers = context.Users.Where(c => c.UserRoles.Any(o => o.RoleId == rolecourier.Id));
            return couriers.AsQueryable();
        }

        [Authorize] // dapat diakses kalau sudah login
        public IQueryable<CourierProfile> GetCourierProfiles([Service] FoodDeliveryContext context) =>
            context.CourierProfiles.Select(p => new CourierProfile()
            {
                CourierName = p.CourierName,
                PhoneNumber = p.PhoneNumber,
                Availabality = p.Availabality,
                UserId = p.UserId
            });
    }
}
