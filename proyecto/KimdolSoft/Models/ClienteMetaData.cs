using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KimdolSoft.Models
{
    public class ClienteMetaData
    {
      

        [Display(Name = "* Primer Nombre: ")]
        [Required]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public string primerNombre { get; set; }

        [Display(Name = "  Segundo Nombre: ")]
        [MaxLength(20)]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se permiten letras")]
        public string segundoNombre { get; set; }

        [Display(Name = "* Primer Apellido: ")]
        [Required]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public string primerApellido { get; set; }

        [Display(Name = "  Segundo Apellido: ")]
        [MaxLength(20)]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se permiten letras")]
        public string segundoApellido { get; set; }

        [Display(Name = "  Telefono: ")]
        [MaxLength(7)]
        [MinLength(7)]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public string telefono { get; set; }

        [Display(Name = "  Celular: ")]
        [MaxLength(12)]
        [MinLength(10)]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public string celular { get; set; }

        [Display(Name = "  Email")]
        [MaxLength(30)]
        public string email { get; set; }

        [Display(Name = "* Dirección: ")]
        [Required]
        [MaxLength(40)]
        public string direccion { get; set; }

        [Display(Name = "* Barrio: ")]
        [Required]
        [RegularExpression("^([a-zA-Z]+)$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(50)]
        public string barrio { get; set; }


        [Display(Name = "  Estado: ")]
        [Required]
        public string estado { get; set; }
    }

    [MetadataType(typeof(ClienteMetaData))]
    public partial class cliente
    {

    }
}