using LIHE.Models.Domain;

namespace LIHE.Repositories.IRepositoty
{
    public interface IDepartmentmastRepository
    {
        Task<department> CreateAsync(department department);
        Task<List<department>> GetAllAsync();
        Task<department?> GetByIdAsync(Guid id);
        Task<department?> UpdateAsync(Guid id, department department);
        Task<department?> DeleteAsync(Guid id);
    }
}
