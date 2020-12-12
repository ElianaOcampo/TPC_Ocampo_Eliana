﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_Ocampo;

namespace TPC_Ocampo
{
    public class Domicilio
    {
        public long Id { get; set; }
        public string Calle { get; set; }
        public int Altura { get; set; }
        public int CodigoPostal { get; set; }
        public string Localidad { get; set; }
    }
}
