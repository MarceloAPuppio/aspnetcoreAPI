using System;
using System.Collections.Generic;
using System.Text;

namespace EL
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public List <Rol> Roles { get; set; }

    }
}
