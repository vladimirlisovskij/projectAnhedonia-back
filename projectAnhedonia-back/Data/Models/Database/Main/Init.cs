using Microsoft.EntityFrameworkCore;
using projectAnhedonia_back.Data.Common;
using projectAnhedonia_back.Data.Entities.Dto;
using projectAnhedonia_back.Data.Entities.Dto.Database;

namespace projectAnhedonia_back.Data.Models.Database.Main
{
    public partial class MainDatabaseContext : DbContext
    {
        public MainDatabaseContext()
        {
        }

        public MainDatabaseContext(DbContextOptions<MainDatabaseContext> options)
            : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data source={Constants.MainDatabasePath}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coauthor>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.UserId });

                entity.HasIndex(e => new { e.PostId, e.UserId }, "Coauthors_Index")
                    .IsUnique();

                entity.HasOne(d => d.Article)
                    .WithMany(p => p.Coauthors)
                    .HasForeignKey(d => d.PostId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CoauthorsRecords)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Comments_Id")
                    .IsUnique();

                entity.HasIndex(e => e.AuthorId, "Comments_AuthorId");

                entity.HasIndex(e => e.Id, "Comments_Id")
                    .IsUnique();

                entity.HasIndex(e => e.PostId, "Comments_PostId");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.CreationDateTime)
                    .IsRequired()
                    .HasColumnType("DATETIME");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Images_Id")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Images_Id")
                    .IsUnique();

                entity.Property(e => e.FilePath)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("VARCHAR");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.Id, "Posts_Id")
                    .IsUnique();

                entity.HasIndex(e => e.Title, "Posts_Title");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.CreationDateTime)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("VARCHAR");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.PreviewImage)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PreviewImageId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Id, "IX_Users_Id")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "IX_Users_Username")
                    .IsUnique();

                entity.HasIndex(e => e.Id, "Users_Id")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "Users_Username")
                    .IsUnique();

                entity.Property(e => e.About)
                    .IsRequired()
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("VARCHAR (30)");

                entity.Property(e => e.RegistrationDate)
                    .IsRequired()
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("\"\"");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("VARCHAR (20)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}