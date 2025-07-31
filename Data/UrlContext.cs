using Microsoft.EntityFrameworkCore;
using URL_Shortener.Model.Url;

namespace URL_Shortener.Data
{
    public class UrlContext : DbContext
    {
        public UrlContext(DbContextOptions<UrlContext> options) : base(options){}

        public DbSet<Url> Urls { get; set; }
    }
}
