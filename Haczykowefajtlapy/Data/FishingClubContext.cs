using Haczykowefajtlapy.Model;
using Microsoft.EntityFrameworkCore;

namespace Haczykowefajtlapy.Data;

public class FishingClubContext : DbContext
{
    public FishingClubContext(DbContextOptions<FishingClubContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<FishingCompetition> FishingCompetitions { get; set; }
    public DbSet<CompetitionResult> CompetitionResults { get; set; }
    public DbSet<FishingLog> FishingLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(200);
            entity.Property(e => e.JoinDate).HasDefaultValueSql("CURRENT_DATE");
            entity.Property(e => e.MembershipFeePaid).HasDefaultValue(false);

            var memberSeeds = new List<Member>();
            for (int i = 1; i <= 20; i++)
            {
                memberSeeds.Add(new Member
                {
                    Id = i,
                    FirstName = $"Member{i}",
                    LastName = $"Surname{i}",
                    BirthDate = new DateTime(2000 + i, 1, 1, 0,0,0, DateTimeKind.Utc),
                    Phone = $"6001001{i:D3}",
                    Email = $"member{i}@fishingclub.com",
                    JoinDate = new DateTime(2022, ((i - 1) % 12) + 1, 1, 0,0,0, DateTimeKind.Utc),
                    IsActive = i % 3 != 0,
                    LicenseValidUntil = new DateTime(2023, ((i - 1) % 12) + 1, 15, 0,0,0, DateTimeKind.Utc),
                    MembershipFeePaid = i % 2 == 0
                });
            }
            entity.HasData(memberSeeds.ToArray());
        });

        modelBuilder.Entity<FishingCompetition>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Location).HasMaxLength(200);
            entity.Property(e => e.CompetitionType).IsRequired().HasMaxLength(50);

            entity.HasData(
                new FishingCompetition { Id = 1, Name = "Spring Challenge",     Date = new DateTime(2024, 1, 15, 0,0,0, DateTimeKind.Utc),  Location = "Lake Nord", CompetitionType = "Club" },
                new FishingCompetition { Id = 2, Name = "Summer Derby",         Date = new DateTime(2024, 4, 10, 0,0,0, DateTimeKind.Utc),  Location = "River East", CompetitionType = "Open" },
                new FishingCompetition { Id = 3, Name = "Autumn Cup",           Date = new DateTime(2024, 7, 20, 0,0,0, DateTimeKind.Utc),  Location = "Bay West", CompetitionType = "Club" },
                new FishingCompetition { Id = 4, Name = "Winter Tournament",    Date = new DateTime(2024,10, 5, 0,0,0, DateTimeKind.Utc),  Location = "Lake South", CompetitionType = "Open" },
                new FishingCompetition { Id = 5, Name = "New Year Bash",       Date = new DateTime(2024,12,31, 0,0,0, DateTimeKind.Utc),  Location = "Lake Nord", CompetitionType = "Club" }
            );
        });

        modelBuilder.Entity<CompetitionResult>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        var compResults = new List<CompetitionResult>();
        for (int compId = 1; compId <= 5; compId++)
        {
            for (int place = 1; place <= 10; place++)
            {
                compResults.Add(new CompetitionResult
                {
                    Id = (compId - 1) * 10 + place,
                    CompetitionId = compId,
                    MemberId = place, 
                    FishType = (place % 2 == 0 ? "Carp" : "Pike"),
                    Weight = 1.0m + (place * 0.5m),
                    Place = place
                });
            }
        }
        modelBuilder.Entity<CompetitionResult>().HasData(compResults.ToArray());

        modelBuilder.Entity<FishingLog>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
        var logs = new List<FishingLog>();
        var locationsArr = new[] { "Lake Nord", "River East" };
        var fishTypes = new[] { "Bream", "Roach" };
        for (int i = 1; i <= 50; i++)
        {
            logs.Add(new FishingLog
            {
                Id = i,
                MemberId = ((i - 1) % 20) + 1,
                Date = new DateTime(2023, ((i - 1) % 12) + 1, ((i - 1) % 28) + 1, 0,0,0, DateTimeKind.Utc),
                Location = locationsArr[(i - 1) % locationsArr.Length],
                FishType = fishTypes[(i - 1) % fishTypes.Length],
                Weight = 0.5m + ((i % 5) * 0.25m)
            });
        }
        modelBuilder.Entity<FishingLog>().HasData(logs.ToArray());
    }
}
