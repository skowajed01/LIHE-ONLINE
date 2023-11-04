using LIHE.Data;
using LIHE.Migrations;
using Microsoft.AspNetCore.Mvc;
using LIHE.Models;
using Microsoft.EntityFrameworkCore;

namespace LIHE.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class MasterController : Controller
    {
        private readonly LIHEDBContext _dbcontext;
        public MasterController(LIHEDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        [Route("PostCountrymast")]
        public async Task<IActionResult> PostCountrymast(country cnt)
        {
            var countrylist = new country()
            {
                transid = Guid.NewGuid(),
                countryname = cnt.countryname,
                currency = cnt.currency,
                nationalityname = cnt.nationalityname,
                callingcode = cnt.callingcode,
                rco = "",
                rcm = DateTime.Now,
                luo = "",
                lum = null,
                sts = 0,
                delstatus = 0
            };
            var result = await _dbcontext.AddAsync(countrylist);
            // var result = await _dbContext.tblnew.AddAsync(aPICoreM);
            await _dbcontext.SaveChangesAsync();
            if (result != null)
            {
                return Ok("Successfull");
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetDetails")]
        public async Task<IActionResult> GetCountrymast() 
        {
            var countrylist = await _dbcontext.tbl_countrymast.Where(m=>m.delstatus == 0).OrderByDescending(m=>m.countryname).ToListAsync();
            return Ok(countrylist);
        }
       
    }
}
