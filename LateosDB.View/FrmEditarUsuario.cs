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
    public partial class FrmEditarUsuario : Form
    {
        int id = 0;
        public FrmEditarUsuario()
        {
            InitializeComponent();
        }
        public FrmEditarUsuario(Usuario entity)
        {
            InitializeComponent();
            id = entity.IdUsuario;

            textBox2.Text = entity.Correo;
            //textBox3.Text = entity.Password;
            UpdateCombo();
            comboBox1.SelectedValue = entity.IdRol;
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Roles";
            comboBox1.ValueMember = "IdRol";
            comboBox1.DataSource = RolBL.Instance.SellecALL();
        }
        private void FrmEditarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usuario entity = new Usuario()
            {
                IdUsuario = id,

                Correo = textBox2.Text.Trim(),
                IdRol = (int)comboBox1.SelectedValue,
                //Password = byte.Parse(textBox3.Text.TrimStart()
         
            };
            if (id == 0)
            {
                if (UsuarioBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (UsuarioBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
    }
}
