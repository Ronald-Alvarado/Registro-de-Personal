using Microsoft.EntityFrameworkCore;
using Registro_del_Personal.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro_del_Personal.DAL
{
    public class Context : DbContext
    {
        public DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = DESKTOP-RLIPRAX\SQLEXPRESS; Database = PersonasDb; Trusted_Connection = true");
        }
    }
}
