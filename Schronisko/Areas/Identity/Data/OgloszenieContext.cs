using Microsoft.EntityFrameworkCore;
using Schronisko.Models;

namespace Schronisko.Areas.Identity.Data
{
    public class OgloszenieContext: DbContext
    {
        public OgloszenieContext(DbContextOptions options) : base(options) { }
        public DbSet<Ogloszenie> Ogloszenie { get; set; }
        
    }
}
