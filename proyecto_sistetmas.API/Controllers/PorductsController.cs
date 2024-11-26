using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;

namespace proyecto_sistetmas.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class PorductsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public PorductsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Products.ToListAsync());

        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await dataContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyc(Product product)
        {
            dataContext.Products.Add(product);
            await dataContext.SaveChangesAsync();
            return Ok();
        }
    }
}
