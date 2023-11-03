using LIHE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LIHE.Data
{
    public class LIHEDBContext : IdentityDbContext
    {
        public LIHEDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<country> tbl_countrymast { get; set; }
    }
}
