using CodigosAlma.Data;
using CodigosAlma.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace CodigosAlma.Data.Usuario
{
    public class UsuarioDB
    {
        private ConexionDB con = new ConexionDB();
        public Tuple<string, string, int> loginUsuario(CMUsuario cmusuario, string bandera)
        {
            string rpta = "";
            string msg = "";
            int id_usuario = 0;
            MySqlConnection mySqlCon = new MySqlConnection();

            try
            {
                mySqlCon.ConnectionString = con.obtenerDatosConexion(bandera);
                mySqlCon.Open();
                MySqlCommand mySqlCmd = new MySqlCommand();
                mySqlCmd.Connection = mySqlCon;
                mySqlCmd.CommandText = "loginUsuario";
                mySqlCmd.CommandType = CommandType.StoredProcedure;
                mySqlCmd.Parameters.AddWithValue("p_usuario", cmusuario.usuario);
                mySqlCmd.Parameters.AddWithValue("p_contrasena", cmusuario.contrasena);

                MySqlDataReader sdr = mySqlCmd.ExecuteReader();
                if(sdr.Read())
                {
                    rpta = sdr["rpta"].ToString();
                    msg = sdr["msg"].ToString();
                    id_usuario = Convert.ToInt32(sdr["id_usuario"]);
                }
            }
            catch(MySqlException ex)
            {
                msg = ex.Message;
            }
            finally
            {
                if (mySqlCon.State == ConnectionState.Open)
                {
                    mySqlCon.Close();
                }
            }

            return Tuple.Create(rpta, msg, id_usuario);
        }
    }
}