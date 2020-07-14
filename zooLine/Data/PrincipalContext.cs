using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using zooLine.Models;

namespace zooLine.Data
{
    public class PrincipalContext : DbContext
    {
        public PrincipalContext (DbContextOptions<PrincipalContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet <Animales> Animal { get; set; }
    }
}
