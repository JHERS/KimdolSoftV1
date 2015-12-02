using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace KimdolSoft.Models
{
    public class ProveedorMetaData
    {
        [Display(Name = "NIT - Documento")]
        [Required]
        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar números")]
        [Remote("ValidarIdProveedor", "proveedors", AdditionalFields ="idProveedor", ErrorMessage ="El proveedor ya se encuentra registrado")]
        public string idProveedor { get; set; }

        [Display(Name = "Tipo documento")]
        [Required]
        [MaxLength(3)]
        public string tipoDocumento { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(50)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo puede ingresar letras")]
        public string empresa { get; set; }

        [Display(Name = "Dirección")]
        [Required]
        [MaxLength(30)]
        public string direccionEmpresa { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Este campo debe tener formato correo")]
        [MaxLength(40)]
        public string emailEmpresa { get; set; }

        [Display(Name = "Teléfono")]
        [Required]
        [MaxLength(10)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar números")]
        public string telefonoEmpresa { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [MaxLength(10)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo puede ingresar letras")]
        public string estado { get; set; }

        [Display(Name = "Nombre")]
        [Required]
        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo puede ingresar letras")]
        public string nombreVendedor { get; set; }

        [Display(Name = "Apellido")]
        [Required]
        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Solo puede ingresar letras")]
        public string apellidoVendedor { get; set; }

        [Display(Name = "Teléfono")]
        [Required]
        [MaxLength(10)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Solo puede ingresar letras")]
        public string telefonoVendedor { get; set; }
    }

    [MetadataType(typeof(ProveedorMetaData))]
    public partial class proveedor
    {

    }
}