using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace News.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<Subsection> Subsections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
/*#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
*/                optionsBuilder.UseSqlServer("Server=.;Database=News.2;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "44546e06-8719-4ad8-b88a-f271ae9d6eab",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "3b62472e-4f66-49fa-a20f-e7685b9565d8",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(e => e.IdArticle);

                entity.ToTable("Article");

                entity.Property(e => e.IdArticle)
                    .ValueGeneratedNever()
                    .HasColumnName("id_article");

                entity.Property(e => e.AddTime)
                    .HasColumnType("datetime")
                    .HasColumnName("add_time");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdSubsectionNews).HasColumnName("id_subsection_news");

                entity.Property(e => e.ImageArticle)
                    .HasColumnType("image")
                    .HasColumnName("image_article");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("short_description");

                entity.Property(e => e.Text).IsUnicode(false);

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdAuthor)
                    .HasConstraintName("FK_Article_Author");

                entity.HasOne(d => d.IdSubsectionNewsNavigation)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.IdSubsectionNews)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_News_Name");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor);

                entity.ToTable("Author");

                entity.Property(e => e.IdAuthor)
                    .ValueGeneratedNever()
                    .HasColumnName("id_author");

                entity.Property(e => e.Document)
                    .IsRequired()
                    .HasColumnName("document");

                entity.Property(e => e.IdSection).HasColumnName("id_section");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Authors)
                    .HasForeignKey(d => d.IdSection)
                    .HasConstraintName("FK_Author_Section");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.IdSection);

                entity.ToTable("Section");

                entity.Property(e => e.IdSection)
                    .ValueGeneratedNever()
                    .HasColumnName("id_section");

                entity.Property(e => e.NameSection)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("name_section");
            });

            modelBuilder.Entity<Subsection>(entity =>
            {
                entity.HasKey(e => e.IdSubsectionNews)
                    .HasName("PK_News_Name");

                entity.ToTable("Subsection");

                entity.Property(e => e.IdSubsectionNews)
                    .ValueGeneratedNever()
                    .HasColumnName("id_subsection_news");

                entity.Property(e => e.IdSection).HasColumnName("id_section");

                entity.Property(e => e.MetaDescription).IsUnicode(false);

                entity.Property(e => e.MetaKeywords).IsUnicode(false);

                entity.Property(e => e.MetaTitle).IsUnicode(false);

                entity.Property(e => e.NameSubsection)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("name_subsection");

                entity.HasOne(d => d.IdSectionNavigation)
                    .WithMany(p => p.Subsections)
                    .HasForeignKey(d => d.IdSection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subsection_Section");
            });

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
