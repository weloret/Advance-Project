using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using TaskCentralWebApp.Models;
using Task = System.Threading.Tasks.Task;

namespace TaskCentralWebApp.Areas.Identity.Data
{
    public class ContextSeed
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<Users> userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            if (!roleManager.RoleExistsAsync(Roles.Admin).GetAwaiter().GetResult())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }
            if (!roleManager.RoleExistsAsync(Roles.User).GetAwaiter().GetResult())
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            }
        }

        public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<Users> userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            TaskCentralDBContext context = new TaskCentralDBContext();
            var defaultUser = new Users
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            User dbUser = new User
            {
                UserName = "admin"
            };
            if (userManager.Users.All(x => x.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Test@123");
                    dbUser.AspUserId = defaultUser.Id;
                    context.Users.Add(dbUser);
                    context.SaveChanges();
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin);
                }
            }
        }

        public static async Task SeedTestUsersAsync(IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<Users> userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            TaskCentralDBContext context = serviceProvider.GetRequiredService<TaskCentralDBContext>();

            var testUsers = new List<Users>
    {
        new Users { UserName = "user1@test.com", Email = "user1@test.com", EmailConfirmed = true, PhoneNumberConfirmed = true },
        new Users { UserName = "user2@test.com", Email = "user2@test.com", EmailConfirmed = true, PhoneNumberConfirmed = true },
        new Users { UserName = "user3@test.com", Email = "user3@test.com", EmailConfirmed = true, PhoneNumberConfirmed = true }
    };
            int userCount = 1;
            foreach (var user in testUsers)
            {
                var nickName = $"user{userCount}";
                var existingUser = await userManager.FindByEmailAsync(user.Email);
                if (existingUser == null)
                {
                    await userManager.CreateAsync(user, "Test@123");
                    context.Users.Add(new User { UserName = nickName, AspUserId = user.Id });
                    context.SaveChanges();
                    await userManager.AddToRoleAsync(user, Roles.User);
                }
                userCount++;
            }
        }
    }
}
