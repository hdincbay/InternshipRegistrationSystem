using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<User, Role, int>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Status> Status { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUserRole<int>>()
               .HasOne<User>()
               .WithMany()
               .HasForeignKey(ur => ur.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<IdentityUserRole<int>>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Entity<User>()
                .HasOne(u => u.Professor)
                .WithMany() // Professor'da ICollection<User> yoksa boş bırakılır
                .HasForeignKey(u => u.ProfessorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);  // Burada cascade delete kapandı
            builder.Entity<RegistrationForm>(entity =>
            {
                // Candidate one-to-one
                entity.HasOne(r => r.Candidate)
                    .WithOne()
                    .HasForeignKey<RegistrationForm>(r => r.CandidateId)
                    .OnDelete(DeleteBehavior.Restrict);

                // ResearchAssistant one-to-one
                entity.HasOne(r => r.ResearchAssistant)
                    .WithOne()
                    .HasForeignKey<RegistrationForm>(r => r.ResearchAssistantId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Professor one-to-one
                entity.HasOne(r => r.Professor)
                    .WithOne()
                    .HasForeignKey<RegistrationForm>(r => r.ProfessorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            builder.Entity<Status>().HasData(
                new Status() { StatusId = 1, Name = "Değerlendirme Aşamasında" },
                new Status() { StatusId = 2, Name = "Reddedildi" },
                new Status() { StatusId = 3, Name = "Yönetici Onayı Bekliyor" },
                new Status() { StatusId = 4, Name = "Onaylandı" }
            );

            builder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, Name = "Web Programcılığı" },
                new Category() { CategoryId = 2, Name = "Siber Güvenlik" },
                new Category() { CategoryId = 3, Name = "Gömülü Sistemler" }
            );

            builder.Entity<Role>().HasData(
                new Role() { Id = 1, Name = "Profesör", NormalizedName = "PROFESÖR" },
                new Role() { Id = 2, Name = "Araştırma Görevlisi", NormalizedName = "ARAŞTIRMA GÖREVLİSİ" },
                new Role() { Id = 3, Name = "Stajyer Adayı", NormalizedName = "STAJYER ADAYI" },
                new Role() { Id = 4, Name = "Stajyer", NormalizedName = "STAJYER" }
            );
        }

    }
}
