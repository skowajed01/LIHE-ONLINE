using LIHE.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LIHE.Data
{
	public class LIHEDbContext : IdentityDbContext
	{
		public LIHEDbContext(DbContextOptions<LIHEDbContext> options) : base(options)
		{

		}
		public DbSet<Country> tbl_countrymast { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
