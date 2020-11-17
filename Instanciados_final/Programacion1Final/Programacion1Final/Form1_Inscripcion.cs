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
    public partial class Form1_Inscripcion : Form
    {
        DataTable Suscriptos = new DataTable();
        public Form1_Inscripcion()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGlobal.Apellido = txtApellido.Text;
            DataGlobal.Nombre = txtNombre.Text;
            DataGlobal.Dni = txtDni.Text;
            DataGlobal.Email = txtEmail.Text;
            DataGlobal.Pago = decimal.Parse(txtPago.Text);
            Form2_dtg FormularioDatos = new Form2_dtg();
            FormularioDatos.ShowDialog();

        }

        private void btnOtro_Click(object sender, EventArgs e)
        {
            Form2_dtg Obj = new Form2_dtg();
            Obj.OtroAdd();


            
        }
    }
}
