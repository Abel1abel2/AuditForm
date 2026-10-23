using Microsoft.AspNetCore.Identity;

namespace AuditForm.Data
{
    public class IdentityRoleSeeder
    {
        public static async Task SeedRolesAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

           
            string[] roleNames = { "Admin", "Audit Officer" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                 
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
