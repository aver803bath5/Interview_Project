﻿using Interview_Project.Core.Domain;
using Interview_Project.Persistence.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Interview_Project.Persistence
{
    public partial class PubsContext : DbContext
    {
        public PubsContext()
        {
        }

        public PubsContext(DbContextOptions<PubsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<PubInfo> PubInfos { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Roysched> Royscheds { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Title> Titles { get; set; }
        public virtual DbSet<Titleauthor> Titleauthors { get; set; }
        public virtual DbSet<Titleview> Titleviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.ApplyConfiguration(new JobConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.AuId)
                    .HasName("UPKCL_auidind");

                entity.ToTable("authors");

                entity.HasIndex(e => new {e.AuLname, e.AuFname}, "aunmind");

                entity.Property(e => e.AuId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("au_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.AuFname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("au_fname");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("au_lname");

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Contract).HasColumnName("contract");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("phone")
                    .HasDefaultValueSql("('UNKNOWN')")
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("discounts");

                entity.Property(e => e.Discount1)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.Discounttype)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("discounttype");

                entity.Property(e => e.Highqty).HasColumnName("highqty");

                entity.Property(e => e.Lowqty).HasColumnName("lowqty");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.HasOne(d => d.Stor)
                    .WithMany()
                    .HasForeignKey(d => d.StorId)
                    .HasConstraintName("FK__discounts__stor___3C69FB99");
            });

            modelBuilder.Entity<PubInfo>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubinfo");

                entity.ToTable("pub_info");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Logo)
                    .HasColumnType("image")
                    .HasColumnName("logo");

                entity.Property(e => e.PrInfo)
                    .HasColumnType("text")
                    .HasColumnName("pr_info");

                entity.HasOne(d => d.Pub)
                    .WithOne(p => p.PubInfo)
                    .HasForeignKey<PubInfo>(d => d.PubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pub_info__pub_id__440B1D61");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasKey(e => e.PubId)
                    .HasName("UPKCL_pubind");

                entity.ToTable("publishers");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("country")
                    .HasDefaultValueSql("('USA')");

                entity.Property(e => e.PubName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("pub_name");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Roysched>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("roysched");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.Hirange).HasColumnName("hirange");

                entity.Property(e => e.Lorange).HasColumnName("lorange");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.TitleId)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.HasOne(d => d.Title)
                    .WithMany()
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__roysched__title___3A81B327");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasKey(e => new {e.StorId, e.OrdNum, e.TitleId})
                    .HasName("UPKCL_sales");

                entity.ToTable("sales");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.Property(e => e.OrdNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ord_num");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.OrdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ord_date");

                entity.Property(e => e.Payterms)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("payterms");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.HasOne(d => d.Stor)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__stor_id__37A5467C");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__sales__title_id__38996AB5");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StorId)
                    .HasName("UPK_storeid");

                entity.ToTable("stores");

                entity.Property(e => e.StorId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("stor_id")
                    .IsFixedLength(true);

                entity.Property(e => e.City)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state")
                    .IsFixedLength(true);

                entity.Property(e => e.StorAddress)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stor_address");

                entity.Property(e => e.StorName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("stor_name");

                entity.Property(e => e.Zip)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("zip")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Title>(entity =>
            {
                entity.ToTable("titles");

                entity.HasIndex(e => e.Title1, "titleind");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.Advance)
                    .HasColumnType("money")
                    .HasColumnName("advance");

                entity.Property(e => e.Notes)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("notes");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Pubdate)
                    .HasColumnType("datetime")
                    .HasColumnName("pubdate")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Royalty).HasColumnName("royalty");

                entity.Property(e => e.Title1)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .HasDefaultValueSql("('UNDECIDED')")
                    .IsFixedLength(true);

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");

                entity.HasOne(d => d.Pub)
                    .WithMany(p => p.Titles)
                    .HasForeignKey(d => d.PubId)
                    .HasConstraintName("FK__titles__pub_id__2E1BDC42");
            });

            modelBuilder.Entity<Titleauthor>(entity =>
            {
                entity.HasKey(e => new {e.AuId, e.TitleId})
                    .HasName("UPKCL_taind");

                entity.ToTable("titleauthor");

                entity.HasIndex(e => e.AuId, "auidind");

                entity.HasIndex(e => e.TitleId, "titleidind");

                entity.Property(e => e.AuId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("au_id");

                entity.Property(e => e.TitleId)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("title_id");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Royaltyper).HasColumnName("royaltyper");

                entity.HasOne(d => d.Au)
                    .WithMany(p => p.Titleauthors)
                    .HasForeignKey(d => d.AuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__au_id__31EC6D26");

                entity.HasOne(d => d.Title)
                    .WithMany(p => p.Titleauthors)
                    .HasForeignKey(d => d.TitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__titleauth__title__32E0915F");
            });

            modelBuilder.Entity<Titleview>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("titleview");

                entity.Property(e => e.AuLname)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("au_lname");

                entity.Property(e => e.AuOrd).HasColumnName("au_ord");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");

                entity.Property(e => e.PubId)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("pub_id")
                    .IsFixedLength(true);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}