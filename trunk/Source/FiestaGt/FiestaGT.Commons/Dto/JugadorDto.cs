using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FiestaGT.Commons.Dto
{
    public class JugadorDto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public int CantidadAsistencias { get; set; }

        public int CantidadAsistenciasHistoricas { get; set; }

        public bool Activo { get; set; } 
    }
}
