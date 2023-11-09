using LIHE.Data;
using LIHE.Models.Domain;
using LIHE.Repositories.IRepositoty;
using Microsoft.EntityFrameworkCore;

namespace LIHE.Repositories
{
	public class CountryMastRepository : ICountryMastRepository
	{
		private readonly LIHEDbContext _dbContext;

		public CountryMastRepository(LIHEDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<Country> CreateAsync(Country country)
		{
			await _dbContext.tbl_countrymast.AddAsync(country);
			await _dbContext.SaveChangesAsync();
			return country;
		}

		public async Task<Country?> DeleteAsync(Guid id)
		{
			var country = await _dbContext.tbl_countrymast.FirstOrDefaultAsync(m => m.transid == id);
			if (country == null)
			{
				return null;
			}
			_dbContext.tbl_countrymast.Remove(country);
			await _dbContext.SaveChangesAsync();
			return country;

		}

		public async Task<List<Country>> GetAllAsync()
		{


			var countryList = await _dbContext.tbl_countrymast.Where(m => m.delstatus == 0).OrderByDescending(m => m.countryname).ToListAsync();
			return countryList;
		}

		public async Task<Country?> GetByIdAsync(Guid id)
		{
			var country = await _dbContext.tbl_countrymast.FirstOrDefaultAsync(m => m.transid == id);
			return country;
		}

		public async Task<Country?> UpdateAsync(Guid id, Country country)
		{
			var existingCountry = await _dbContext.tbl_countrymast.FirstOrDefaultAsync(x => x.transid == id);

			if (existingCountry == null)
			{
				return null;
			}
			existingCountry.countryname = country.countryname;
			existingCountry.currency = country.currency;
			existingCountry.nationalityname = country.nationalityname;
			existingCountry.lum = DateTime.Now;
			existingCountry.callingcode = country.callingcode;

			await _dbContext.SaveChangesAsync();
			return existingCountry;
		}
	}
}
