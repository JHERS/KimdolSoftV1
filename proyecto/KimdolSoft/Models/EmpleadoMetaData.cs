using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KimdolSoft.Models
{
    public class EmpleadoMetaData
    {
        [Remote("validacionEmail", "empleadoes")]
        public string email { get; set; }

        [Display(Name = " * Documento: ")]
        [Required]
        public int idEmpleado { get; set; }

        [Display(Name = "  Tipo Documento: ")]
        [Required]
        public int tipoDocumento { get; set; }

        [Display(Name = "  * Primer Nombre: ")]
        [Required]
        public int primerNombre { get; set; }

        [Display(Name = "  Segundo Nombre: ")]
        [Required]
        public int segundoNombre { get; set; }

        [Display(Name = "  * Primer Apellido: ")]
        [Required]
        public int primerApellido { get; set; }

        [Display(Name = "  Segundo Apellido: ")]
        [Required]
        public int segundoApellido { get; set; }

        [Display(Name = "  * Rol: ")]
        [Required]
        public int rol{ get; set; }

        [Display(Name = "  * Direccion: ")]
        [Required]
        public int direccion { get; set; }
    }
    [MetadataType(typeof(EmpleadoMetaData))]

    public partial class empleado
    {

    }
}