using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC_Ocampo
{
    public class Factura
    {
        public long Id { get; set; }
        public long Producto { get; set; }
        public int Costo { get; set; }
        public int Cantidad { get; set; }
        public int SubTotal { get; set; }
    }
}
