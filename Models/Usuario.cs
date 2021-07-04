using System;
using System.Collections.Generic;

#nullable disable

namespace WebGz.Models
{
    public partial class Usuario
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apodo { get; set; }
        public uint Contraseña { get; set; }
    }
}
