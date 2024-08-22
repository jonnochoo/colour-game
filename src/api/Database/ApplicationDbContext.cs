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
                new Person { Id = PersonIds.Elijah, Name = "Elijah" },
                new Person { Id = PersonIds.Abigail, Name = "Abigail" }
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
                PersonId = PersonIds.Elijah,
                Summary = "Brush Teeth",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning, TimeOfDay.Evening]
            });
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = PersonIds.Elijah,
                Summary = "Get changed out of PJs",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning]
            });

        this.AddRegularChores(builder, PersonIds.Elijah);
        this.AddRegularChores(builder, PersonIds.Abigail);
    }

    private void AddRegularChores(ModelBuilder builder, int personId)
    {

        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Brush Teeth",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning, TimeOfDay.Evening]
            });
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Turn off lights, fans and open blinds",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning]
            });
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Get changed out of PJs",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning]
            });
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Eat breakfast",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning]
            });
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Put breakfast dishes away in dishwasher",
                DaysOfWeek = DayOfWeeks.AllDays,
                TimeOfDays = [TimeOfDay.Morning]
            });

        // School day chores
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Find hat, jacket, socks and shoes",
                DaysOfWeek = DayOfWeeks.WeekDays,
                TimeOfDays = [TimeOfDay.Morning]
            });
        builder.Entity<ChoreTemplate>()
            .HasData(new ChoreTemplate
            {
                PersonId = personId,
                Summary = "Pack school bag",
                DaysOfWeek = DayOfWeeks.WeekDays,
                TimeOfDays = [TimeOfDay.Morning]
            });
    }
}
