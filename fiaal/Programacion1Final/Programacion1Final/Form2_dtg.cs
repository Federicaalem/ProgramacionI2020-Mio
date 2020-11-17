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
        //Form1_Inscripcion OBJ = new Form1_Inscripcion();
        public Form2_dtg()
        {
            InitializeComponent();
            verListaCompleta();
            //OBJ.Close();
        }
      
        #region METODOS form2
        public void AgregarFilas()
        {
            DataSuscriptos.TableName = "Datos Subcriptores";


            DataSuscriptos.Rows.Add();
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][0] = DataGlobal.Nombre;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][1] = DataGlobal.Apellido;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][2] = DataGlobal.Dni;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][3] = DataGlobal.Contacto;
            DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][4] = DataGlobal.Pago;
            Calcular();

            dtgv.DataSource = DataSuscriptos;

            //OtroAdd();
        }
        public void Grabar()
        {
            AgregarFilas();
            DataSuscriptos.WriteXml(@"C:\Users\Usuario\Desktop\Suscriptos.xml");

        }
        public void verListaCompleta()
        {
            DataSuscriptos.TableName = "Datos Subcriptores";

            DataSuscriptos.Columns.Add("Nombre", typeof(string));
            DataSuscriptos.Columns.Add("Apellido", typeof(string));
            DataSuscriptos.Columns.Add("DNI", typeof(int));
            DataSuscriptos.Columns.Add("Contacto", typeof(string));
            DataSuscriptos.Columns.Add("Pagó", typeof(decimal));
            DataSuscriptos.Columns.Add("¿Adeuda inscripcion?", typeof(string));


            //dtgv.DataSource = DataSuscriptos;
            DataSuscriptos.ReadXml(@"C:\Users\Usuario\Desktop\Suscriptos.xml");
            dtgv.DataSource = DataSuscriptos;

            dtgv.AllowUserToAddRows = false;

            contadorSus();
        }
        public void contadorSus()
        {
            int Count = Convert.ToInt32(DataSuscriptos.Rows.Count.ToString());


            lblContador.Text = "Personas Subscriptas: " + Count;

        }
        public void Calcular()
        {

            if (DataGlobal.Pago < 3500)
            {
                decimal deuda = 3500 - DataGlobal.Pago;

                string deudaA = Convert.ToString(deuda);
            
                DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][5] = deudaA;
                //DataSuscriptos.Columns["¿Adeuda inscripcion?"].
              

            }
            if (DataGlobal.Pago == 3500)
            {
                DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][5] = "Completo";
                              
            }
            if (DataGlobal.Pago > 3500)
            {
                MessageBox.Show("Mas de lo requerido");
                DataSuscriptos.Rows[DataSuscriptos.Rows.Count - 1][5] = "Error";
            }


            //if (DataGlobal.Pago > 3500)
            //{
            //    MessageBox.Show("Mas de lo requerido");
            //}


        }


        #endregion

        #region EVENTO
        private void btnEliminarFila_Click(object sender, EventArgs e)
        {

            if (dtgv.CurrentRow.Index != -1)
            {
                dtgv.Rows.RemoveAt(dtgv.CurrentRow.Index);
                dtgv.RefreshEdit();
            }
            contadorSus();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = this.dtgv.CurrentRow.Cells[5].Value.ToString();

            if (data == "Completo")
            {
                lblEstado.Visible = true;
                lblEstado.BackColor = Color.Lime;
                lblEstado.Text = "Completo";

            }
            if (data != "Completo")
            {
                lblEstado.Visible = true;
                lblEstado.BackColor = Color.Red;
                lblEstado.Text = "Adeuda $" + data;

            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            lblEstado.Visible = false;
        }


        #endregion


        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            
            #region comentario
            //Busco por DNI
            //foreach (DataGridViewRow Row in dtgv.Rows)
            //{
            //    string strFila = Row.Index.ToString();
            //    string Valor = Convert.ToString(Row.Cells["Dni"].Value);

            //    if (Valor == this.txtBusqueda.Text)
            //    {
            //        dtgv.Rows[int.Parse(strFila)].DefaultCellStyle.BackColor = Color.BurlyWood;

            //    }
            //    else
            //    {
            //        dtgv.Rows[int.Parse(strFila)].DefaultCellStyle.BackColor = DefaultBackColor;
            //    }
            //}
            #endregion
            // BUSCO POR Dni SELECT
            foreach (DataGridViewRow Row in dtgv.Rows)
            {
                string ValorN = Convert.ToString(Row.Cells["Dni"].Value);

                if (ValorN == this.txtBusqueda.Text)
                {
                    //dtgv.Rows[dtgv.CurrentRow.Index].Selected= true;
                    //dtgv.Rows[dtgv.CurrentRow.Index].Selected = true;

                    //dtgv.Rows[].Selected = true;
                    //int strFilaa = dtgv.Rows[n].Index;
                    Row.Selected = true;

                    //dtgv.CurrentCell.RowIndex;

                }




                #region comentario
                //private void dtgv_SelectionChanged(object sender, EventArgs e)
                //{
                //    foreach (DataGridViewRow Row in dtgv.Rows)
                //    {
                //        string strFila = Row.Index.ToString();
                //        string Valor = Convert.ToString(Row.Cells["Nombre"].Value);

                //        if (Valor == this.txtBusqueda.Text)
                //        {
                //            dtgv.Rows[dtgv.CurrentRow.Index - 1].Selected = true;

                //        }
                //    }
                //}
                #endregion

            }

        }
    }
}




