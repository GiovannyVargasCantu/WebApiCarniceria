using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCarniceria.Entidades;

namespace WebApiCarniceria.Controllers
{
    [ApiController]
    [Route("api/producto")] //Cambie el nombre dado que no me parecia que era intuitivo, asi mismo cambie el nombre de la clase a ProductoController.
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public ProductoController(ApplicationDBContext context)
        {
            this.dbContext= context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get() //Cambie el metodo Get
        {
            return await dbContext.Producto.Include(x => x.TipoProducto).ToListAsync();  
            //return await dbContext.Producto.ToListAsync();
        }

        [HttpGet("/lista")] //Lista

        public async Task<ActionResult<List<Producto>>> GetAll()
        {
            return await dbContext.Producto.ToListAsync();
        }
        [HttpPost]
        public async Task<ActionResult>Post(Producto producto) //Agregue metodo Post
        {
            dbContext.Add(producto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]

        public async Task<ActionResult> Put(Producto producto, int id)
        {
            if(producto.Id != id)
            {
                return BadRequest("El id del producto no coincide con el que se establecio en la url");
            }

            dbContext.Update(producto);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var exist = await dbContext.Producto.AnyAsync(x => x.Id == id);
            if (!exist)
            {
                return NotFound("No fue encontrado el Id");
            }

            dbContext.Remove(new Producto()
            {
                Id = id
            });
            await dbContext.SaveChangesAsync();
            return Ok();

        }
       


    }
}
