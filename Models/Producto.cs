using System;
using System.Collections.Generic;

#nullable disable

namespace WebGz.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Compras = new HashSet<Compra>();
        }

        public int Idproducto { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Idprovedor { get; set; }

        public virtual Provedor IdprovedorNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
