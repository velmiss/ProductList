using Microsoft.AspNetCore.Identity;

namespace ProductApp.Data
{

    public static class DbInitializer
    {
        public static async Task Initialize(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            //create 3 users one with Admin, User and Guest Role
            if (context.Users.Any())
            {
                return;
            }

   
            var role = new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" };

            var user = new IdentityUser { UserName = "admin@admin.fi", Email = "admin@admin.fi", EmailConfirmed = true };
            await roleManager.CreateAsync(role);
            
            await userManager.CreateAsync(user, "Asdf1234!");

            await userManager.AddToRoleAsync(user, role.Name);

            context.SaveChanges();


        }
    }
}


