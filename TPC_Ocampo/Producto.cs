using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_Ocampo;

namespace TPC_Ocampo
{
    public class Producto
    {
        public long Id { get; set; }
        public string Descripcion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int PrecioCompra { get; set; }
        public Categorias categoria;
        public Marcas marca;
        public Proveedor proveedor;
    }
}
