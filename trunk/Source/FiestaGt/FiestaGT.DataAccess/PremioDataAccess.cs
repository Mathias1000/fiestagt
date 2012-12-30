using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using FiestaGT.DataAccess.Entities;
using FiestaGT.Commons.Dto;

namespace FiestaGT.DataAccess
{
    public class PremioDataAccess : BaseDataAccess
    {

        public List<Premio> ListAll()
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_PREMIO";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    var premios = new List<Premio>();

                    while (myReader.Read())
                    {
                        var premio = new Premio();

                        premio.Id = myReader.GetInt32(0);
                        premio.Nombre = myReader.GetString(1);
                        premio.ValorEnTokens = myReader.GetInt32(2);
                        premio.Activo = myReader.GetBoolean(3);

                        premios.Add(premio);
                    }

                    connection.Close();
                    return premios;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }


        public void Insert(PremioDto dto)
        {
            string conectionString = CadenaConexion();

            string query = "INSERT INTO GT_PREMIO (Nombre, ValorEnTokens, Activo) VALUES (@Nombre, @ValorEnTokens, @Activo) ";

            // Prepara la conexion y ejecuta la query en la base
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Nombre", dto.Nombre);
                sqlCommand.Parameters.AddWithValue("@ValorEnTokens", dto.ValorEnTokens);
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


        public void Update(PremioDto dto)
        {
            string conectionString = CadenaConexion();
            string query = "UPDATE GT_PREMIO SET Nombre = @Nombre, ValorEnTokens = @ValorEnTokens,  Activo = @Activo  WHERE ID = @Id";

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@ID", dto.Id);
                sqlCommand.Parameters.AddWithValue("@Nombre", dto.Nombre);
                sqlCommand.Parameters.AddWithValue("@ValorEnTokens", dto.ValorEnTokens);
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

        public Premio GetPremioById(int premioId)
        {
            string conectionString = CadenaConexion();
            string query = "SELECT * FROM GT_PREMIO WHERE id = " + premioId;

            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader myReader = sqlCommand.ExecuteReader();

                    var pre = new Premio();

                    while (myReader.Read())
                    {
                        pre.Id = myReader.GetInt32(0);
                        pre.Nombre = myReader.GetString(1);
                        pre.ValorEnTokens = myReader.GetInt32(2);
                        pre.Activo = myReader.GetBoolean(3);
                    }

                    connection.Close();
                    return pre;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message, e);
                }
            }
        }
    }
}
