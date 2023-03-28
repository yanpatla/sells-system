using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSventa.Models;
using WSventa.Models.Response;
using WSventa.Models.Request;
using Microsoft.AspNetCore.Authorization;

namespace WSventa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize ]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Response oRespuesta = new Response();

            try
            {

                using (SaleSystemContext db = new SaleSystemContext())
                {
                    var lst = db.Clientes.OrderByDescending(d => d.Id).ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(ClientRequest oModel)
        {
            Response oRespuesta = new Response();
            try
            {
                using (SaleSystemContext db = new SaleSystemContext())

                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nombre = oModel.Nombre;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
        [HttpPut]
        public IActionResult Edit(ClientRequest oModel)
        {
            Response oRespuesta = new Response();
            try
            {
                using (SaleSystemContext db = new SaleSystemContext())

                {

                    Cliente oCliente = db.Clientes.Find((long)oModel.Id);
                    oCliente.Nombre = oModel.Nombre;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
        [HttpDelete("{Id}")]
        public IActionResult Delete(long Id)
        {
            Response oRespuesta = new Response();
            try
            {
                using (SaleSystemContext db = new SaleSystemContext())

                {

                    Cliente oCliente = db.Clientes.Find(Id);
                    db.Remove(oCliente);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);

        }
    }


}
