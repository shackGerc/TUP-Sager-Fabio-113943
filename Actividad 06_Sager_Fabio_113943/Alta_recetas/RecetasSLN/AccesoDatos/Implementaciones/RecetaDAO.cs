using RecetasSLN.AccesoDatos.Interfaces;
using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RecetasSLN.AccesoDatos.Implementaciones
{
    internal class RecetaDAO : IRecetaDAO
    {
        private static RecetaDAO instancia;
        private SqlConnection conexion = new SqlConnection(Properties.Resources.ConnectionString);
        private SqlCommand cmd = new SqlCommand();

        public static RecetaDAO ObtenerInstancia()
        {
            if (instancia == null)
            {
                instancia = new RecetaDAO();
            }
            return instancia;
        }

        private void ConfigurarComando_SP(string nombreSP)
        {
            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandText = nombreSP;
            cmd.CommandType = CommandType.StoredProcedure;
        }
        
        private void Desconectar()
        {
            conexion.Close();
            cmd.Parameters.Clear();
        }

        private DataTable HacerConsultaConSP(string nombreSP)
        {
            DataTable tabla = new DataTable();
            ConfigurarComando_SP(nombreSP);
            tabla.Load(cmd.ExecuteReader());
            Desconectar();
            return tabla;
        }

        private DataTable HacerConsultaConSP(string nombreSP, List<Parametro> parametros)
        {
            DataTable tabla = new DataTable();
            ConfigurarComando_SP(nombreSP);
            for(int i = 0; i < parametros.Count; i++)
            {
                cmd.Parameters.AddWithValue(parametros[i].Nombre, parametros[i].Valor);
            }
            tabla.Load(cmd.ExecuteReader());
            Desconectar();
            return tabla;
        }

        private void ConsultaParametrosOUT(string nombreSP, List<SqlParameter> parametrosOUT)
        {
            ConfigurarComando_SP(nombreSP);
            if (parametrosOUT != null && parametrosOUT.Count != 0)
            {
                foreach (SqlParameter param in parametrosOUT)
                {
                    cmd.Parameters.Add(param);
                }
            }
            cmd.ExecuteNonQuery();
            Desconectar();
        }

        public bool CargarReceta(Receta r)
        {
            ConfigurarComando_SP("SP_INSERTAR_RECETA");
            SqlTransaction transaccion = null;
            bool exito = true;

            try
            {
                transaccion = conexion.BeginTransaction();
                cmd.Transaction = transaccion;

                cmd.Parameters.AddWithValue("@tipo_receta", r.TipoReceta);
                cmd.Parameters.AddWithValue("@nombre", r.Nombre);
                cmd.Parameters.AddWithValue("@cheff", r.Cheff);

                SqlParameter param = new SqlParameter("@new_id_receta", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                int cod_receta = (int)param.Value;

                cmd.CommandText = "SP_INSERTAR_DETALLES";

                foreach (DetalleReceta dr in r.Detalles)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@id_receta", cod_receta);
                    cmd.Parameters.AddWithValue("@id_ingrediente", dr.Ingrediente.ID);
                    cmd.Parameters.AddWithValue("@cantidad", dr.cantidad);
                    cmd.ExecuteNonQuery();
                }
                transaccion.Commit();
                Desconectar();
                return exito;
            }
            catch (Exception)
            {
                transaccion.Rollback();
                exito = false;
                return exito;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    Desconectar();
                }
            }
        }

        public DataTable ObtenerIngredientes()
        {
            return HacerConsultaConSP("SP_CONSULTAR_INGREDIENTES");
        }

        public DataTable ObtenerTiposRecetas()
        {
            return HacerConsultaConSP("SP_CONSULTAR_TIPOS_RECETA");
        }

        public int ObtenerIDProxReceta()
        {
            List<SqlParameter> parametros = new List<SqlParameter>();
            SqlParameter pOutID = new SqlParameter();
            pOutID.ParameterName = "@next";
            pOutID.DbType = DbType.Int32;
            pOutID.Direction = ParameterDirection.Output;
            parametros.Add(pOutID);
            ConsultaParametrosOUT("SP_PROXIMO_ID_RECETA", parametros);

            try
            {
                int prox_id;
                prox_id = (int)pOutID.Value;
                return prox_id;
            }
            catch(Exception)
            {
                return 1;
            }
        }

        public List<Receta> ObtenerRecetasConFiltros(int tipo, string nombre)
        {
            List<Parametro> parametros = new List<Parametro>();

            parametros.Add(new Parametro("@tipo_receta", tipo));
            parametros.Add(new Parametro("@nombre", nombre));

            DataTable tablaRecetas = HacerConsultaConSP("SP_CONSULTAR_RECETAS", parametros);

            List<Receta> recetas = new List<Receta>();
            
            for (int i = 0; i < tablaRecetas.Rows.Count; i++)
            {
                Receta receta = new Receta();
                if (!tablaRecetas.Rows[i].IsNull("nombre"))
                {
                    receta.Nombre = tablaRecetas.Rows[i]["nombre"].ToString();
                }
                if (!tablaRecetas.Rows[i].IsNull("tipo_receta"))
                {
                    receta.TipoReceta = Convert.ToInt32(tablaRecetas.Rows[i]["tipo_receta"]);
                }
                if (!tablaRecetas.Rows[i].IsNull("cheff"))
                {
                    receta.Cheff = tablaRecetas.Rows[i]["cheff"].ToString();
                }
                recetas.Add(receta);
            }

            return recetas;
        }
    }
}
