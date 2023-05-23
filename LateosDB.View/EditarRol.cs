using LateosDB.BusinessLogic;
using LateosDB.DataAccess;
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
    public partial class EditarRol : Form
    {
        int id = 0;
        public EditarRol()
        {
            InitializeComponent();
            UpdateCombo();
        }
        
        public EditarRol(Rol entity)
        {
            InitializeComponent();
            id = entity.IdRol;
            textBox1.Text = entity.Roles;
            UpdateCombo();
            comboBox1.SelectedValue = entity.IdEstado;
        }
        private void EditarRol_Load(object sender, EventArgs e)
        {

        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }
        private void button1_Click(object sender, EventArgs e)
        {
   
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
         Rol entity = new Rol()
            {
                IdRol = id,
                Roles = textBox1.Text.Trim(),
                IdEstado = (int)comboBox1.SelectedValue
            };
            if (id == 0)
            {
                if (RolBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (RolBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
    }
}
