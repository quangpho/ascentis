using Ascentis.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace Ascentis.DAL.Context
{
    public class MemberDbContext : DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options) : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
