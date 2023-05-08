using System.ComponentModel.DataAnnotations;

namespace Tienda.Models.Entities
{
    public class CarritoModel
    {
        public int idPedido { get; set; }
        [Required]
        public int idCliente { get; set; }
        public decimal valorTotal { get; set; }
        public List<DetallePedido> detalles { get; set; }
    }

    public class DetallePedido {
        public int idPedido { get; set; }
        public int cantidad { get; set; }
        public decimal vlUnit { get; set; }
        [Required(ErrorMessage= "El nombre o referencia del producto es necesario")]
        [MaxLength(200)]
        public string? producto { get; set; }
    }
}