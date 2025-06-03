using Microsoft.EntityFrameworkCore;
using _378daftarkhoneh.Models;

namespace _378daftarkhoneh.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FileUpload> FileUploads { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User configurations
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(255);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            });

            // UserFile configurations
            modelBuilder.Entity<UserFile>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.ProcessedByUser)
                    .WithMany()
                    .HasForeignKey(d => d.ProcessedByUserId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Seed initial admin user
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Username = "admin",
                    Password = "admin123", // در محیط واقعی باید هش شود
                    FirstName = "مدیر",
                    LastName = "سیستم",
                    Email = "admin@notary378.ir",
                    Role = UserRole.SuperAdmin,
                    IsActive = true,
                    CreatedAt = DateTime.Now
                }
            );

            // Seed initial categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "اسناد املاک", Description = "خرید، فروش، اجاره املاک", Color = "#3498db", Icon = "fas fa-home" },
                new Category { Id = 2, Name = "وکالتنامه", Description = "انواع وکالتنامه‌ها", Color = "#e74c3c", Icon = "fas fa-gavel" },
                new Category { Id = 3, Name = "اقرارنامه", Description = "انواع اقرارنامه‌ها", Color = "#27ae60", Icon = "fas fa-file-signature" },
                new Category { Id = 4, Name = "ازدواج و طلاق", Description = "شروط ضمن عقد، طلاق", Color = "#f39c12", Icon = "fas fa-ring" },
                new Category { Id = 5, Name = "گواهی و استعلام", Description = "گواهی امضا، استعلام", Color = "#9b59b6", Icon = "fas fa-certificate" }
            );
        }
    }
} 