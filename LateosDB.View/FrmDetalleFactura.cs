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
    public partial class FrmDetalleFactura : Form
    {
        private List<DetalleFactura> _listado;
        public FrmDetalleFactura()
        {
            InitializeComponent();
        }

        private void FrmDetalleFactura_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateComboProducto();

        }

        private void UpdateComboProducto()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdProducto";
            comboBox1.DataSource = ProductoBL.Instance.SellecALL();
        }

        private void UpdateGrid()
        {
            _listado = DetalleFacturaBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdDetalleFactura,
                           cantidad = x.Cantidad,
                           subTotales = x.subTotal,
                            Productos = x.Productos.Nombre

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleFactura entity = new DetalleFactura()
            {
                
                subTotal = decimal.Parse(textBox1.Text),
                Cantidad = Convert.ToInt32(numericUpDown1.Value),
                IdProducto = (int)comboBox1.SelectedValue,
                
            };

            if (DetalleFacturaBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }
    }
}
