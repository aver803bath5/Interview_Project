using Interview_Project.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Interview_Project.Persistence.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.EmpId)
                .HasName("PK_emp_id")
                .IsClustered(false);

            builder.ToTable("employees");

            builder.HasIndex(e => new {e.Lname, e.Fname, e.Minit}, "employees_ind")
                .IsClustered();

            builder.Property(e => e.EmpId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("emp_id")
                .IsFixedLength(true);

            builder.Property(e => e.Fname)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fname");

            builder.Property(e => e.HireDate)
                .HasColumnType("datetime")
                .HasColumnName("hire_date")
                .HasDefaultValueSql("(getdate())");

            builder.Property(e => e.JobId)
                .HasColumnName("job_id")
                .HasDefaultValueSql("((1))");

            builder.Property(e => e.JobLvl)
                .HasColumnName("job_lvl")
                .HasDefaultValueSql("((10))");

            builder.Property(e => e.Lname)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lname");

            builder.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("minit")
                .IsFixedLength(true);

            builder.Property(e => e.PubId)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("pub_id")
                .HasDefaultValueSql("('9952')")
                .IsFixedLength(true);

            builder.HasOne(d => d.Job)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__job_id__48CFD27E");

            builder.HasOne(d => d.Pub)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.PubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__employees__pub_id__4BAC3F29");
        }
    }
}