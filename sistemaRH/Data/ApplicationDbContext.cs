using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sistemaRH.Models;

namespace sistemaRH.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Setor> Setor { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Colaborador> Colaborador { get; set; }
    }
}
