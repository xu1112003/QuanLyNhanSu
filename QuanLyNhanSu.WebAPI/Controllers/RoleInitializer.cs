using Microsoft.AspNetCore.Identity;
using QuanLyNhanSu.Models.Entities;

namespace QuanLyNhanSu.WebAPI.Controllers
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Tạo các vai trò
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            // Tạo người dùng mặc định và gán vai trò
            var adminUser = await userManager.FindByNameAsync("admin");
            if (adminUser == null)
            {
                adminUser = new ApplicationUser { Email = "Admin2@gmail.com" };
                await userManager.CreateAsync(adminUser, "Admin123@");
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }

            //var regularUser = await userManager.FindByNameAsync("user");
            //if (regularUser == null)
            //{
            //    regularUser = new ApplicationUser { UserName = "user", Email = "user@example.com" };
            //    await userManager.CreateAsync(regularUser, "User@123");
            //    await userManager.AddToRoleAsync(regularUser, "User");
            //}
        }
    }
}
