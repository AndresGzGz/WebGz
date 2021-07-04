using System;
using System.Collections.Generic;

#nullable disable

namespace WebGz.Models
{
    public partial class Compra
    {
        public int Idcliente { get; set; }
        public int Idproducto { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
