using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
    public class MarcaMetaData
    {
        [Display(Name = "* ID Marca: ")]
        [Required]
        [MaxLength(20)]
        public int idMarca { get; set; }

        [Display(Name = "* Nombre: ")]
        [Required]
        [MaxLength(20)]
        public string nombre { get; set; }

        [Display(Name = "Descripciones: ")]
        [Required]
        [MaxLength(20)]
        public string descripcion { get; set; }
    }

    [MetadataType(typeof(MarcaMetaData))]

    public partial class marca
    {

    }
}