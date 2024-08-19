using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public DbSet<ChoreTemplate> ChoreTemplates { get; set; }
    public DbSet<Person> People { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Person
        builder.Entity<Person>()
            .HasKey(x => x.Id);
        builder.Entity<Person>()
            .HasMany<ChoreTemplate>()
            .WithOne(e => e.Person)
            .IsRequired(false);
        builder.Entity<Person>()
            .HasData([
                new Person { Id = 1, Name = "Elijah" },
                new Person { Id = 2, Name = "Abigail" }
            ]);

        // Chore Template
        builder.Entity<ChoreTemplate>();
        builder.Entity<ChoreTemplate>()
            .HasKey(x => x.Id);
        builder.Entity<ChoreTemplate>()
            .Property(x => x.Summary)
            .IsRequired();

        // Elijah
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = 1,
                Summary = "Brush Teeth",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning, TimeOfDay.Evening]
            });

        // Abigail
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = 2,
                Summary = "Brush Teeth",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning, TimeOfDay.Evening]
            });
    }
}
