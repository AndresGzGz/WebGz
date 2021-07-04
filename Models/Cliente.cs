using System;
using System.Collections.Generic;

#nullable disable

namespace WebGz.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Compras = new HashSet<Compra>();
        }

        public int Idcliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public uint CC { get; set; }
        public string Celular { get; set; }

        public virtual ICollection<Compra> Compras { get; set; }
    }
}
