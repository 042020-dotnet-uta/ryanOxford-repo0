using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RockPaperScissor
{
    class RPS_DbContext: DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Player> Players { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=ESTE; Database=RPS; Trusted_connection = true;");

        }
    }
}
