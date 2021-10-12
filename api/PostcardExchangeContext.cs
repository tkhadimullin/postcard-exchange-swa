using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api {
    public class PostcardExchangeContext: DbContext {
        public PostcardExchangeContext(DbContextOptions<PostcardExchangeContext> options)
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Postcard> Postcards { get; set; }
    }
}