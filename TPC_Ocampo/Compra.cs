using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_Ocampo;

namespace TPC_Ocampo
{
    public class Compra
    {
        public long Id { get; set; }
        public long Proveedor { get; set; }
        public int CostoTotal { get; set; }
        public string MetodoPago { get; set; }
        public long Tarjeta { get; set; }
        public int Codigo { get; set; }
        public bool Estado { get; set; }
    }
}
