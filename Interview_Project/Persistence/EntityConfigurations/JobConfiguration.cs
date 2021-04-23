using Interview_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview_Project.Persistence.EntityConfigurations
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
                builder.ToTable("jobs");

                builder.Property(e => e.JobId).HasColumnName("job_id");

                builder.Property(e => e.JobDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("job_desc")
                    .HasDefaultValueSql("('New Position - title not formalized yet')");

                builder.Property(e => e.MaxLvl).HasColumnName("max_lvl");

                builder.Property(e => e.MinLvl).HasColumnName("min_lvl");
        }
    }
}