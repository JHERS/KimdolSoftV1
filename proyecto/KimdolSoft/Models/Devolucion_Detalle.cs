using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KimdolSoft.Models
{
    public partial class Devolucion_Detalle
    {
        public devolucion devolucion { get; set; }        
        public detalledevolucion dtDevolucion { get; set; }
    }
}