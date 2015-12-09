using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class PresentacionMetaData
    {

        [Display(Name = "* ID Presentacion: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(20)]
        public int idPresentacion { get; set; }

        [Display(Name = "* Nombre: ")]
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(20)]
        public string nombre { get; set; }

        [Display(Name = "Descripciones: ")]
        [MaxLength(20)]
        public string descripcion { get; set; }

    }

    [MetadataType(typeof(PresentacionMetaData))]

    public partial class presentacion
    {

    }
}