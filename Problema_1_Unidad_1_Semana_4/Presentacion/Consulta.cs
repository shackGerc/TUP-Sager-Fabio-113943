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
using Problema_1_Unidad_1.Dominio;

namespace Problema_1_Unidad_1
{
    public partial class frmConsultar : Form
    {
        AccesoBD accesoDB;
        List<Carrera> carreras;
        List<Carrera> carrerasDeshabilitadas;

        public frmConsultar()
        {
            InitializeComponent();
            accesoDB = new AccesoBD();
            carreras = new List<Carrera>();
            carrerasDeshabilitadas = new List<Carrera>();
        }

        public void CargarListaCarreras()
        {
            DataTable tablaCarreras = accesoDB.HacerConsultaConSP("pa_consultar_carreras");
            DataTable tablaDetalles = accesoDB.HacerConsultaConSP("pa_consultar_detalleCarrera");
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
                else
                {
                    carrerasDeshabilitadas.Add(carrera);
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

        private void Consulta_carreras_Load(object sender, EventArgs e)
        {
            CargarListaCarreras();
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Carrera carreraABorrar = carreras[lstCarreras.SelectedIndex];

            if (MessageBox.Show($"¿Seguro que quiere borrar la carrera " +
                    $"{carreraABorrar.NombreTitulo}?",
                    "Borrar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    lstCarreras.Items.Remove(carreraABorrar);
                    carreras.Remove(carreraABorrar);
                    carrerasDeshabilitadas.Add(carreraABorrar);

                    carreraABorrar.Deshabilitada = true;

                    accesoDB.actualizarCarreraConSP("pa_actualizar_carrera", carreraABorrar);


                    MessageBox.Show($"La carrera {carreraABorrar.NombreTitulo} ha sido enviada " +
                        $"a la papelera",
                    "Borrar", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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

                accesoDB.actualizarCarreraConSP("pa_actualizar_carrera", carreraARestaurar);


                MessageBox.Show($"La carrera {carreraARestaurar.NombreTitulo} ha sido " +
                    $"restaurada",
                "Restaurar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }
    }
}
