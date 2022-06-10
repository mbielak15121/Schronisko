using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schronisko.Areas.Identity.Data;

namespace Schronisko.Data;

public class SchroniskoContext : IdentityDbContext<SchroniskoUsers>
{
    public SchroniskoContext(DbContextOptions<SchroniskoContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<SchroniskoUsers>
{
    void IEntityTypeConfiguration<SchroniskoUsers>.Configure(EntityTypeBuilder<SchroniskoUsers> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
        builder.Property(u => u.IsAdmin).HasDefaultValue(false);
       
    }
}