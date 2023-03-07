using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCarniceria.Entidades;

namespace WebApiCarniceria.Controllers
{
    [ApiController]
    [Route("api/TipoProducto")]
    public class TipoProductoController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;
        
        public TipoProductoController(ApplicationDBContext context) 
        {
            this.dbContext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<TipoProducto>>> GetAll() 
        {
            return await dbContext.TipoProductos.ToListAsync();
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult<TipoProducto>> GetById(int id) 
        {
            return await dbContext.TipoProductos.FirstOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]

        public async Task<ActionResult> Post(TipoProducto tipoProducto)
        {
           dbContext.Add(tipoProducto);
           await dbContext.SaveChangesAsync();
           return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(TipoProducto tipoProducto, int id)
        {
            if (tipoProducto.Id != id)
            {
                return BadRequest("El id del tipo de producto no coincide con el que se establecio en la url");
            }

            dbContext.Update(tipoProducto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.TipoProductos.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No fue encontrado el Id");
            }

            dbContext.Remove(new TipoProducto()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }
    }
}
