using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;

namespace FiestaGT.DataAccess
{
    public class TorneoDataAccess : BaseDataAccess
    {
        public List<Torneo> ListAll()
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_TORNEO";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    var torneos = new List<Torneo>();

                    while (myReader.Read())
                    {
                        var torneo = new Torneo();

                        torneo.Id = myReader.GetInt32(0);
                        torneo.Fecha = myReader.GetDateTime(1);
                        torneo.Comentarios = myReader.GetString(2);
                        torneo.Activo = myReader.GetBoolean(3);

                        torneos.Add(torneo);
                    }

                    connection.Close();
                    return torneos;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }


        public void Insert(TorneoDto dto)
        {
            string conectionString = CadenaConexion();

            string query = "INSERT INTO GT_TORNEO (Fecha, Comentarios, Activo) VALUES (@Fecha, @Comentarios, @Activo) ";

            // Prepara la conexion y ejecuta la query en la base
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Fecha", dto.Fecha);
                sqlCommand.Parameters.AddWithValue("@Comentarios", dto.Comentarios);
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


        public void Update(TorneoDto dto)
        {
            string conectionString = CadenaConexion();
            string query = "UPDATE GT_TORNEO SET Fecha = @Fecha, Comentarios = @Comentarios,  Activo = @Activo  WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ID", dto.Id);
                sqlCommand.Parameters.AddWithValue("@Fecha", dto.Fecha);
                sqlCommand.Parameters.AddWithValue("@Comentarios", dto.Comentarios);
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

        public Torneo GetTorneoById(int torneoId)
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_TORNEO WHERE id = " + torneoId;

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    var tor = new Torneo();

                    while (myReader.Read())
                    {
                        tor.Id = myReader.GetInt32(0);
                        tor.Fecha = myReader.GetDateTime(1);
                        tor.Comentarios = myReader.GetString(2);
                        tor.Activo = myReader.GetBoolean(3);
                    }

                    connection.Close();
                    return tor;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }

    }
}
