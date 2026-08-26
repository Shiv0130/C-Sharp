/* My Code
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc_BloggingPlatform.Models;

namespace mvc_BloggingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BlogPost>()
                .HasOne(b => b.Author)
                .WithMany(a => a.BlogPost)
                .HasForeignKey(b => b.Author)
                .OnDelete(DeleteBehavior.Restrict);

        }
        //Why is BlogPost the dependent entity? Because BlogPost has the foreign key (AuthorId) that references the primary key of Author. In a one-to-many relationship, the entity that contains the foreign key is considered the dependent entity, while the entity that is referenced by the foreign key is considered the principal entity.

    }
}*/

// Corrected Code
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc_BloggingPlatform.Models;

namespace mvc_BloggingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BlogPost>()
                .HasOne(b => b.Author)
                .WithMany(a => a.BlogPosts)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
