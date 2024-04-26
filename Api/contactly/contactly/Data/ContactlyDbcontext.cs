using contactly.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace contactly.Data
{
    public class ContactlyDbcontext : DbContext
    {
        public ContactlyDbcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; }
    }
}
