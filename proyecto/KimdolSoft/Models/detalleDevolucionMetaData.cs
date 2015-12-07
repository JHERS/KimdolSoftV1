using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class detalleDevolucionMetaData
    {
        [Display(Name = "* Producto: ")]
        [Required]
        public int idProducto { get; set; }

        [Display(Name = "* Cantidad a devolver: ")]
        [Required]
        public int cantidadADevolver { get; set; }

        [Display(Name = "* Cantidad pendiente: ")]
        [Required]
        public int cantidadPendiente { get; set; }

        [Display(Name = "* Descripción: ")]
        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }
    }
    [MetadataType(typeof(detalleDevolucionMetaData))]
    public partial class detalledevolucion
    {

    }
}