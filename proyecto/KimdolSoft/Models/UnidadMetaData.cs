using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class UnidadMetaData
    {

        [Display(Name = "* ID Unidad: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(20)]
        public int idUnidad { get; set; }

        [Display(Name = "* Nombre: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(20)]
        public string nombre { get; set; }

        [Display(Name = "Descripciones: ")]
        [MaxLength(20)]
        public string descripcion { get; set; }
    }

    [MetadataType(typeof(UnidadMetaData))]

    public partial class unidad
    {

    }
}