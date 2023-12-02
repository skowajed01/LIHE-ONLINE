using LIHE.Data;
using LIHE.Models.Domain;
using LIHE.Repositories.IRepositoty;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace LIHE.Repositories
{
    public class DepartmentMastRepository : IDepartmentmastRepository
    {
        private readonly LIHEDbContext _dbContext;
        public DepartmentMastRepository(LIHEDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<department> CreateAsync(department department)
        {
            await _dbContext.tbldeptmast.AddAsync(department);
            await _dbContext.SaveChangesAsync();
            return department;
        }

        public async Task<department?> DeleteAsync(Guid id)
        {
            var dept = await _dbContext.tbldeptmast.FirstOrDefaultAsync(m => m.transid == id);
            if (dept == null)
            {
                return null;
            }
           // dept.delstatus = 0;
            _dbContext.tbldeptmast.Remove(dept);
            //_dbContext.SaveChanges();
            await _dbContext.SaveChangesAsync();
            return dept;
        }

        public async Task<List<department>> GetAllAsync()
        {
            var deptList = await _dbContext.tbldeptmast.Where(m => m.delstatus == 0).OrderByDescending(m => m.deptname).ToListAsync();
            return deptList;
        }

        public async Task<department?> GetByIdAsync(Guid id)
        {
            var dept = await _dbContext.tbldeptmast.FirstOrDefaultAsync(m => m.transid == id);
            return dept;
        }

        public async Task<department?> UpdateAsync(Guid id, department department)
        {
            var existingDepartment = await _dbContext.tbldeptmast.FirstOrDefaultAsync(x => x.transid == id);

            if (existingDepartment == null)
            {
                return null;
            }
            existingDepartment.deptname = department.deptname;
            existingDepartment.deptsname = department.deptsname;
            existingDepartment.jobtype = department.jobtype;
            existingDepartment.lum = DateTime.Now;
           
            await _dbContext.SaveChangesAsync();
            return existingDepartment;
        }
    }
}
