
using EAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt)
            : base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }

        public DbSet<CreateCinemaDTO> Cinemas { get; set; }
    }
}
