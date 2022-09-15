using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Problema_1_Unidad_1.Dominio;
using Problema_1_Unidad_1.AccesoDatos;

namespace Problema_1_Unidad_1
{
    public partial class frmNuevaCarrera : Form
    {
        Carrera carrera;
        AccesoBD accesoDB = new AccesoBD();

        public frmNuevaCarrera()
        {
            InitializeComponent();
            carrera = new Carrera();
        }

        private void frmNuevaCarrera_Load(object sender, EventArgs e)
        {
            DataTable tabla = accesoDB.HacerConsultaConSP("pa_recuperar_asignaturas");
            cboMaterias.DataSource = tabla;
            cboMaterias.ValueMember = tabla.Columns[0].ColumnName;
            cboMaterias.DisplayMember = tabla.Columns[1].ColumnName;
            cboMaterias.SelectedIndex = -1;
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (txtNombreCarrera.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre de la carrera!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            if (cboMaterias.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar una Materia!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            if (txtAnioCursado.Text == "")
            {
                MessageBox.Show("Debe ingresar un año de cursado valido!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            if (rbnPrimerCuatrimestre.Checked == false && rbnSegundoCuatrimestre.Checked == false)
            {
                MessageBox.Show("Debe seleccionar un cuatrimestre!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            foreach(DetalleCarrera dc in carrera.DetallesCarrera)
            {
                if (dc.Materia.Nombre == cboMaterias.Text)
                {
                    MessageBox.Show("Esa materia ya existe en esta carrera!",
                    "Control", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                    return;
                }
            }

            Asignatura materia = new Asignatura();
            materia.Codigo = Convert.ToInt32(cboMaterias.SelectedValue);
            materia.Nombre = cboMaterias.Text;

            int anioCursado = int.Parse(txtAnioCursado.Text);
            int cuatrimestre = 2;
            if (rbnPrimerCuatrimestre.Checked)
            {
                cuatrimestre = 1;
            }

            DetalleCarrera detalle = new DetalleCarrera(anioCursado, cuatrimestre, materia);

            carrera.AgregarDetalle(detalle);

            dgvDetalles.Rows.Add(materia.Codigo, materia.Nombre, anioCursado, cuatrimestre);
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                carrera.EliminarDetalle(dgvDetalles.CurrentCell.RowIndex);
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
            }
        }

        private void txtNombreCarrera_TextChanged(object sender, EventArgs e)
        {
            carrera.NombreTitulo = txtNombreCarrera.Text;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool ok = true;

            if (txtNombreCarrera.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe ingresar el nombre de la carrera!",
                "Control", MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
                return;
            }

            int cod_carrera = accesoDB.InsertarCarreraConSP("pa_insertar_carrera",
                carrera);
            if (cod_carrera != -1)
            {
                if (carrera.DetallesCarrera.Count != 0)
                {
                    if(!accesoDB.InsertarDetallesCarreraConSP("pa_insertar_detalleCarrera", carrera))
                    {
                        MessageBox.Show("Error, no se pudo cargar los detalles de la carrera", "Insertar",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ok = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Error, no se pudo cargar la carrera", "Insertar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ok = false;
            }
            
            if (ok)
            {
                MessageBox.Show("La carrera se inserto con exito", "Insertar",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
     
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
