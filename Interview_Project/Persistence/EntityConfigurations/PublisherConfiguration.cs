using Interview_Project.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview_Project.Persistence.EntityConfigurations
{
    public class PublisherConfiguration : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> builder)
        {
            builder.HasKey(e => e.PubId)
                .HasName("UPKCL_pubind");

            builder.ToTable("publishers");

            builder.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("pub_id")
                .IsFixedLength(true);

            builder.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");

            builder.Property(e => e.Country)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("country");

            builder.Property(e => e.PubName)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pub_name");

            builder.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("state")
                .IsFixedLength(true);
        }
    }
}