using LateosDB.BusinessLogic;
using LateosDB.Entities;
using System;
using System.Collections;
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
    public partial class FrmUsuario : Form
    {
        int Id = 0;
        private List<Usuario> _listado;
        public FrmUsuario()
        {
            InitializeComponent();
            UpdateGrid();
            UpdateCombo();
            UpdateComboEstado();

        }
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateCombo();
            UpdateComboEstado();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Roles";
            comboBox1.ValueMember = "IdRol";
            comboBox1.DataSource = RolBL.Instance.SellecALL();
        }
        private void UpdateComboEstado()
        {
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdEstado";
            comboBox2.DataSource = EstadoBL.Instance.SellecALL();
        }
        private void UpdateGrid()
        {
            _listado = UsuarioBL.Instance.SelectAll();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdUsuario,

                            correos = x.Correo,
                            Claves = x.Password,
                            estados = x.Estados.Nombre,
                            Rolt = x.Rols.Roles


                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            _listado = UsuarioBL.Instance.SelectAll();

            var busqueda = from x in _listado
                           select new
                           {
                               Id = x.IdUsuario,
                               correos = x.Correo,
                               Claves = x.Password,
                               estados = x.Estados,                            
                               Rolt = x.Rols.Roles
                           };
            var query = busqueda.Where(x => x.correos.ToLower().Contains(textBox4.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }


            private void button3_Click(object sender, EventArgs e)
            {
            Usuario entity = new Usuario()
            {

                Correo = textBox3.Text.Trim(),
                Password = textBox2.Text.Trim(),
                IdEstado = (int)comboBox1.SelectedValue,
                IdRol = (int)comboBox2.SelectedValue
            };

            if (UsuarioBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox2.Text = "";
                textBox3.Text = "";
                UpdateGrid();
            }
        }
            //MontoTotal = decimal.Parse(textBox2.Text),
            private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string correos = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                byte Password = (byte)dataGridView1.CurrentRow.Cells[5].Value;
                //decimal moneda = decimal.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                int IdRol = _listado.FirstOrDefault(x => x.IdUsuario.Equals(id)).IdRol;
                Usuario entity = new Usuario()
                {
                    IdUsuario = id,
                    Correo = correos,
                    //Password = Password,
                    IdRol = IdRol

                };
                FrmEditarUsuario frm = new FrmEditarUsuario(entity);
                frm.ShowDialog();
                //UpdateGrid();
            }

            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (UsuarioBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }

        }
        
    }
}
