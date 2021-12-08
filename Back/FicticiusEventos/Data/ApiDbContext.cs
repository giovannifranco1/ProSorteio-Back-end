using FicticiusEventos.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProSorteio.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Models;
using TodoApp.Models.DTOs.Requests;

namespace TodoApp.Data
{
  public class ApiDbContext : IdentityDbContext
  {
        public DbSet<Category> Category { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<Phone> Phone { get; set; }
        public DbSet<Sweepstake> Sweepstakes { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<PeopleSweepstake> PeopleSweepstakes { get; set; }
        public DbSet<SweepstakeProduct> SweepstakeProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      string ADMIN_ID = "02174cf0�9412�4cfe - afbf - 59f706d72cf6";
      string ROLE_ID = "341743f0 - asd2�42de - afbf - 59kmkkmk72cf6";

      //seed admin role
      modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
      {
        Name = "SuperAdmin",
        NormalizedName = "SuperAdmin",
        Id = ROLE_ID,
        ConcurrencyStamp = ROLE_ID
      });

      //create user
      var appUser = new IdentityUser
      {
        Id = ADMIN_ID,
        Email = "admin@gmail.com",
        EmailConfirmed = true,
        UserName = "Admin"
      };

      //set user password
      PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
      appUser.PasswordHash = ph.HashPassword(appUser, "$Admin1234");

      //seed user
      modelBuilder.Entity<IdentityUser>().HasData(appUser);

      //set user role to admin
      modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
      {
        RoleId = ROLE_ID,
        UserId = ADMIN_ID
      });
            modelBuilder.Entity<People>()
                .HasIndex(u => u.Cpf)
                .IsUnique();

            modelBuilder.Entity<People>()
                 .HasOne(b => b.Member)
                 .WithOne(p => p.People)
                 .HasForeignKey<Member>(m => m.PeopleId);

            modelBuilder.Entity<Product>()
                 .HasOne(b => b.Category)
                 .WithMany(g => g.Products)
                 .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<PeopleSweepstake>()
               .HasOne(ps => ps.People)
               .WithMany(p => p.PeopleSweepstakes)
               .HasForeignKey(ps => ps.PeopleId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SweepstakeProduct>()
                .HasOne(sp => sp.Sweepstake)
                .WithMany(s => s.SweepstakeProducts)
                .HasForeignKey(ps => ps.SweepstakeId);



            modelBuilder.Entity<SweepstakeProduct>()
               .HasOne(sp => sp.Product)
               .WithMany(p => p.SweepstakeProducts)
               .HasForeignKey(ps => ps.ProductId);
               
    }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,CancellationToken token = default)
        {
            foreach (var entity in ChangeTracker
                .Entries()
                .Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .Cast<BaseEntity>())
            {
                entity.UpdatedDate = DateTime.Now;
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, token);
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ProSorteio.Models.Member> Member { get; set; }

  }
}