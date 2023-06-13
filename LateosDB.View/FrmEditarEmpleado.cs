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
    public partial class FrmEditarEmpleado : Form
    {
        int id = 0;
        public FrmEditarEmpleado()
        {
            InitializeComponent();
        }

        public FrmEditarEmpleado(Empleado entity)
        {
            InitializeComponent();
            id = entity.IdEmpleado;
            textBox1.Text = entity.Nombre;
            textBox2.Text = entity.Apellido;
            textBox3.Text = entity.Direccion;
            
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
        private void button3_Click(object sender, EventArgs e)
        {
            Empleado entity = new Empleado()
            {
                IdEmpleado = id,
                Nombre = textBox1.Text.Trim(),
                Apellido = textBox2.Text.Trim(),
                Direccion = textBox3.Text.Trim(),
                FechaRegistro = dateTimePicker1.Value,
                IdEstado = (int)comboBox1.SelectedValue
            };
            if (id == 0)
            {
                if (EmpleadoBL.Instance.Insert(entity))
                {
                    MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (EmpleadoBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
        private void FrmEditarEmpleado_Load(object sender, EventArgs e)
        {

        }

      
    }
}
