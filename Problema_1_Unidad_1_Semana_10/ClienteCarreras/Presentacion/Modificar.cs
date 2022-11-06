using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Dominio;
using Aplicacion.Servicios;
using Aplicacion.Servicios.Interfaces;
using ClienteCarreras.Cliente;
using Newtonsoft.Json;

namespace ClienteCarreras.Presentacion
{
    public partial class frmModificar : Form
    {
        List<Carrera> carreras;
        Carrera carreraOriginal;
        string nombreCarreraOriginal;

        IServicio servicio;
        public frmModificar()
        {
            InitializeComponent();
            carreras = new List<Carrera>();
            carreraOriginal = new Carrera();
            servicio = new ImpFabricaServicio().CrearServicio();
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
            if (carreras[i].DetallesCarrera[j].Cuatrimestre == 1)
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

        private async Task CargarListaCarrerasAsync()
        {
            string url = "http://localhost:5225/CarreraGet";
            var data = await ClienteSingleton.ObtenerInstancia().GetAsync(url);
            List<Carrera> todasLasCarreras = JsonConvert.DeserializeObject<List<Carrera>>(data);

            for (int i = 0; i < todasLasCarreras.Count; i++)
            {
                if (!todasLasCarreras[i].Deshabilitada)
                    carreras.Add(todasLasCarreras[i]);
            }

        }

        private async Task CargarCboMateriasAsync()
        {
            string url = "http://localhost:5225/api/ControllerAsignaturas";
            var data = await ClienteSingleton.ObtenerInstancia().GetAsync(url);
            List<Asignatura> asignaturas = JsonConvert.DeserializeObject<List<Asignatura>>(data);
            cboMaterias.DataSource = asignaturas;
            cboMaterias.ValueMember = "Codigo";
            cboMaterias.DisplayMember = "Nombre";
            cboMaterias.SelectedIndex = -1;
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

        private async void frmModificar_Load(object sender, EventArgs e)
        {
            await CargarCboMateriasAsync();
            await CargarListaCarrerasAsync();
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

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            Carrera carreraModificada = carreras[lstCarreras.SelectedIndex];

            string url = "http://localhost:5225/carreraPut";
            string carreraJson = JsonConvert.SerializeObject(carreraModificada);

            var result = await ClienteSingleton.ObtenerInstancia().PutAsync(url, carreraJson);

            if (result.Equals("true"))
                MessageBox.Show("La carerra se modifico con exito", "Modificación", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            else
                MessageBox.Show("La carerra no se pudo modificar", "Modificación", MessageBoxButtons.OK,
                MessageBoxIcon.Error);

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
