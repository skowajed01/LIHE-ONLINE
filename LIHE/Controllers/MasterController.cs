using LIHE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIHE.Models.Domain;
using LIHE.Models;
using System.Net;
using Azure;
using LIHE.Models.DTO;
using AutoMapper;
using LIHE.Repositories.IRepositoty;
using LIHE.Repositories;

namespace LIHE.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class MasterController : Controller
	{

		protected APIResponse _response;

		private readonly IMapper mapper;
		private readonly ICountryMastRepository countryMastRepository;

		public MasterController(IMapper mapper, ICountryMastRepository countryMastRepository)
		{

			_response = new();

			this.mapper = mapper;
			this.countryMastRepository = countryMastRepository;
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
