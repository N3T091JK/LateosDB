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
    public partial class FrmInventario : Form
    {
        private List<Inventario> _listado;

        public FrmInventario()
        {
            InitializeComponent();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            UpdateGrid();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
  
        private void UpdateGrid()
        {
            _listado = InventarioBL.Instance.SelectAll();
            var query = from x in _listado
                        select new
                        {
                           Id = x.IdInventario,
                           Cantidades = x.cantidad,
                            //Producto = x.Productos.Precio.ToString()
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           

        }
        //int id = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                int Cantidad = (int)dataGridView1.CurrentRow.Cells[3].Value;
                int IdProducto = _listado.FirstOrDefault(x => x.IdInventario.Equals(id)).IdProduto;


                Inventario entity = new Inventario()
                {
                  IdInventario = id,
                  cantidad = Cantidad,
                  IdProduto = IdProducto


                };
                EdiatrInventario frm = new EdiatrInventario(entity);
                frm.ShowDialog();
                UpdateGrid();
            }

            

            
        }



    }
}
