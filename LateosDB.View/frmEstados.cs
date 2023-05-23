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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LateosDB.View
{
    public partial class frmEstados : Form
    {
        int Id = 0;
        private List<Estado> _listado;
        public frmEstados()
        {
            InitializeComponent();
        }



        private void frmEstados_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void UpdateGrid()
        {
            _listado = EstadoBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdEstado,
                            Nombres = x.Nombre

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = EstadoBL.Instance.SellecALL();

            var busqueda = from x in _listado
                           select new
                           {
                               IdEstados = x.IdEstado,
                               Nombres = x.Nombre
                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox2.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Estado entity = new Estado()
            {
                IdEstado = Id,
                Nombre = textBox1.Text.Trim(),

            };
            if (EstadoBL.Instance.Insert(entity))
            {
                MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                Estado entity = new Estado()
                {
                    IdEstado = id,
                    Nombre = nombre,

                };
             FrmEditarEstado frm = new FrmEditarEstado(entity);
            frm.ShowDialog();
            UpdateGrid();
            }
          
            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (EstadoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }




        }


    }
}
