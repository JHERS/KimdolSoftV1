using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KimdolSoft.Models
{
  
    public partial class Compra_Detalle
    {
        public compra compra { get; set; }
        public detallecompra dtcompra { get; set; }
    }
}