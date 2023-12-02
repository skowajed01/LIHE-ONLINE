using LIHE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIHE.Models.Domain;
using LIHE.Models;
using System.Net;

using LIHE.Models.DTO;
using AutoMapper;
using LIHE.Repositories.IRepositoty;


namespace LIHE.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class MasterController : Controller
	{

		protected APIResponse _response;

		private readonly IMapper mapper;
		private readonly ICountryMastRepository countryMastRepository;
		private readonly IDepartmentmastRepository departmentmastRepository;

		public MasterController(IMapper mapper, ICountryMastRepository countryMastRepository,IDepartmentmastRepository departmentmastRepository)
		{

			_response = new();

			this.mapper = mapper;
			this.countryMastRepository = countryMastRepository;
			this.departmentmastRepository = departmentmastRepository;
		}

        [HttpPost]
        [Route("Department")]
        public async Task<IActionResult> Departmentmaster([FromBody] DepartmentRequestDto dept)
        {
            if (ModelState.IsValid)
            {
				department department = new department()
				{
					transid = Guid.NewGuid(),
					deptname = dept.deptname,
					deptsname = dept.deptsname,
					jobtype = dept.jobtype,
					rco = "",
					rcm = DateTime.Now,
					luo = "",
					lum = null,
					visblsts = "0",
					delstatus = 0,
					slno = 0,
					serial_no = 0,
					ImageLocation = "",
					department_email = "",
					dept_cname = "",
					e_mail ="",
                    orign_id = "",
					webdeptname = "",
					status = "",
                };

                var result = await departmentmastRepository.CreateAsync(department);

                if (result != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Result = mapper.Map<DepartmentRequestDto>(result);

                    return Ok(_response);
                }
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Result = _response;
                return BadRequest(result);
            }
            _response.StatusCode = HttpStatusCode.BadRequest;
            _response.IsSuccess = false;
            _response.Result = "Validation Error";
            return BadRequest(_response);
        }

        [HttpGet]
        [Route("GetDepartmentDetails")]
        public async Task<IActionResult> GetDeptmast()
        {
            var deptlist = await departmentmastRepository.GetAllAsync();

            if (deptlist != null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = mapper.Map<List<DepartmentRequestDto>>(deptlist);

                return Ok(_response);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("GetDepartment/{id}")]
        public async Task<IActionResult> GetDepartmentById([FromRoute] Guid id)
        {
            var dept = await departmentmastRepository.GetByIdAsync(id);
            if (dept == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                _response.Result = "Wrong Details";
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = mapper.Map<DepartmentRequestDto>(dept);
            return Ok(_response);
        }

        [HttpPost]
        [Route("UpdateDepartmentmast/{id}")]
        public async Task<IActionResult> UpdateDepartment([FromRoute] Guid id, [FromBody] DepartmentRequestDto dept)
        {
            var deptDomainModel = mapper.Map<department>(dept);
            var existingDepartment = await departmentmastRepository.UpdateAsync(id, deptDomainModel);

            if (existingDepartment == null)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = true;
                _response.Result = "Wrong Details";
                return BadRequest(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = mapper.Map<DepartmentRequestDto>(existingDepartment);
            return Ok(_response);
        }

        [HttpDelete]
        [Route("DeleteDepartmentmast/{id}")]
        public async Task<IActionResult> DeleteDepartmentmast([FromRoute] Guid id)
        {
            var dept = await departmentmastRepository.DeleteAsync(id);
            if (dept != null)
            {

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Result = mapper.Map<DepartmentRequestDto>(dept)!;
                return Ok(_response);
            }
            _response.StatusCode = HttpStatusCode.NotFound;
            _response.IsSuccess = false;
            _response.Result = "No Data Found";
            return NotFound(_response);
        }


        [HttpPost]
		[Route("Countrymast")]
		public async Task<IActionResult> Countrymast([FromBody] AddCountryRequestDto cnt)
		{
			if (ModelState.IsValid)
			{
				Country country = new Country()
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

				//var result = await _dbcontext.tbl_countrymast.AddAsync(country);

				//// var result = await _dbContext.tblnew.AddAsync(aPICoreM);
				//await _dbcontext.SaveChangesAsync();
				var result = await countryMastRepository.CreateAsync(country);

				if (result != null)
				{
					_response.StatusCode = HttpStatusCode.OK;
					_response.IsSuccess = true;
					_response.Result = mapper.Map<AddCountryResponseDto>(result);

					return Ok(_response);
				}
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = false;
				_response.Result = _response;
				return BadRequest(result);
			}
			_response.StatusCode = HttpStatusCode.BadRequest;
			_response.IsSuccess = false;
			_response.Result = "Validation Error";
			return BadRequest(_response);
		}

		[HttpGet]
		[Route("GetCountryDetails")]
		public async Task<IActionResult> GetCountrymast()
		{
			var countrylist = await countryMastRepository.GetAllAsync();

			if (countrylist != null)
			{
				_response.StatusCode = HttpStatusCode.OK;
				_response.IsSuccess = true;
				_response.Result = mapper.Map<List<AddCountryResponseDto>>(countrylist);

				return Ok(_response);
			}

			return NoContent();
		}
		[HttpPost]
		[Route("UpdateCountrymast/{id}")]
		public async Task<IActionResult> UpdateCounty([FromRoute] Guid id, [FromBody] UpdateCountryRequestDto cnt)
		{
			var countryDomainModel = mapper.Map<Country>(cnt);
			var existingCountry = await countryMastRepository.UpdateAsync(id, countryDomainModel);

			if (existingCountry == null)
			{
				_response.StatusCode = HttpStatusCode.BadRequest;
				_response.IsSuccess = true;
				_response.Result = "Wrong Details";
				return BadRequest(_response);
			}
			_response.StatusCode = HttpStatusCode.OK;
			_response.IsSuccess = true;
			_response.Result = mapper.Map<AddCountryResponseDto>(existingCountry);
			return Ok(_response);
		}
		[HttpGet]
		[Route("GetCountry/{id}")]
		public async Task<IActionResult> GetCountryById([FromRoute] Guid id)
		{
			var country = await countryMastRepository.GetByIdAsync(id);
			if (country == null)
			{
				_response.StatusCode = HttpStatusCode.NotFound;
				_response.IsSuccess = false;
				_response.Result = "Wrong Details";
				return NotFound(_response);
			}
			_response.StatusCode = HttpStatusCode.OK;
			_response.IsSuccess = true;
			_response.Result = mapper.Map<AddCountryResponseDto>(country);
			return Ok(_response);
		}



		[HttpDelete]
		[Route("DeleteCountrymast/{id}")]
		public async Task<IActionResult> DeleteCountrymast([FromRoute] Guid id)
		{
			var country = await countryMastRepository.DeleteAsync(id);
			if (country != null)
			{

				_response.StatusCode = HttpStatusCode.OK;
				_response.IsSuccess = true;
				_response.Result = mapper.Map<AddCountryResponseDto>(country)!;
				return Ok(_response);
			}
			_response.StatusCode = HttpStatusCode.NotFound;
			_response.IsSuccess = false;
			_response.Result = "No Data Found";
			return NotFound(_response);
		}

	}
}
