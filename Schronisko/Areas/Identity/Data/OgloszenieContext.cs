using Microsoft.EntityFrameworkCore;
using Schronisko.Models;

namespace Schronisko.Areas.Identity.Data
{
    public class SchroniskoContext: DbContext
    {
        public SchroniskoContext(DbContextOptions options) : base(options) { }
        public DbSet<Ogloszenie> Ogloszenie { get; set; }
        public DbSet<Zaginiecia> Zaginiecia { get; set; }

        public DbSet<Wiadomosci> Wiadomosci { get; set; }
       
    }
}
