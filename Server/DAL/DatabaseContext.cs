using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.DAL.Entity;
using Server.DTO;

namespace Server.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }


        // DbSet properties represent database tables
        public virtual DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<BetResult> BetResults { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}