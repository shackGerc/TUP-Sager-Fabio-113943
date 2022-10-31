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
    public partial class frmConsultar : Form
    {
        List<Carrera> carreras;
        List<Carrera> carrerasDeshabilitadas;

        IServicio servicio;
        public frmConsultar()
        {
            InitializeComponent();
            carreras = new List<Carrera>();
            carrerasDeshabilitadas = new List<Carrera>();
            servicio = new ImpFabricaServicio().CrearServicio();
        }

        private async Task CargarListaCarrerasAsync()
        {
            string url = "http://localhost:5225/api/ControllerCarreras";
            var data = await ClienteSingleton.ObtenerInstancia().GetAsync(url);
            List<Carrera> todasLasCarreras = JsonConvert.DeserializeObject<List<Carrera>>(data);

            for (int i = 0; i < todasLasCarreras.Count; i++)
            {
                if (!todasLasCarreras[i].Deshabilitada)
                    carreras.Add(todasLasCarreras[i]);
                else
                    carrerasDeshabilitadas.Add(todasLasCarreras[i]);
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

        private async void Consulta_carreras_Load(object sender, EventArgs e)
        {
            await CargarListaCarrerasAsync();
            CargarListBoxCarreras(carreras);
            btnDeshabilitar.Enabled = false;
            btnRestaurar.Visible = false;
            btnRestaurar.Enabled = false;
        }


        private void lstCarreras_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            dgvDetalles.Rows.Clear();

            if (lstCarreras.SelectedIndex != -1)
            {

                if (!chkbMostrarCarrerasDeshabilitadas.Checked)
                {
                    btnDeshabilitar.Enabled = true;

                    foreach (DetalleCarrera dC in carreras[lstCarreras.SelectedIndex].DetallesCarrera)
                    {
                        dgvDetalles.Rows.Add(dC.Materia.Codigo, dC.Materia.Nombre, dC.AnioCursado, dC.Cuatrimestre);
                    }
                }
                else
                {
                    btnRestaurar.Enabled = true;
                    foreach (DetalleCarrera dC in carrerasDeshabilitadas[lstCarreras.SelectedIndex].DetallesCarrera)
                    {
                        dgvDetalles.Rows.Add(dC.Materia.Codigo, dC.Materia.Nombre, dC.AnioCursado, dC.Cuatrimestre);
                    }
                }
            }
            else
            {
                btnDeshabilitar.Enabled = false;

                if (chkbMostrarCarrerasDeshabilitadas.Checked)
                {
                    btnRestaurar.Enabled = false;
                }
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async Task<bool> DeshabilitarCarrera(Carrera carreraABorrar)
        {
            string url = "http://localhost:5225/carrera";
            string carreraJson = JsonConvert.SerializeObject(carreraABorrar);

            var result = await ClienteSingleton.ObtenerInstancia().PutAsync(url, carreraJson);
            return result.Equals("true");
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Carrera carreraABorrar = carreras[lstCarreras.SelectedIndex];

            if (MessageBox.Show($"¿Seguro que quiere borrar la carrera " +
                    $"{carreraABorrar.NombreTitulo}?",
                    "Borrar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                carreraABorrar.Deshabilitada = true;


                if (/*await DeshabilitarCarrera(carreraABorrar)*/ servicio.DeshabilitarCarrera(carreraABorrar))
                {
                    lstCarreras.Items.Remove(carreraABorrar);
                    carreras.Remove(carreraABorrar);
                    carrerasDeshabilitadas.Add(carreraABorrar);
                    MessageBox.Show($"La carrera {carreraABorrar.NombreTitulo} ha sido enviada " +
                        $"a la papelera",
                    "Borrar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void chkbMostrarEnPapelera_CheckedChanged(object sender, EventArgs e)
        {
            btnRestaurar.Enabled = false;
            btnDeshabilitar.Enabled = false;
            dgvDetalles.Rows.Clear();
            if (chkbMostrarCarrerasDeshabilitadas.Checked)
            {
                btnRestaurar.Visible = true;

                CargarListBoxCarreras(carrerasDeshabilitadas);
            }
            else
            {
                btnRestaurar.Visible = false;
                CargarListBoxCarreras(carreras);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            Carrera carreraARestaurar = carrerasDeshabilitadas[lstCarreras.SelectedIndex];

            if (MessageBox.Show($"¿Seguro que quiere restaurar la carrera " +
               $"{carreraARestaurar.NombreTitulo}?",
               "Restaurar", MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lstCarreras.Items.Remove(carreraARestaurar);
                carrerasDeshabilitadas.Remove(carreraARestaurar);
                carreras.Add(carreraARestaurar);

                carreraARestaurar.Deshabilitada = false;

                servicio.DeshabilitarCarrera(carreraARestaurar);

                MessageBox.Show($"La carrera {carreraARestaurar.NombreTitulo} ha sido " +
                    $"restaurada",
                "Restaurar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
    }
}
