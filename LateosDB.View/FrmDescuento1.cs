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
    public partial class FrmDescuento1 : Form
    {
        private List<Descuento> _listado;
        public FrmDescuento1()
        {
            
            InitializeComponent();
        }

        private void FrmDescuento1_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            _listado = DescuentoBL.Instance.SellecALL();
            var query2 = from x in _listado
                         select new
                         {
                             id = x.IdDescuento,
                             Nombres = x.Nombre,
                             cantidades = x.Porcentaje
                         };
            dataGridView1.DataSource = query2.ToList();
        }

 


        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Descuento entity = new Descuento()
            {
                Nombre = textBox1.Text.Trim(),
                Porcentaje = decimal.Parse(textBox2.Text)

            };

            if (DescuentoBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                textBox1.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {

                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();             
                decimal Porcentajes = decimal.Parse(textBox2.Text);
                //entity.Porcentaje = decimal.Parse(textBox2.Text);

                Descuento entity = new Descuento()
                {
                    IdDescuento = id,
                    Nombre = nombre,
                    Porcentaje = Porcentajes


                };
                FrmEditarPorcentaje frm = new FrmEditarPorcentaje(entity);
                frm.ShowDialog();
                UpdateGrid();
            }

            if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
            {
                int id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    if (DescuentoBL.Instance.Delete(id))
                    {
                        MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                UpdateGrid();

            }
        }
    }
}
