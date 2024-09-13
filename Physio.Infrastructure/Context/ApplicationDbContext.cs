using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Physio.Domain.Models;

namespace Physio.Infrastructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Physiotherapist> Physiotherapists { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany(c => c.Appointments)
                .HasForeignKey(a => a.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Appointment>()
                .HasOne(a => a.Physiotherapist)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PhysiotherapistId);

            builder.Entity<Video>()
                .HasOne(v => v.Physiotherapist)
                .WithMany(f => f.Videos)
                .HasForeignKey(v => v.PhysiotherapistId);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Client",
                    NormalizedName = "CLIENT"
                },
                new IdentityRole
                {
                    Name = "Physiotherapist",
                    NormalizedName = "PHYSIOTHERAPIST"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
