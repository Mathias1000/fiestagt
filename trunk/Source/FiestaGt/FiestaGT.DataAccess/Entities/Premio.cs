using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiestaGT.DataAccess.Entities
{
    public class Premio
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int ValorEnTokens { get; set; }

        public bool Activo { get; set; }
    }
}
