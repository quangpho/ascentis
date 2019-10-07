using System;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class MemberDbContext:DbContext
    {
        public MemberDbContext(DbContextOptions<MemberDbContext> options):base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
    }
}
