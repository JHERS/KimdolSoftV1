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
        [Required (ErrorMessage = "Este campo es obligatorio")]
        public int idProducto { get; set; }

        [Display(Name = "* Cantidad: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar números")]
        //[Range(0, int.MaxValue, ErrorMessage = "Solo puede ingresar números")]
        public int cantidad { get; set; }

        [Display(Name = "* Valor Unitario: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int valorUnitario { get; set; }      
        
        

    }

    [MetadataType(typeof(detalleCompraMetaData))]
    public partial class detallecompra
    {

    }
}