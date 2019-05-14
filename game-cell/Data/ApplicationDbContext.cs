using System;
using System.Collections.Generic;
using System.Text;
using game_cell.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace game_cell.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Platforms> Platformss { get; set; }
        public DbSet<GAME> GAMEs { get; set; }
    }
}
