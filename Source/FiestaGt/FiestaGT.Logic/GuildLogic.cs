using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiestaGT.DataAccess;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;

namespace FiestaGT.Logic
{
    public class GuildLogic
    {

        private static GuildDataAccess _guildDataAccess = new GuildDataAccess();

        public List<Guild> ObtenerGuilds()
        {
            try
            {
                return _guildDataAccess.ListAll().OrderByDescending(x => x.Activo).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public List<Guild> BuscarGuilds(string buscar)
        {
            try
            {
                return _guildDataAccess.ListAll().Where(x => x.Nombre.ToLower().Contains(buscar.ToLower())).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

        public void CrearGuild(GuildDto dto)
        {
            try
            {
                _guildDataAccess.Insert(dto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }


        public Guild ObtenerGuildById(int id)
        {
            try
            {
                return _guildDataAccess.GetGuildById(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }

    }
}
