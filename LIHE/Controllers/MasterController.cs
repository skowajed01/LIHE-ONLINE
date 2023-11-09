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

        [HttpGet]
        [Route("GetCountrymast")]
        public async Task<IActionResult> GetCountrymast(Guid Id)
        {
            country model = new country();

            var tbl_countrymast = _dbcontext.tbl_countrymast.Where(m => m.transid == Id).FirstOrDefault();

            if (tbl_countrymast != null)
            {
                model.transid = tbl_countrymast.transid;
                model.countryname = tbl_countrymast.countryname;
                model.currency = tbl_countrymast.currency;
                model.nationalityname = tbl_countrymast.nationalityname;
                model.callingcode = tbl_countrymast.callingcode;
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("PostCountrymastUpdate")]
        public async Task<IActionResult> PostCountrymastUpdate(country model)
        {
            var tbl = _dbcontext.tbl_countrymast.Where(m => m.transid == model.transid).FirstOrDefault();
           
            if (tbl != null)
            {
                tbl.countryname = model.countryname;
                tbl.currency = model.currency;
                tbl.nationalityname = model.nationalityname;
                tbl.callingcode = model.callingcode;
                tbl.luo = "";
                tbl.lum = DateTime.Now;
                _dbcontext.tbl_countrymast.Update(tbl);
                _dbcontext.SaveChanges();
            }

            return Ok(tbl);
        }

        [HttpGet]
        [Route("DeleteCountrymast")]
        public async Task<IActionResult> DeleteCountrymast(Guid Id)
        {

            var tbl = _dbcontext.tbl_countrymast.Where(m => m.transid == Id).FirstOrDefault();

            if (tbl != null)
            {
                tbl.delstatus = 1;
                _dbcontext.tbl_countrymast.Update(tbl);
                _dbcontext.SaveChanges();
            }

            return Ok(tbl);
        }

    }
}
