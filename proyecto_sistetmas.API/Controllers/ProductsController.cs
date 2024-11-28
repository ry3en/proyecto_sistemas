using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;
using proyecto_sistetmas.API;

namespace proyecto_sistemas.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext dataContext;

        public ProductsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var products = await dataContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .ToListAsync();

            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await dataContext.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("El producto no es válido.");
            }

            // Validar que los campos no estén vacíos o tengan un tamaño inválido (esto es opcional según tus necesidades).
            if (string.IsNullOrEmpty(product.Name) || string.IsNullOrEmpty(product.Size) || string.IsNullOrEmpty(product.Color))
            {
                return BadRequest("Los campos del producto deben estar completos.");
            }

            // Validar que la categoría y la marca existan.
            var brand = await dataContext.Brands.FindAsync(product.Brand.Id);
            var category = await dataContext.Categories.FindAsync(product.Category.Id);

            if (brand == null || category == null)
            {
                return BadRequest("La marca o la categoría especificada no existen.");
            }

            // Agregar el nuevo producto al contexto y guardar los cambios.
            dataContext.Products.Add(product);
            await dataContext.SaveChangesAsync();

            // Retornar el producto recién creado con un código de estado 201 (Creado).
            return CreatedAtAction(nameof(GetAsync), new { id = product.Id }, product);
        }
    }
}
