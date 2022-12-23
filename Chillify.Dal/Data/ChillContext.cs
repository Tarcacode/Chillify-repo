using Microsoft.EntityFrameworkCore;

namespace Chillify.Dal.Data;

public class ChillContext : DbContext
{
	public ChillContext(DbContextOptions<ChillContext> options) : base(options)
	{
	}

	public DbSet<Member> Members { get; set; }
	public DbSet<HistoricMember> HistoricMembers { get; set; }
	public DbSet<Address> Addresses { get; set; }
	public DbSet<HistoricAddress> HistoricAddresses { get; set; }
	public DbSet<MemberAddress> MemberAddresses { get; set; }
	public DbSet<HistoricMemberAddress> HistoricMemberAddresses { get; set; }
	public DbSet<Role> Roles { get; set; }
	public DbSet<HistoricRole> HistoricRoles { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Composite PK: 
		modelBuilder.Entity<MemberAddress>().HasKey(ma => new {ma.MemberId, ma.AddressId} );
        modelBuilder.Entity<HistoricMemberAddress>().HasKey(hma => new { hma.HistoricMemberId, hma.HistoricAddressId });

		// Many-to-Many:
		modelBuilder.Entity<MemberAddress>()
			.HasOne(ma => ma.Member)
			.WithMany(ma => ma.MemberAddresses)
			.HasForeignKey(ma => ma.MemberId);

        modelBuilder.Entity<MemberAddress>()
            .HasOne(ma => ma.Address)
            .WithMany(ma => ma.MemberAddresses)
            .HasForeignKey(ma => ma.AddressId);

        modelBuilder.Entity<HistoricMemberAddress>()
            .HasOne(hma => hma.HistoricMember)
            .WithMany(hma => hma.HistoricMemberAddresses)
            .HasForeignKey(ma => ma.HistoricMemberId);

        modelBuilder.Entity<HistoricMemberAddress>()
            .HasOne(hma => hma.HistoricAddress)
            .WithMany(hma => hma.HistoricMemberAddresses)
            .HasForeignKey(hma => hma.HistoricAddressId);

		// Unique:
		modelBuilder.Entity<Member>().HasIndex(m => m.EmailAddress).IsUnique();
        modelBuilder.Entity<Member>().HasIndex(m => m.Pseudo).IsUnique();

        modelBuilder.Entity<HistoricMember>().HasIndex(hm => hm.EmailAddress).IsUnique();
        modelBuilder.Entity<HistoricMember>().HasIndex(hm => hm.Pseudo).IsUnique();

		// Seed:
		modelBuilder.DbSeed();
    }

}
