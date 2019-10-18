using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forma1Example.Data
{
    public class FeedUser
    {
        
        public static async Task SeedUsersAsync(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            
            var userStore = new UserStore<IdentityUser>(context);

            if (!context.Users.Any(x => x.UserName == "admin"))
            {

                var roleStore = new RoleStore<IdentityRole>(context);
                await roleStore.CreateAsync(new IdentityRole { Name = "admin" });


                var user = new IdentityUser {
                    UserName = "admin",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true

                };
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(user, "admin");
                user.PasswordHash = hashed;

                await userManager.CreateAsync(user);
                context.Users.Add(user);
                await context.SaveChangesAsync();

                await userStore.AddToRoleAsync(user, "admin");
            }
        }
    }
}
