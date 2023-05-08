using Microsoft.AspNetCore.Mvc;
using Tienda.Models.Entities;
using Tienda.Models.Interfaces;

namespace Tienda.API.Controllers
{
    /// <summary>
    /// Administra los pedidos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CarritoController : Controller
    {
        private readonly ICarritoBusiness _business;
        public CarritoController(ICarritoBusiness carritoBusiness)
        {
            _business = carritoBusiness;
        }
        /// <summary>
        /// Guarda el pedido desde el carro de compras
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        [HttpPost("GuardaPedido")]
        public async Task<ActionResult> Save(CarritoModel datos)
        {
            var result = await _business.SavePedido(datos);
            return StatusCode(200, result);
        }
    }
}
