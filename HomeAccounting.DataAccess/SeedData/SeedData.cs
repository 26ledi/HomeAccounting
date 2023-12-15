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
            var adminRoleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });


            var clientRoleId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = clientRoleId,
                    Name = "Client",
                    NormalizedName = "CLIENT"
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


            builder.Entity<IdentityUser>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = user.Id,
            });

            // Suppose you want to assign "Client" role to another user
      
            var anotherUser = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "Wisdom",
                NormalizedUserName = "WISDOM",
                Email = "wisdomledi@gmail.com",
                NormalizedEmail = "WISDOMLEDI@GMAIL.COM",
                PhoneNumber = "+375257716193",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                AccessFailedCount = 0,
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                LockoutEnabled = true,
                TwoFactorEnabled = false

            };

            var anotherUserPasswordHash = passworHasher.HashPassword(anotherUser, "AnotherPassword");
            anotherUser.PasswordHash = anotherUserPasswordHash;

            builder.Entity<IdentityUser>().HasData(anotherUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = clientRoleId,
                UserId = anotherUser.Id,
            });
        }
    }
}
    


