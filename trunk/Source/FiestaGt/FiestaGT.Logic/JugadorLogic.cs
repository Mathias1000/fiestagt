using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiestaGT.DataAccess;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;

namespace FiestaGT.Logic
{
    public class JugadorLogic
    {
        private static JugadorDataAccess _jugadorDataAccess = new JugadorDataAccess();

        public List<Jugador> ObtenerJugadores()
        {
            try 
            {
                return _jugadorDataAccess.ListAll().OrderByDescending(x => x.Activo).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public void CrearJugador(JugadorDto dto)
        {
            try
            {
                _jugadorDataAccess.Insert(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Jugador ObtenerJugadorById(int id)
        {
            try
            {
                return _jugadorDataAccess.GetJugadorById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public void EditarJugador(JugadorDto dto)
        {
            try
            {
                _jugadorDataAccess.Update(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<Jugador> BuscarJugadores(string buscar)
        {
            try
            {
                return _jugadorDataAccess.ListAll().Where(x => x.Nombre.ToLower().Contains(buscar.ToLower())).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
