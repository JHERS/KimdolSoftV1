using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class ProductoMetaData
    {
        [Display(Name = "* Presentación: ")]
        [Required]
        public int idPresentacion { get; set; }

        [Display(Name = "* Tipo de producto: ")]
        [Required]
        public int idTipoProducto { get; set; }

        [Display(Name = "* Marca: ")]
        [Required]
        public int idMarca { get; set; }

        [Display(Name = "* Unidad: ")]
        [Required]
        public int idUnidad { get; set; }

        [Display(Name = "* Valor: ")]
        [Required]
        public int valor { get; set; }

        [Display(Name = "  Estado: ")]
        [Required]
        public string estado { get; set; }

        [Display(Name = "* Nombre: ")]
        [Required]
        [MaxLength(20)]
        public string nombre { get; set; }

        [Display(Name = "Descripción: ")]
        [MaxLength(100)]
        public string descripcion { get; set; }

    }

    [MetadataType(typeof(ProductoMetaData))]

    public partial class producto
    {

    }
}