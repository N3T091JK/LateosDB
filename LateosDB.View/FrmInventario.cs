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

        private void button1_Click(object sender, EventArgs e)
        {
            Inventario entity = new Inventario()
            {
                Stock = Convert.ToInt32(numericUpDown1.Value),
            };

            if (InventarioBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }


        private void UpdateGrid()
        {
            _listado = InventarioBL.Instance.SellecALL();
            var query2 = from x in _listado
                         select new
                         {
                             id = x.IdInventario,
                             Nombres = x.Stock
                             

                         };
            dataGridView1.DataSource = query2.ToList();
        }




    }
}
