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
    
        public int idEmpleado { get; set; }

        [Display(Name = "  Tipo Documento: ")]
        [Required]
        public int tipoDocumento { get; set; }

        [Display(Name = "  * Primer Nombre: ")]
        [Required]
        [RegularExpression("^[A-Z a-z nÑóíáéú]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int primerNombre { get; set; }

        [Display(Name = "  Segundo Nombre: ")]
        [RegularExpression("^[A-Z a-z ñÑóíáéú]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int segundoNombre { get; set; }

        [Display(Name = "  * Primer Apellido: ")]
        [Required]
        [RegularExpression("^[A-Z a-z ñÑóíáéú]*$", ErrorMessage = "Solo se permiten letras")]
        [MaxLength(20)]
        public int primerApellido { get; set; }

        [Display(Name = "  Segundo Apellido: ")]
        [RegularExpression("^[A-Z a-z ñÑ]*$", ErrorMessage = "Solo se permiten letras")]
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
        [EmailAddress(ErrorMessage ="Este campo debe tener formato correo")]
        [MaxLength(30)]
        public int email { get; set; }

        [Display(Name = "  Telefono: ")]
        [MinLength(7, ErrorMessage = "El campo teléfono debe tener mínimo 7 caracteres")]
        [MaxLength(7, ErrorMessage = "El campo teléfono debe tener máximo 7 caracteres")]
        [RegularExpression("^([0-9]+)$", ErrorMessage = "Solo se permiten números")]
        public int telefono { get; set; }

        [Display(Name = " Celular: ")]
        [MinLength(10, ErrorMessage = "El campo teléfono debe tener mínimo 10 caracteres")]
        [MaxLength(12, ErrorMessage = "El campo teléfono debe tener máximo 12 caracteres")]
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