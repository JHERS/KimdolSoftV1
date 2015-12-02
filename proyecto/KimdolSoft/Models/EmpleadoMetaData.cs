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
        //[Remote("validacionEmail", "empleadoes")]
        //public string email { get; set; }

        [Display(Name = " * Documento: ")]
        [Required]
        [MaxLength(12)]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        [Remote("ValidacionEmpleado", "empleadoes", AdditionalFields = "idEmpleado", ErrorMessage = "El empleado ya se encuentra registrado")]
       


        public int idEmpleado { get; set; }

        [Display(Name = "  Tipo Documento: ")]
        [Required]
        public int tipoDocumento { get; set; }

        [Display(Name = "  * Primer Nombre: ")]
        [Required]
        [RegularExpression("^[A-Z a-z]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int primerNombre { get; set; }

        [Display(Name = "  Segundo Nombre: ")]
        [RegularExpression("^[A-Z a-z]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int segundoNombre { get; set; }

        [Display(Name = "  * Primer Apellido: ")]
        [Required]
        [RegularExpression("^[A-Z a-z]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int primerApellido { get; set; }

        [Display(Name = "  Segundo Apellido: ")]
        [RegularExpression("^[A-Z a-z]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int segundoApellido { get; set; }

        [Display(Name = "  * Rol: ")]
        [Required]
        public int rol{ get; set; }

        [Display(Name = "  * Direccion: ")]
        [Required]
        [MaxLength(40)]
        public int direccion { get; set; }

        [Display(Name = " * Email: ")]
        [Required]
        [MaxLength(30)]
        public int email { get; set; }

        [Display(Name = "  Telefono: ")]
        [MaxLength(7)]
        [MinLength(7)]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public int telefono { get; set; }

        [Display(Name = " Celular: ")]
        [MaxLength(12)]
        [MinLength(10)]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public int celular { get; set; }

        [Display(Name = " Estado: ")]
        public int estado { get; set; }

    }
    [MetadataType(typeof(EmpleadoMetaData))]

    public partial class empleado
    {

    }
}