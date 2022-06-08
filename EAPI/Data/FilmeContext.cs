
using EAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EAPI.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt)
            : base(opt)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
