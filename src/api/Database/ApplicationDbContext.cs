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
        builder.Entity<ChoreTemplate>();
        builder.Entity<Person>()
            .HasMany<ChoreTemplate>()
            .WithOne(e => e.Person)
            .IsRequired(false);
        builder.Entity<Person>()
            .HasData([
                new Person { Id = Guid.NewGuid(), Name = "Elijah" },
                    new Person { Id = Guid.NewGuid(), Name = "Abigail" }
            ]);


        base.OnModelCreating(builder);
    }

}