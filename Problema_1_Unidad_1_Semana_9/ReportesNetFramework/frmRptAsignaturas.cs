using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportesNetFramework
{
    public partial class frmRptAsignaturas : Form
    {
        public frmRptAsignaturas()
        {
            InitializeComponent();
        }

        private async void frmRptAsignaturas_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            string url = "http://localhost:5225/getTabla";
            var data = await ClienteSingleton.ObtenerInstancia().GetAsync(url);
            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(data);
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dataTable));
            this.reportViewer1.RefreshReport();
        }
    }
}
