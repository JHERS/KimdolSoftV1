using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class ComprasMetaData
    {

        [Display(Name = " * Proveedor")]
        [Required(ErrorMessage = "Seleccione una ópción")]
        public string idProveedor { get; set; }

        [Display(Name = "* Fecha compra: ")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fechaCompra { get; set; }

        [Display(Name = "  Estado: ")]
        [Required]
        public string estado { get; set; }

        [Display(Name = "  Descuento: ")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public int descuento { get; set; }

        [Display(Name = "*  Valor compra: ")]
        [Required]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public int valorCompra { get; set; }

    }
    [MetadataType(typeof(ComprasMetaData))]
    public partial class compra
    {

    }
}