using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;

namespace proyecto_sistetmas.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext dataContext;

        public CategoriesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Categories.ToListAsync());

        }

        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await dataContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsyc(Category category)
        {
            dataContext.Categories.Add(category);
            await dataContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync(int  id)
        {
            var affectedRows = await dataContext.Categories.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (affectedRows == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
