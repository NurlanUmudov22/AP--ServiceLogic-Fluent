using API_Intro.Data;
using API_Intro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Intro.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }



        



        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _context.Categories.ToListAsync());
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var data = await _context.Categories.FindAsync(id);

            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

    

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync([FromQuery] int? id)
        {
            if(id == null)  return BadRequest();

            var data = await _context.Categories.FindAsync(id);

            if (data == null) return NotFound();

            _context.Categories.Remove(data);

             await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Create", category);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> EditAsync([FromRoute] int id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = await _context.Categories.FindAsync(id);
            if (data == null) return NotFound();

            data.Name = category.Name;

            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] string? search)
        {
            return Ok( search== null ? await _context.Categories.ToListAsync() : await _context.Categories.Where(m => m.Name.Contains(search)).ToListAsync());
        }
    }
}
