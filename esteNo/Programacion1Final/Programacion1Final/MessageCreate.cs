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
    public partial class MessageCreate : Form
    {
        public MessageCreate()
        {
            InitializeComponent();
        }

        //Hice un message box personalizado, (un form nuevo con su clase)
        //la pregunta del messagebox es (¿Quieres suscribir a otro usuario?)
        //Si la respuesta es Si, vuelve al form principal para la suscripcion
        // pero el tema es que se me abre otro formulario (datagrid) donde tengo
        // la lista de suscriptores.

        //El tema es que quiero que cuando el usuario haga click en SI, evite que
        //ese formulario(segundario(datagrid)) no se habra hasta que diga NO(no quiero volver a suscrbir a nadie)

        //e hice este codigo pero no funciona
        // lo hice desde la misma clase donde esta mi datagrid pero nose cmo hacer
        //quise usar el FORMCLOSED pero nose su sintaxis.
        public void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();      
           

            Form2_dtg obj = new Form2_dtg();
            obj.ShowDialog();
        }

        public void btnSi_Click(object sender, EventArgs e)
        {                     
            this.Close();
            Form1_Inscripcion form1_Inscripcion = new Form1_Inscripcion();
            form1_Inscripcion.ShowDialog();
        }

    }
}
