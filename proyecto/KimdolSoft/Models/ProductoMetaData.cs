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
        [Required(ErrorMessage = "    Este campo es obligatorio")]
        public int idPresentacion { get; set; }

        [Display(Name = "* Tipo de producto: ")]
        [Required(ErrorMessage = "    Este campo es obligatorio")]
        public int idTipoProducto { get; set; }

        [Display(Name = "* Marca: ")]
        [Required(ErrorMessage = "    Este campo es obligatorio")]
        public int idMarca { get; set; }

        [Display(Name = "* Unidad: ")]
        [Required(ErrorMessage = "    Este campo es obligatorio")]
        public int idUnidad { get; set; }

        [Display(Name = "* Valor: ")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar números")]
        [Required(ErrorMessage = "    Este campo es obligatorio")]
        public int valor { get; set; }

        [Display(Name = "  Estado: ")]
        [Required(ErrorMessage = "    Este campo es obligatorio")]
        public string estado { get; set; }

        [Display(Name = "* Nombre: ")]
        [Required(ErrorMessage = "    Este campo es obligatorio")]
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