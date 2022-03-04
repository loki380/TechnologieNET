using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoccerLeague.Models;

namespace SoccerLeague.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(b => b.Players)
                .HasForeignKey(p => p.TeamID);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Team>()
                .HasOne(p => p.League)
                .WithMany(b => b.Teams)
                .HasForeignKey(p => p.LeagueID);
        }
        public DbSet<SoccerLeague.Models.Player> Player { get; set; }
        public DbSet<SoccerLeague.Models.League> League { get; set; }
        public DbSet<SoccerLeague.Models.Team> Team { get; set; }
    }
}
