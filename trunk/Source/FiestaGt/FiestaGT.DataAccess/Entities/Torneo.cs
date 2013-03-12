using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiestaGT.DataAccess.Entities
{
    public class Torneo
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Comentarios { get; set; }

        public bool Activo { get; set; }
    }
}
