using Authorization.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Authorization.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.PensionUser.AnyAsync()) return;

            List<string> users = File.ReadAllLines("../../users.csv").Skip(1).Select(v => v).ToList();
            foreach (string user in users)
            {
                using var hmac = new HMACSHA512();
                var user1 = new AppUser();
                user1.UserName = user;
                user1.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Passwor%"));
                user1.PasswordSalt = hmac.Key;
                context.PensionUser.Add(user1);
            }

            await context.SaveChangesAsync();   
        }
    }
}
