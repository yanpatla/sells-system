using System.ComponentModel.DataAnnotations;

namespace WSventa.Models.Request
{
    public class VentaRequest
    {
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "The value of IdCliente must be more than 0")]
        [ExisteCliente(ErrorMessage = "The client doesnt Excist")]
        public long IdCliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Coneceptos must excist")]
        public List<Concepto> Conceptos { get; set; }

        public VentaRequest()
        {

            this.Conceptos = new List<Concepto>();
        }
    }

    public class ConceptoRequest
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Improte { get; set; }
        public long IdProducto { get; set; }
    }

    #region
    public class ExisteCliente : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            long idCliente = (long)value;
            using (var db = new Models.SaleSystemContext())
            {
                if (db.Clientes.Find(idCliente) == null)
                {
                    return false;
                }
            }
            return true;
        }
    }

    #endregion
}
