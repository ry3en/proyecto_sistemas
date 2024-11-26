using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;

namespace proyecto_sistetmas.API.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public BrandsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Brands.ToListAsync());

        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var brand = await dataContext.Brands.FirstOrDefaultAsync(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(brand);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyc(Brand brand)
        {
            dataContext.Brands.Add(brand);
            await dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
