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
    public partial class FrmHistorial : Form
    {
        private List<Registro> _listado;
        public FrmHistorial()
        {
            InitializeComponent();
        }

        private void FrmHistorial_Load(object sender, EventArgs e)
        {

            UpdateGrid();
            UpdateComboCLiente();
            UpdateComboEmpleado();
            UpdateComboUsuario();
            UpdateComboRols();
        }
        private void UpdateComboCLiente()
        {
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdCliente";
            comboBox2.DataSource = ClienteBL.Instance.SellecALL();
        }

        private void UpdateComboEmpleado()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEmpleado";
            comboBox1.DataSource = EmpleadoBL.Instance.SellecALL();
        }

  
        private void UpdateComboUsuario()
        {
            comboBox4.DisplayMember = "Correo";
            comboBox4.ValueMember = "IdUsuario";
            comboBox4.DataSource = UsuarioBL.Instance.SelectAll();
        }




        private void UpdateComboRols()
        {
            comboBox6.DisplayMember = "Roles";
            comboBox6.ValueMember = "IdRol";
            comboBox6.DataSource = RolBL.Instance.SellecALL();
        }


        private void UpdateGrid()
        {
            _listado = RegistroBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdRegistro,
                            Nombres = x.Nombre,
                            Clientes = x.Cliente.Nombre,
                            Empleados = x.Empleado.Nombre,                  
                            Usuario = x.Usuarios.Correo,
  
                            Role = x.Rols.Roles,
                            


                        };
            dataGridView1.DataSource = query.ToList();
        }





        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registro entity = new Registro()
            {
                Nombre = textBox2.Text.Trim(),
                IdCliente = (int)comboBox2.SelectedValue,
                IdEmpleado = (int)comboBox1.SelectedValue,
                IdUsuario = (int)comboBox4.SelectedValue,
                IdRol = (int)comboBox6.SelectedValue,
    
            };

            if (RegistroBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string codigo = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                //decimal moneda = decimal.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                int IdCliente = _listado.FirstOrDefault(x => x.IdRegistro.Equals(id)).IdCliente;
                int IdEmpleados = _listado.FirstOrDefault(x => x.IdRegistro.Equals(id)).IdEmpleado;
                int IdUsuario = _listado.FirstOrDefault(x => x.IdRegistro.Equals(id)).IdUsuario;
                int IdRol = _listado.FirstOrDefault(x => x.IdRegistro.Equals(id)).IdRol;
                Registro entity = new Registro()
                {
                   IdRegistro = id,
                   Nombre = codigo,
                    IdCliente = IdCliente,
                    IdEmpleado = IdEmpleados,
                    IdUsuario = IdUsuario,      
                    IdRol = IdRol

                };
                //FrmEditarUsuario frm = new FrmEditarUsuario(entity);
                //frm.ShowDialog();
                //UpdateGrid();
            }

            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (RegistroBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }
        }
    }
}
