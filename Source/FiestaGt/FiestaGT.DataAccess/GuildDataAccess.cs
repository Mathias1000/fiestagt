using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiestaGT.DataAccess.Entities;
using System.Data.SqlClient;
using FiestaGT.Commons.Dto;

namespace FiestaGT.DataAccess
{
    public class GuildDataAccess : BaseDataAccess
    {
        public List<Guild> ListAll()
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_GUILD";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();


                    var guilds = new List<Guild>();

                    while (myReader.Read())
                    {
                        var guild = new Guild();

                        guild.Id = myReader.GetInt32(0);
                        guild.Nombre = myReader.GetString(1);
                        guild.Activo = myReader.GetBoolean(2);

                        guilds.Add(guild);
                    }

                    connection.Close();
                    return guilds;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }



        public void Insert(GuildDto dto)
        {
            string conectionString = CadenaConexion();

            string query = "INSERT INTO GT_GUILD (Nombre, Activo) VALUES (@Nombre, @Activo) ";

            // Prepara la conexion y ejecuta la query en la base
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Nombre", dto.Nombre);
                sqlCommand.Parameters.AddWithValue("@Activo", dto.Activo);

                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }




        public Guild GetGuildById(int guildId)
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_GUILD WHERE id = " + guildId;

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    var guild = new Guild();

                    while (myReader.Read())
                    {
                        guild.Id = myReader.GetInt32(0);
                        guild.Nombre = myReader.GetString(1);
                        guild.Activo = myReader.GetBoolean(2);
                    }

                    connection.Close();
                    return guild;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }

    }
}
