using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KimdolSoft.Models
{
    public class ContactoMetaData
    {
        [Display(Name = "Id contacto")]
        [Required]
        [MaxLength(12)]
        [Remote("validacionContacto", "contactoes")]
        public string idContacto { get; set; }

        [Display(Name = "Tipo documento")]
        [Required]
        [MaxLength(3)]
        public string tipoDocumento { get; set; }

        [Display(Name = "Primer nombre")]
        [Required]
        [MaxLength(20)]
        public string primerNombre { get; set; }

        [Display(Name = "Segundo nombre")]
        [MaxLength(20)]
        public string segundoNombre { get; set; }

        [Display(Name = "Primer apellido")]
        [Required]
        [MaxLength(20)]
        public string primerApellido { get; set; }

        [Display(Name = "Segundo apellido")]
        [MaxLength(20)]
        public string segundoApellido { get; set; }

        [Display(Name = "Celular")]
        [Required]
        [MaxLength(12)]
        public string celular { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Este campo debe tener formato correo")]
        [MaxLength(40)]
        public string email { get; set; }

        [Display(Name = "Id proveedor")]
        [Required]
        public string idProveedor { get; set; }

    }
    [MetadataType(typeof(ContactoMetaData))]
    public partial class contacto
    {

    }
}