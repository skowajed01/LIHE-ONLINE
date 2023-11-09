using LIHE.Models.Domain;

namespace LIHE.Repositories.IRepositoty
{
	public interface ICountryMastRepository
	{
		Task<Country> CreateAsync(Country country);
		Task<List<Country>> GetAllAsync();
		Task<Country?> GetByIdAsync(Guid id);
		Task<Country?> UpdateAsync(Guid id, Country country);
		Task<Country?> DeleteAsync(Guid id);
	}
}
