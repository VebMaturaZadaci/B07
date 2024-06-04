using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace B7.Data
{
    public class BibliotekaDBContext : IdentityDbContext
    {
        public BibliotekaDBContext(DbContextOptions<BibliotekaDBContext> options)
        : base(options)
        {
        }
    }
}
