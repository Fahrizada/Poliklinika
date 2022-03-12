using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Model;

namespace PoliklinikaAPI.Data
{
    public partial class DBContext : IdentityDbContext<User, Role, int>
    {

        public DbSet<Odjel> Odjel { get; set; }
        public DbSet<Obaveza> Obaveza { get; set; }
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Izvjestaj> Izvjestaj { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Nalaz> Nalaz { get; set; }
        public DbSet<Osoblje> Osoblje { get; set; }
        public DbSet<Pregled> Pregled { get; set; }
        public DbSet<Raspored> Raspored { get; set; }
        public DbSet<Tehnicar> Tehnicar { get; set; }
        public DbSet<Uplata> Uplata { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<ChatObaveza> ChatObaveza { get; set; }
        public DbSet<ChatPoruka> ChatPoruka { get; set; }
        public DbSet<Konsultacije> Konsultacije { get; set; }
        public DbSet<KonsultacijePoruka> KonsultacijePoruka { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
