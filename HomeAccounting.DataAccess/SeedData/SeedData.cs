using HomeAccounting.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Models.SeedData
{
    public static class SeedData
    {
        public static void SeedApplicationData(this ModelBuilder builder)
        {
            var password = "JoyceLedi124";
            var passworHasher = new PasswordHasher<IdentityUser>();
            var roleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
           

            var user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Ledi",
                NormalizedUserName = "LEDI",
                Email = "joyceledi26@gmail.com",
                NormalizedEmail = "JOYCLELEDI26@GMAIL.COM",
                PhoneNumber = "+375257716193",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                AccessFailedCount = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                TwoFactorEnabled = false

            };

            var passwordHash = passworHasher.HashPassword(user, password);
            user.PasswordHash = passwordHash;
           // userManager.CreateAsync(user, password).Wait();

            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = user.Id,
            });
        }
    }
}

