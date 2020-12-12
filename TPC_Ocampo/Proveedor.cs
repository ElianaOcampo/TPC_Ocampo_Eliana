using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_Ocampo;

namespace TPC_Ocampo
{
    public class Proveedor
    {
        public long CUIT { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public Telefono telefono;
        public bool Estado { get; set; }
    }
}
