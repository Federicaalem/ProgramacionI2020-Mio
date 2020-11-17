using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programacion1Final
{
    public partial class Form2_dtg : Form
    {
        DataTable DataSuscriptos = new DataTable();
        Form1_Inscripcion Datos = new Form1_Inscripcion();
        public Form2_dtg()
        {
            InitializeComponent();
            abrirDtg();
        }

        public void abrirDtg()
        {
            DataSuscriptos.TableName = "Datos Subcriptores";

            DataSuscriptos.Columns.Add("Nombre", typeof(string));
            DataSuscriptos.Columns.Add("Apellido", typeof(string));
            DataSuscriptos.Columns.Add("DNI", typeof(int));
            DataSuscriptos.Columns.Add("Contacto", typeof(string));
            DataSuscriptos.Columns.Add("Pago", typeof(decimal));

            dtgv.DataSource = DataSuscriptos;


        }
        public void Filas()
        {
            DataSuscriptos.TableName = "Datos Subcriptores";
            dtgv.DataSource = DataSuscriptos;

            DataSuscriptos.Rows.Add();
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count -1]["Nombre"] = DataGlobal.Nombre;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count -1]["Apellido"] = DataGlobal.Apellido;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count -1]["DNI"] = DataGlobal.Dni;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count -1]["Contacto"] = DataGlobal.Email;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count -1]["Pago"] = DataGlobal.Pago;
        }

        private void btnFilas_Click(object sender, EventArgs e)
        {
            Filas();
        }

        public void OtroAdd()
        {
             dtgv.Rows.Add();

            dtgv.Rows[0].Cells[0].Value = DataGlobal.Apellido;
            dtgv.Rows[1].Cells[1].Value = DataGlobal.Nombre;
            dtgv.Rows[2].Cells[2].Value = DataGlobal.Dni;
            dtgv.Rows[3].Cells[3].Value = DataGlobal.Email;
            dtgv.Rows[4].Cells[4].Value = DataGlobal.Pago;

            DataGlobal.Apellido = "";
            DataGlobal.Nombre = "";
            DataGlobal.Dni = "";
            DataGlobal.Email = "";
            DataGlobal.Pago = Convert.ToDecimal("");
        }
    }
}
