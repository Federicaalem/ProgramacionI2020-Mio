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
        DataTable DataSuscriptos = new DataTable();

        public Form1_Inscripcion()
        {
            InitializeComponent();

        }

        //button incripcion
        private void button1_Click(object sender, EventArgs e)
        {
            #region comentario
            //Suscribirse

            //Los datos que entren por usuario se guardaran en las variables de la clase DataGlobal
            //Dsp de eso instancio la clase Form2 para llamar a sus metodos y propiedades

            #endregion

            
                try
                {
                    DataGlobal.Apellido = txtApellido.Text;
                    DataGlobal.Nombre = txtNombre.Text;
                    DataGlobal.Dni = int.Parse(txtDni.Text);
                    DataGlobal.Contacto = txtContacto.Text;
                    DataGlobal.Pago = decimal.Parse(txtPago.Text);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }




            Form2_dtg Obj = new Form2_dtg();
            //Obj.Calcular();
            Obj.Grabar() ;
            Limpiar();
            MessageCreate mess = new MessageCreate();
            mess.Show();
           
            //Obj.Grabar();
            //Limpiar();
            //MessageCreate messageCreate = new MessageCreate();
            //messageCreate.ShowDialog();
           
          


        }


        #region METODOS
        public void Limpiar()
        {
            txtApellido.Clear();
            txtDni.Clear();
            txtContacto.Clear();
            txtNombre.Clear();
            txtPago.Clear();
        }



        #endregion

        #region EVENTOS

        #region Referencian en txtbox
      
        private void txtContacto_Enter(object sender, EventArgs e)
        {//activo
            if (txtContacto.Text == "Telefono o Correo electronico")
            {
                txtContacto.Text = "";
                txtContacto.ForeColor = Color.Black;
            }

        }

        private void txtContacto_Leave(object sender, EventArgs e)
        {//inactivo
            if (txtContacto.Text == "")
            {
                txtContacto.Text = "Telefono o Correo electronico";
                txtContacto.ForeColor = Color.Silver;
            }
        }

        private void txtPago_Enter(object sender, EventArgs e)
        {
            //activo
            if (txtPago.Text == "$")
            {
                txtPago.Text = "";
                txtPago.ForeColor = Color.Black;
            }
        }

        private void txtPago_Leave(object sender, EventArgs e)
        {
            //inactivo
            if (txtPago.Text =="")
            {
                txtPago.Text = "$";
                txtPago.ForeColor = Color.Silver;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form2_dtg datagrid = new Form2_dtg();
           datagrid.ShowDialog();
        }





        #endregion

        #region Validacion de texboxs           


        #endregion
        #endregion

    }


}