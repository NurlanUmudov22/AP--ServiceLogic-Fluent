using API_Intro.Data;
using API_Intro.DTOs.Cities;
using API_Intro.DTOs.Countries;
using API_Intro.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Intro.Controllers
{
  
    public class CityController : BaseController
    {
        private readonly AppDbContext _context;

        private readonly IMapper _mapper;

        public CityController(AppDbContext context,
                                IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CityCreateDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existCountry = await _context.Countries.FindAsync(request.CountryId);

            if (existCountry == null)
            {
                return NotFound();
            }


            await _context.Cities.AddAsync(_mapper.Map<City>(request));

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), request);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            return Ok(_mapper.Map < List<CityDto>>(await _context.Cities.Include(m => m.Country).AsNoTracking().ToListAsync()));
        }
    }
}
