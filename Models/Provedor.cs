using System;
using System.Collections.Generic;

#nullable disable

namespace WebGz.Models
{
    public partial class Provedor
    {
        public Provedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idprovedor { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
