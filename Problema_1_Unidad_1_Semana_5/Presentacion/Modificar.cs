using Problema_1_Unidad_1.AccesoDatos;
using Problema_1_Unidad_1.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Problema_1_Unidad_1.AccesoDatos;


namespace Problema_1_Unidad_1.Presentacion
{
    public partial class frmModificar : Form
    {
        List<Carrera> carreras;
        Carrera carreraOriginal;
        string nombreCarreraOriginal;

        public frmModificar()
        {
            InitializeComponent();
            carreras = new List<Carrera>();
            carreraOriginal = new Carrera();
        }

        private void HabilitarBotones(bool selector)
        {
            btnCancelar.Enabled =
            btnAceptar.Enabled = selector;

            btnModificar.Enabled =
            btnSalir.Enabled = !selector;
        }

        private void HabilitarCamposDeCarga(bool selector)
        {
            txtNombreCarrera.Enabled =
                txtAnioCursado.Enabled =
                rbnPrimerCuatrimestre.Enabled =
                rbnSegundoCuatrimestre.Enabled =
                cboMaterias.Enabled = selector;
        }

        private void CargarCamposMaterias()
        {
            int i = lstCarreras.SelectedIndex;
            int j = lstMaterias.SelectedIndex;
            txtAnioCursado.Text = Convert.ToString(carreras[i].DetallesCarrera[j].AnioCursado);
            cboMaterias.SelectedValue = carreras[i].DetallesCarrera[j].Materia.Codigo;
            if(carreras[i].DetallesCarrera[j].Cuatrimestre == 1)
            {
                rbnPrimerCuatrimestre.Checked = true;
            }
            else
            {
                rbnSegundoCuatrimestre.Checked = true;
            }
        }

        private void LimpiarCamposMaterias()
        {
            txtAnioCursado.Text = "";
            cboMaterias.SelectedIndex = -1;
            rbnPrimerCuatrimestre.Checked =
                rbnSegundoCuatrimestre.Checked = false;
        }

        private void CargarCampoNombreCarrera()
        {
            if (lstCarreras.SelectedIndex != -1)
            {
                int i = lstCarreras.SelectedIndex;

                txtNombreCarrera.Text = carreras[i].NombreTitulo;
            }    
        }

        private void CargarListaCarreras()
        {
            DataTable tablaCarreras = DBHelper.ObtenerInstancia().HacerConsultaConSP("pa_consultar_carreras");
            DataTable tablaDetalles = DBHelper.ObtenerInstancia().HacerConsultaConSP("pa_consultar_detalleCarrera");
            int ultimaPosicion = 0;

            for (int i = 0; i < tablaCarreras.Rows.Count; i++)
            {
                Carrera carrera = new Carrera();
                if (!tablaCarreras.Rows[i].IsNull("nombre"))
                {
                    carrera.NombreTitulo = tablaCarreras.Rows[i]["nombre"].ToString();
                }

                if (!tablaCarreras.Rows[i].IsNull("cod_carrera"))
                {
                    carrera.Cod_carrera = Convert.ToInt32(tablaCarreras.Rows[i]["cod_carrera"]);
                }

                if (tablaCarreras.Rows[i].IsNull("bajada_logicamente"))
                {
                    carrera.Deshabilitada = false;
                }
                else
                {
                    carrera.Deshabilitada = (bool)tablaCarreras.Rows[i]["bajada_logicamente"];
                }

                for (int j = ultimaPosicion; j < tablaDetalles.Rows.Count; j++)
                {

                    if (carrera.Cod_carrera ==
                        Convert.ToInt32(tablaDetalles.Rows[j]["cod_carrera"]))
                    {
                        int anioCursado = Convert.ToInt32(tablaDetalles.Rows[j]["anio_cursado"]);
                        int cuatrimestre = Convert.ToInt32(tablaDetalles.Rows[j]["cuatrimestre"]);

                        Asignatura materia = new Asignatura();
                        materia.Codigo = Convert.ToInt32(tablaDetalles.Rows[j]["cod_asignatura"]);
                        materia.Nombre = tablaDetalles.Rows[j]["nombre asignatura"].ToString();

                        DetalleCarrera detalleCarrera = new DetalleCarrera(anioCursado, cuatrimestre,
                            materia);

                        carrera.AgregarDetalle(detalleCarrera);
                    }
                    else
                    {
                        break;
                    }

                    ultimaPosicion = j+1;
                }
                if (!carrera.Deshabilitada)
                {
                    carreras.Add(carrera);
                }
            }

        }

        private void CargarListBoxCarreras(List<Carrera> carreras)
        {
            lstCarreras.Items.Clear();
            foreach (Carrera carrera in carreras)
            {
                lstCarreras.Items.Add(carrera);
            }
            lstCarreras.SelectedIndex = -1;
        }

        private void frmModificar_Load(object sender, EventArgs e)
        {
            DataTable tabla = DBHelper.ObtenerInstancia().HacerConsultaConSP("pa_recuperar_asignaturas");
            cboMaterias.DataSource = tabla;
            cboMaterias.ValueMember = tabla.Columns[0].ColumnName;
            cboMaterias.DisplayMember = tabla.Columns[1].ColumnName;
            cboMaterias.SelectedIndex = -1;

            CargarListaCarreras();
            CargarListBoxCarreras(carreras);
            HabilitarBotones(false);
            HabilitarCamposDeCarga(false);
            btnBorrar.Visible = false;
            btnBorrar.Enabled = false;
        }

        private void lstCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            nombreCarreraOriginal = carreras[lstCarreras.SelectedIndex].NombreTitulo;

            CargarCampoNombreCarrera();

            LimpiarCamposMaterias();

            lstMaterias.Items.Clear();

            if (lstCarreras.SelectedIndex != -1)
            {
                foreach (DetalleCarrera dC in carreras[lstCarreras.SelectedIndex].DetallesCarrera)
                {
                    lstMaterias.Items.Add(dC);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lstMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMaterias.SelectedIndex != -1)
            {
                CargarCamposMaterias();
                btnBorrar.Enabled = true;
            }
            else
            {
                LimpiarCamposMaterias();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(lstCarreras.SelectedIndex != -1)
            {
                carreraOriginal = (Carrera) carreras[lstCarreras.SelectedIndex].Clone();
                HabilitarBotones(true);
                HabilitarCamposDeCarga(true);
                lstCarreras.Enabled = false;
                btnBorrar.Visible = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarBotones(false);
            HabilitarCamposDeCarga(false);
            btnBorrar.Visible = false;
            btnBorrar.Enabled = false;
            lstCarreras.Enabled = true;

            carreras[lstCarreras.SelectedIndex] = carreraOriginal;
            lstCarreras.Items[lstCarreras.SelectedIndex] = carreraOriginal;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int iCarreras = lstCarreras.SelectedIndex;
            int iDetalles = lstMaterias.SelectedIndex;

            carreras[iCarreras].DetallesCarrera.RemoveAt(iDetalles);
            lstMaterias.Items.RemoveAt(iDetalles);

            lstMaterias.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Carrera carreraModificada = carreras[lstCarreras.SelectedIndex];
            if (nombreCarreraOriginal != txtNombreCarrera.Text)
            {
                carreraModificada.NombreTitulo = txtNombreCarrera.Text;
                DBHelper.ObtenerInstancia().actualizarCarreraConSP("pa_actualizar_carrera", carreraModificada);
            }

            DBHelper.ObtenerInstancia().borrarMateriasConSP("pa_borrar_detalles_carrera", carreraModificada.Cod_carrera);
            DBHelper.ObtenerInstancia().InsertarDetallesCarreraConSP("pa_insertar_detalleCarrera", carreraModificada);

            lstCarreras.Enabled = true;
            HabilitarBotones(false);
            HabilitarCamposDeCarga(false);
            LimpiarCamposMaterias();
            lstCarreras.Items.Clear();
            lstMaterias.Items.Clear();
            CargarListBoxCarreras(carreras);
            btnBorrar.Visible = false;
        }

        private void txtAnioCursado_TextChanged(object sender, EventArgs e)
        {
            if (txtAnioCursado.Text != string.Empty)
            {
                int iCarreras = lstCarreras.SelectedIndex;
                int iDetalles = lstMaterias.SelectedIndex;

                carreras[iCarreras].DetallesCarrera[iDetalles].AnioCursado = int.Parse(txtAnioCursado.Text);
            }
        }

        private void cboMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMaterias.SelectedIndex != -1 && lstCarreras.SelectedIndex != -1)
            {
                if (cboMaterias.SelectedIndex != -1)
                {
                    int iCarreras = lstCarreras.SelectedIndex;
                    int iDetalles = lstMaterias.SelectedIndex;

                    carreras[iCarreras].DetallesCarrera[iDetalles].Materia.Codigo = (int)cboMaterias.SelectedValue;
                    carreras[iCarreras].DetallesCarrera[iDetalles].Materia.Nombre = (string)cboMaterias.Text;
                }
            }
        }

        private void rbnPrimerCuatrimestre_CheckedChanged(object sender, EventArgs e)
        {
            int iCarreras = lstCarreras.SelectedIndex;
            int iDetalles = lstMaterias.SelectedIndex;
            if (lstMaterias.SelectedIndex != -1 && lstCarreras.SelectedIndex != -1)
            {
                if (rbnPrimerCuatrimestre.Checked)
                {
                    carreras[iCarreras].DetallesCarrera[iDetalles].Cuatrimestre = 1;
                }
                else
                {
                    carreras[iCarreras].DetallesCarrera[iDetalles].Cuatrimestre = 2;
                }
            }
        }
    }
}
