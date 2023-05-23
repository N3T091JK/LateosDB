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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class FrmEditarCliente : Form
    {
        int id = 0;
        public FrmEditarCliente()
        {
            InitializeComponent();
        }
        public FrmEditarCliente(Cliente entity)
        {
            InitializeComponent();
            id = entity.IdCliente;
            textBox1.Text = entity.Nombre;          
            dateTimePicker1.Value = entity.FechaRegistro;
            UpdateCombo();
            comboBox1.SelectedValue = entity.IdEstado;

        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Cliente entity = new Cliente()
            {
                IdCliente = id,
                Nombre = textBox1.Text.Trim(),
                FechaRegistro = dateTimePicker1.Value,
                IdEstado = (int)comboBox1.SelectedValue
            };
            if (id == 0)
            {
                if (ClienteBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (ClienteBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }

        private void FrmEditarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
