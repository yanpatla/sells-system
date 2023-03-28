using WSventa.Models;
using WSventa.Models.Request;

namespace WSventa.Services
{
    public class VentaService : IVentaService
    {
        public void Add(VentaRequest model)
        {


            using (SaleSystemContext db = new SaleSystemContext())
            {


                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {

                        var venta = new Venta();
                        venta.Total = model.Conceptos.Sum(d => d.Cantidad * d.PrecioUnitario);
                        venta.Fecha = DateTime.Now;
                        venta.IdCliente = model.IdCliente;
                        db.Ventas.Add(venta);
                        db.SaveChanges();

                        foreach (var modelConcepto in model.Conceptos)
                        {
                            var concepto = new Concepto();
                            concepto.Cantidad = modelConcepto.Cantidad;
                            concepto.IdProducto = modelConcepto.IdProducto;
                            concepto.PrecioUnitario = modelConcepto.PrecioUnitario;
                            concepto.Importe = modelConcepto.Importe;
                            concepto.IdVenta = venta.Id;
                            db.Conceptos.Add(concepto);
                            db.SaveChanges();
                        }
                        transaction.Commit();

                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Sorry, an error occurred while trying to create the sale");
                    }
                }
            }



        }
    }
}
