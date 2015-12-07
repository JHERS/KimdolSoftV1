using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class DevolucionMetaData
    {
        [Display(Name = "* ID Proveedor: ")]
        [Required]
        public string idProveedor { get; set; }

        [Display(Name = "* Fecha devolución: ")]
        [Required]
        public DateTime fechaDevolucion { get; set; }

        [Display(Name = "* Estado: ")]
        [Required]
        public string estado { get; set; }

    }
    [MetadataType(typeof(DevolucionMetaData))]
    public partial class devolucion
    {

    }
}