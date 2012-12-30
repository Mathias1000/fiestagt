using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiestaGT.DataAccess;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;

namespace FiestaGT.Logic
{
    public class PremioLogic
    {
        private static PremioDataAccess _premioDataAccess = new PremioDataAccess();

        public List<Premio> ObtenerPremios()
        {
            try
            {
                return _premioDataAccess.ListAll().OrderByDescending(x => x.Activo).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public void CrearPremio(PremioDto dto)
        {
            try
            {
                _premioDataAccess.Insert(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public Premio ObtenerPremioById(int id)
        {
            try
            {
                return _premioDataAccess.GetPremioById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public void EditarPremio(PremioDto dto)
        {
            try
            {
                _premioDataAccess.Update(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<Premio> BuscarPremios(string buscar)
        {
            try
            {
                return _premioDataAccess.ListAll().Where(x => x.Nombre.ToLower().Contains(buscar.ToLower())).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
    }
}
