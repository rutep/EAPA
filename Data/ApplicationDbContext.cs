using System;
using BoardMemberEntity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

// Database starter
namespace webApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<MyUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

            // 

        }
        public DbSet<Event.Data.Event> Event { get; set; }

        public DbSet<Grant.Data.Grant> Grant { get; set; }
       
        public DbSet<Vote.Data.Vote> Vote { get; set; }
        public DbSet<FAQ.Data.FAQ> Faq { get; set; }
        public DbSet<BoardMemberEntity.Data.BoardMember> BoardMember { get; set; }

        
    }
}
