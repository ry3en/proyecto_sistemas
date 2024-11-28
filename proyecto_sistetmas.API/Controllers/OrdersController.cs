using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyecto_sistemas.Shared.Entities;
using proyecto_sistetmas.API;

namespace proyecto_sistemas.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext dataContext;

        public OrdersController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        // GET: api/orders
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var orders = await dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)  // Incluir los productos de los items de la orden
                .ToListAsync();

            return Ok(orders);
        }

        // GET: api/orders/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var order = await dataContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound("La orden no fue encontrada.");
            }

            return Ok(order);
        }

        // POST: api/orders
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Order order)
        {
            if (order == null)
            {
                return BadRequest("La orden no es válida.");
            }

            // Validar que el nombre de la orden no esté vacío
            if (string.IsNullOrEmpty(order.Name))
            {
                return BadRequest("El nombre de la orden es obligatorio.");
            }

            // Validar que los items de la orden no estén vacíos
            if (order.OrderItems == null || order.OrderItems.Count == 0)
            {
                return BadRequest("La orden debe contener al menos un producto.");
            }

            // Verificar que cada item de la orden tenga un producto válido y que la cantidad sea mayor a 0
            foreach (var item in order.OrderItems)
            {
                var product = await dataContext.Products.FindAsync(item.ProductId);
                if (product == null)
                {
                    return BadRequest($"El producto con ID {item.ProductId} no existe.");
                }

                if (item.Quantity <= 0)
                {
                    return BadRequest($"La cantidad del producto {product.Name} debe ser mayor a 0.");
                }
            }

            // Calcular el total de la orden
            order.Total = order.OrderItems.Sum(item => item.Quantity * item.Product.Total);

            // Agregar la nueva orden al contexto y guardar los cambios
            dataContext.Orders.Add(order);
            await dataContext.SaveChangesAsync();

            // Retornar la orden creada con un código de estado 201 (Creado)
            return CreatedAtAction(nameof(GetAsync), new { id = order.Id }, order);
        }
    }
}
