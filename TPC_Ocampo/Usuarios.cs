using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_Ocampo;

namespace TPC_Ocampo
{
    public class Usuarios
    {
        public string Contraseña { get; set; }
        public string NombreUsuario { get; set; }
        public int Permiso { get; set; } //Administrador - Vendedor - Cliente
        public int Dni { get; set; }
    }
}
