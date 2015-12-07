using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class ComprasMetaData
    {
        [Display(Name ="* Proveedor:")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string idProveedor { get; set; }

        [Display(Name = "* Fecha compra: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public DateTime fechaCompra { get; set; }

        [Display(Name = "  Estado: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string estado { get; set; }

        [Display(Name = "  Descuento: ")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar números")]
        public int descuento { get; set; }

        [Display(Name = "*  Valor compra: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]       
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar números")]
        public int valorCompra { get; set; }

    }
    [MetadataType(typeof(ComprasMetaData))]
    public partial class compra
    {

    }
}