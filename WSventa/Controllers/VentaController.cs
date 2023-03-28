using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSventa.Models;
using WSventa.Models.Request;
using WSventa.Models.Response;
using WSventa.Services;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VentaController : ControllerBase
    {
        private IVentaService _venta;

        public VentaController(IVentaService venta)
        {
            this._venta = venta;
        }

        [HttpPost]
        public IActionResult Add(VentaRequest model)
        {
            Response respuesta = new Response();

            try
            {
                _venta.Add(model);
                respuesta.Exito = 1;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}
