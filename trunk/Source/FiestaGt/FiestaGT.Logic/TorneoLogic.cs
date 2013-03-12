using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiestaGT.DataAccess;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;

namespace FiestaGT.Logic
{
    public class TorneoLogic
    {

        private static TorneoDataAccess _torneoDataAccess = new TorneoDataAccess();

        public List<Torneo> ObtenerTorneos()
        {
            try
            {
                return _torneoDataAccess.ListAll().OrderByDescending(x => x.Activo).ThenByDescending(x => x.Fecha).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public void CrearTorneo(TorneoDto dto)
        {
            try
            {
                _torneoDataAccess.Insert(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Torneo ObtenerTorneoById(int id)
        {
            try
            {
                return _torneoDataAccess.GetTorneoById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public void EditarTorneo(TorneoDto dto)
        {
            try
            {
                _torneoDataAccess.Update(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<Torneo> BuscarTorneos(string buscar)
        {
            try
            {
                return _torneoDataAccess.ListAll().Where(x => x.Comentarios.ToLower().Contains(buscar.ToLower()) || x.Fecha.ToShortDateString().Contains(buscar.ToLower())).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
