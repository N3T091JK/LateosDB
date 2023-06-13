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
    public partial class BSCategoria : Form
    {
        private List<Categoria> _listado;


        public BSCategoria()
        {
            InitializeComponent();
        }

        private void BSCategoria_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateCombo();
        }

        private void UpdateGrid()
        {
            _listado = CategoriaBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.IdCategoria,
                            Nombres = x.Nombre,
                            Litros = x.CantidaCategoria,
                            Estado = x.Estado.Nombre
                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdEstado";
            comboBox1.DataSource = EstadoBL.Instance.SellecALL();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
  
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Categoria entity = new Categoria()
            {
                Nombre = textBox2.Text.Trim(),
                CantidaCategoria = decimal.Parse(textBox3.Text),
                IdEstado = (int)comboBox1.SelectedValue
           };

            if (CategoriaBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
 



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {

                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Decimal Cantidad = (decimal)dataGridView1.CurrentRow.Cells[4].Value;
                int IdEstado = _listado.FirstOrDefault(x => x.IdCategoria.Equals(id)).IdEstado;
                Categoria entity = new Categoria()
                {
                    IdCategoria = id,
                    Nombre = nombre,
                    CantidaCategoria = Cantidad,
                    IdEstado = IdEstado


                };
                Agregar frm = new Agregar(entity);
                frm.ShowDialog();
                UpdateGrid();
            }
            
            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (CategoriaBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();
            }
        }
    }
}
