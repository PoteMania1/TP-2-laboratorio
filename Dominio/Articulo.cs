﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //public int IdMarca { get; set; }
        //public int IdCategoria { get; set; }
        public string UrlImagen { get; set; }
        public decimal Precio { get; set; }
    }
}
