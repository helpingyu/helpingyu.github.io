using Npgsql;
using Npgsql.Internal;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;

namespace RestApi.Datos
{
    public class BaseDatos
    {
        NpgsqlConnection conexion;
        NpgsqlCommand comando;
        NpgsqlDataAdapter adapter;
        DataTable dT;
        readonly string CadenaConexion = string.Empty;

        public BaseDatos(NpgsqlConnection _conexion, NpgsqlCommand _comando, NpgsqlDataAdapter _adapter, DataTable _dt) { 
            this.conexion = _conexion;
            this.comando = _comando;
            this.adapter = _adapter;
            this.dT = _dt;
        }

        public BaseDatos() {
            dT = new DataTable();
            adapter = new NpgsqlDataAdapter();
            comando = new NpgsqlCommand();
            conexion = new NpgsqlConnection();
            //CadenaConexion = "data source=SQL8005.site4now.net;Initial Catalog=db_a95105_prueba;User Id=db_a95105_prueba_admin;Password=yewa2312";
            //CadenaConexion = "Data Source=localhost;Database=SysEnvironment;User Id=inventarios;Password=inventarios2015";
            CadenaConexion = "Server=192.168.45.129;Database=SysEnvi;Port=5432;User Id=inventarios;Password=inventarios2015";
            //CadenaConexion = "Server=192.168.100.118;Database=SysEnvironment;Port=5432;User Id=inventarios;Password=inventarios2015";

        }

        public void EjecutarProcesoAlmacenado(SqlParameter[] parParametros, string parSPName) {
            try
            {
                conexion = new NpgsqlConnection(CadenaConexion);
                comando = new NpgsqlCommand
                {
                    Connection = conexion
                };
                conexion.Open();
                comando.CommandType = CommandType.StoredProcedure;
                comando.CommandText = parSPName;
                comando.Parameters.AddRange(parParametros);
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

        }
        public DataTable RetornaTabla(NpgsqlParameter[] parParametros, string parTSQL)
        {
            dT = new DataTable();
            try
            {
                dT = new DataTable();
                //Instanciamos el objeto conexion con la cadena de conexion.
                conexion = new NpgsqlConnection(CadenaConexion);
                //Instanciamos el objeto comando con el TSQL
                comando = new NpgsqlCommand
                {
                    Connection = conexion,
                    //Asignamos el tipo de comando a ejecutar.
                    CommandType = CommandType.StoredProcedure,
                    //Agregamos el nombre del Srore procedure.
                    CommandText = parTSQL
                };//(parTSQL, cnnConexion);
                //Agregmos los parametros a ejecutar
                comando.Parameters.AddRange(parParametros);
                //Instanciamos el objeto Adaptador con el comando a utilizar
                adapter = new NpgsqlDataAdapter(comando);
                //Llenamos el Dataset con el adaptador de datos.
                adapter.Fill(dT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
                adapter.Dispose();
            }
            return dT;
        }

        #region PruebaRetornoTexto
        public DataTable RetornaTablaText(string query)
        {
            dT = new DataTable();
            try
            {
                dT = new DataTable();
                //Instanciamos el objeto conexion con la cadena de conexion.
                conexion = new NpgsqlConnection(CadenaConexion);

                comando = new NpgsqlCommand
                {
                    Connection = conexion
                };
                conexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = query;
                adapter = new NpgsqlDataAdapter(comando);
                adapter.Fill(dT);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conexion.Dispose();
                comando.Dispose();
                adapter.Dispose();
            }
            return dT;
        }
        #endregion


        public void EjecutartCommandoTexto(string query)
        {
            try
            {
                conexion = new NpgsqlConnection(CadenaConexion);
                comando = new NpgsqlCommand
                {
                    Connection = conexion
                };
                conexion.Open();
                comando.CommandType = CommandType.Text;
                comando.CommandText = query;
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            finally
            {
                conexion.Dispose();
                comando.Dispose();
            }

        }


    }
}
