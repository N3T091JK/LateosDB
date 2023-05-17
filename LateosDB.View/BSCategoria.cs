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
    }
}
