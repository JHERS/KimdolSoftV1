using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class detalleCompraMetaData
    {
        [Display(Name ="* ID Producto: ")]
        [Required]
        public int idProducto { get; set; }

        [Display(Name = "* ID Compra: ")]
        [Required]
        public int idCompra { get; set; }

        [Display(Name = "* Cantidad: ")]
        [Required]
        public int cantidad { get; set; }

        [Display(Name = "* Valor Unitario: ")]
        [Required]
        public int valorUnitario { get; set; }       

    }

    [MetadataType(typeof(detalleCompraMetaData))]
    public partial class detallecompra
    {

    }
}