using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class ComprasMetaData
    {
        [Display(Name = "* Fecha compra: ")]
        [Required]    
        public DateTime fechaCompra { get; set; }

        [Display(Name = "  Estado: ")]
        [Required]
        public string estado { get; set; }

        [Display(Name = "  Descuento: ")]
        public int descuento { get; set; }

        [Display(Name = "*  Valor compra: ")]
        [Required]
        public int valorCompra { get; set; }

    }
    [MetadataType(typeof(ComprasMetaData))]
    public partial class compra
    {

    }
}