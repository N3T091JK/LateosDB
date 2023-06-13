using LateosDB.BusinessLogic;
using LateosDB.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LateosDB.View
{
    public partial class InicioLog : Form
    {
        public InicioLog()
        {
            InitializeComponent();
        }
        public void frm_closing(object sender, FormClosingEventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";

            this.Show();


        }
        private void Salir_Click(object sender, EventArgs e)
        {

        }

        private void InicioLog_Load(object sender, EventArgs e)
        {

        }

        private void InicioLog_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Usuario oPersona = UsuarioBL.Instance.SelectAll().Where(p => p.Correo == textBox2.Text && p.Rols.IdRol != 3).FirstOrDefault();
            if (oPersona != null)
            {
                MessageBox.Show("La contraseña y correo son correcto", "Bienvenidos", MessageBoxButtons.OK);
                Cero frm = new Cero();
                frm.Show();
                this.Hide();
                frm.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("No se econtraron coincidencias del usuario o contraseña, verifica nuevamente tus credenciales o ponte en contacto con el administrador", "Mensaje", MessageBoxButtons.OK);
            }

        }
    }
}
