using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using saborna_crkva_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace saborna_crkva_API.EF
{
    public class MyContext : IdentityDbContext<User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public MyContext(DbContextOptions<MyContext> x) : base(x)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }

        public DbSet<Message> Message { get; set; }
        public DbSet<Conversation> Conversation { get; set; }
        public DbSet<Novosti> Novosti { get; set; }
        public DbSet<NovostiSlike> NovostiSlike { get; set; }
        public DbSet<Obavjestenja> Obavjestenja { get; set; }
        public DbSet<ObavjestenjaKategorije> ObavjestenjaKategorije { get; set; }
        public DbSet<ObavjestenjaSlike> ObavjestenjaSlike { get; set; }
        public DbSet<ObavjestenjaKategorijeObavjestenja> ObavjestenjaKategorijeObavjestenja { get; set; }
        public DbSet<Donacije> Donacije { get; set; }
    }
}
