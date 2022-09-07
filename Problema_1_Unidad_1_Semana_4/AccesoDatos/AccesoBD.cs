using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Problema_1_Unidad_1.Dominio;

namespace Problema_1_Unidad_1.AccesoDatos
{
    internal class AccesoBD
    {
        private SqlConnection conexion = new SqlConnection(
            @"Data Source=localhost;Initial Catalog=Carreras;Integrated Security=True");
        private SqlCommand cmd = new SqlCommand();

        private void ConfigurarComandoParaSP(string SPName)
        {
            conexion.Open();
            cmd.Connection = conexion;
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        public DataTable HacerConsultaConSP(string SPName)
        {
            DataTable tabla = new DataTable();

            ConfigurarComandoParaSP(SPName);
            tabla.Load(cmd.ExecuteReader());

            conexion.Close();

            return tabla;
        }

        public bool InsertarDetallesCarreraConSP(string SPName, Carrera carrera)
        {
            bool cargaExitosa = true;
            ConfigurarComandoParaSP(SPName);
            SqlTransaction transaction = null;

            try
            {
                transaction = conexion.BeginTransaction();
                cmd.Transaction = transaction;
                for (int i = 0; i < carrera.DetallesCarrera.Count; i++)
                {
                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@anioCursado", carrera.DetallesCarrera[i].AnioCursado);
                    cmd.Parameters.AddWithValue("@cuatrimestre", carrera.DetallesCarrera[i].Cuatrimestre);
                    cmd.Parameters.AddWithValue("@cod_asignatura", carrera.DetallesCarrera[i].Materia.Codigo);
                    cmd.Parameters.AddWithValue("@cod_carrera", carrera.Cod_carrera);

                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
                conexion.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
                cargaExitosa = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return cargaExitosa;
        }

        public int InsertarCarreraConSP(string SPName, Carrera carrera)
        {
            int cod_carrera;
            ConfigurarComandoParaSP(SPName);
            SqlTransaction transaction = null;
            
            try
            {
                transaction = conexion.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@nombre", carrera.NombreTitulo);

                SqlParameter param = new SqlParameter("@new_cod_carrera", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                cod_carrera = Convert.ToInt32(param.Value);

                transaction.Commit();
                conexion.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
                cod_carrera = -1;
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return cod_carrera;
        }

        public bool actualizarCarreraConSP(string SPName, Carrera carrera)
        {
            bool actualizacionExitosa = true;
            ConfigurarComandoParaSP(SPName);
            SqlTransaction transaction = null;
            try
            {
                transaction = conexion.BeginTransaction();
                cmd.Transaction= transaction;
                cmd.Parameters.AddWithValue("@cod_carrera", carrera.Cod_carrera);
                cmd.Parameters.AddWithValue("@nombre", carrera.NombreTitulo);
                cmd.Parameters.AddWithValue("@bajada_logicamente", carrera.Deshabilitada);

                cmd.ExecuteNonQuery();
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
                actualizacionExitosa = false;
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return actualizacionExitosa;
        }

        public int borrarMateriasConSP(string SPName, int cod_carrera)
        {
            int filasAfectadas = 0;
            ConfigurarComandoParaSP(SPName);
            SqlTransaction transaction = null;
            cmd.Parameters.AddWithValue("@cod_carrera", cod_carrera);

            try
            {
                transaction = conexion.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                conexion.Close();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }

            return filasAfectadas;
        }
    }
}
