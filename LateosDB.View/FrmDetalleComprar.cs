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
    public partial class FrmDetalleComprar : Form
    {
        private List<DetalleCompra> _listado;
        public FrmDetalleComprar()
        {
            InitializeComponent();
        }

        private void FrmDetalleComprar_Load(object sender, EventArgs e)
        {
            UpdateComboCompraProducto();
            UpdateGrid();
        }
        private void UpdateComboCompraProducto()
        {
            comboBox1.DisplayMember = "MarcaProducto";
            comboBox1.ValueMember = "IdCompraProducto";
            comboBox1.DataSource = CompraProductoBL.Instance.SellecALL();
        }
        private void UpdateGrid()
        {
            _listado = DetalleComprarBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.IdCompraProducto,
                            cantidad = x.CantidadProductos,
                            PrecioUnitarios = x.PrecioUnitario,
                            Descuentos = x.Descuento,                  
                            CompraProducto = x.CompraProductos.MarcaProducto
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DetalleCompra entity = new DetalleCompra()
            {
                CantidadProductos = textBox1.Text.Trim(),
                PrecioUnitario = decimal.Parse(textBox2.Text),
                Descuento = decimal.Parse(textBox3.Text),              
                IdCompraProducto = (int)comboBox1.SelectedValue
            };

            if (DetalleComprarBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }
    }
}
