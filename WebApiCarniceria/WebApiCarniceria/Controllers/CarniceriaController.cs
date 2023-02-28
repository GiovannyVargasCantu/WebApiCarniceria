using Microsoft.AspNetCore.Mvc;
using WebApiCarniceria.Entidades;

namespace WebApiCarniceria.Controllers
{
    [ApiController]
    [Route("api/carniceria")]
    public class CarniceriaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            return new List<Producto>()
            {
                new Producto() { Id = 1, Nombre = "T-Bone" },
                new Producto() { Id = 2, Nombre = "Flecha" }

            };
        }


    }
}
