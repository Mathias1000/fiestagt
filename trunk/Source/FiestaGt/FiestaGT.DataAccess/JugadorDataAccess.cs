using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FiestaGT.DataAccess.Entities;
using System.Data.SqlClient;
using FiestaGT.Commons.Dto;

namespace FiestaGT.DataAccess
{
    public class JugadorDataAccess : BaseDataAccess
    {
        public List<Jugador> ListAll()
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_JUGADOR";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();


                    var jugadores = new List<Jugador>();

                    while (myReader.Read())
                    {
                        var jug = new Jugador();

                        jug.Id = myReader.GetInt32(0);
                        jug.Nombre = myReader.GetString(1);
                        jug.CantidadAsistencias = myReader.GetInt32(2);
                        jug.CantidadAsistenciasHistoricas = myReader.GetInt32(3);
                        jug.Activo = myReader.GetBoolean(4);

                        jugadores.Add(jug);
                    }

                    connection.Close();
                    return jugadores;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }

        public void Insert(JugadorDto dto)
        {
            string conectionString = CadenaConexion();

            string query = "INSERT INTO GT_JUGADOR (Nombre, CantidadAsistencias, CantidadAsistenciasHistoricas, Activo) VALUES (@Nombre, @CantidadAsistencias, @CantidadAsistenciasHistoricas, @Activo) ";

            // Prepara la conexion y ejecuta la query en la base
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Nombre", dto.Nombre);
                sqlCommand.Parameters.AddWithValue("@CantidadAsistencias", dto.CantidadAsistencias);
                sqlCommand.Parameters.AddWithValue("@CantidadAsistenciasHistoricas", dto.CantidadAsistenciasHistoricas);
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

        public void Update(JugadorDto dto)
        {
            string conectionString = CadenaConexion();
            string query = "UPDATE GT_JUGADOR SET Nombre = @Nombre, CantidadAsistencias = @CantidadAsistencias, CantidadAsistenciasHistoricas = @CantidadAsistenciasHistoricas, Activo = @Activo  WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ID", dto.Id);
                sqlCommand.Parameters.AddWithValue("@Nombre", dto.Nombre);
                sqlCommand.Parameters.AddWithValue("@CantidadAsistencias", dto.CantidadAsistencias);
                sqlCommand.Parameters.AddWithValue("@CantidadAsistenciasHistoricas", dto.CantidadAsistenciasHistoricas);
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

        public Jugador GetJugadorById(int jugadorId)
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_JUGADOR WHERE id = " + jugadorId;

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    var jug = new Jugador();

                    while (myReader.Read())
                    {
                        jug.Id = myReader.GetInt32(0);
                        jug.Nombre = myReader.GetString(1);
                        jug.CantidadAsistencias = myReader.GetInt32(2);
                        jug.CantidadAsistenciasHistoricas = myReader.GetInt32(3);
                        jug.Activo = myReader.GetBoolean(4);
                    }

                    connection.Close();
                    return jug;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }
    }
}
