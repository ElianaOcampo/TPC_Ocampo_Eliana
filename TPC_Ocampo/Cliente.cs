using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_Ocampo;

namespace TPC_Ocampo
{
    public class Cliente
    {
        public int DNI { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public bool Estado { get; set; }
        public Telefono telefono;
        public Domicilio domicilio;
    }
}
