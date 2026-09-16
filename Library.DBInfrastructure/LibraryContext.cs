using Library.BackendData.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Library.DBInfrastructure.Data
{
    public class LibraryContext : DbContext
    {
        // 1. Tabelele noastre
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        // 2. "Ușa deschisă". 
        // Acest constructor permite proiectului API să îi trimită conexiunea 
        // de-a gata, fără ca DBInfrastructure să facă vreo muncă în plus.
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
    }
}