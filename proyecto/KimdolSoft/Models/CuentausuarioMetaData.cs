using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KimdolSoft.Models
{
    public class CuentausuarioMetaData
    {

        [Display(Name = "Nombre usuario")]
        [Required]
        [MaxLength(20)]
        public string nombreUsuario { get; set; }

        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(12)]
        public string contrasena { get; set; }

        [Display(Name = "Pregunta seguridad")]
        [Required]
        public string preguntaSeguridad { get; set; }

        [Display(Name = "Respuesta seguridad")]
        [Required]
        [MaxLength(45)]
        public string respuestaSeguridad { get; set; }

        [Display(Name = "Id empleado")]
        [Required]
        public string idEmpleado { get; set; }

    }
    [MetadataType(typeof(CuentausuarioMetaData))]

    public partial class cuentausuario
    {
    }
}