using Microsoft.EntityFrameworkCore;

namespace Chillify.Dal.Data;

public static class DataSeed
{
    public static void DbSeed(this ModelBuilder modelBuilder) 
    {
        modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    Id = 1,
                    Title = "None",
                    Description = "No Role"
                },
                new Role()
                {
                    Id = 2,
                    Title = "Visitor",
                    Description = "Basic role for newcomers"
                },
                new Role()
                {
                    Id = 3,
                    Title = "Member",
                    Description = "Classic role for contributing members"
                },
                new Role()
                {
                    Id = 4,
                    Title = "Manager",
                    Description = "Advanced role to manage the website"
                },
                new Role()
                {
                    Id = 5,
                    Title = "Administrator",
                    Description = "Most advanced role to administrate the website"
                });

        SeedGenerator seedGenerator = new();

        modelBuilder.Entity<Member>().HasData(seedGenerator.GetMembers());
        modelBuilder.Entity<Address>().HasData(seedGenerator.GetAddresses());
        modelBuilder.Entity<MemberAddress>().HasData(seedGenerator.GetMemberAddresses());

    }
}
