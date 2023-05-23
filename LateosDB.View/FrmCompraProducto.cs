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
    public partial class FrmCompraProducto : Form
    {
        private List<DetalleCompra> _listado1;
        private List<CompraProducto> _listado;
        public FrmCompraProducto()
        {
            InitializeComponent();
        }

        private void FrmCompraProducto_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            UpdateComboCompraProducto();
            UpdateComboFactura();
            UpdateComboDetallefacturaFactura();
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //----------------------------------------

        private void UpdateComboCompraProducto()
        {
            comboBox1.DisplayMember = "MarcaProducto";
            comboBox1.ValueMember = "IdCompraProducto";
            comboBox1.DataSource = CompraProductoBL.Instance.SellecALL();
        }

        private void UpdateComboFactura()
        {
            comboBox2.DisplayMember =  "Codigo";
            comboBox2.ValueMember ="IdFactura";
            comboBox2.DataSource = FacturaBL.Instance.SellecALL();
        }
        private void UpdateComboDetallefacturaFactura()
        {
            comboBox3.DisplayMember = "subTotal";
            comboBox3.ValueMember = "IdDetalleFactura";
            comboBox3.DataSource = DetalleFacturaBL.Instance.SellecALL();
        }


        private void UpdateGrid()
        {
            _listado1 = DetalleComprarBL.Instance.SellecALL();
            var query = from x in _listado1
                        select new
                        {
                            id = x.IdCompraProducto,
                            cantidad = x.CantidadProductos,
                            PrecioUnitarios = x.PrecioUnitario,
                            CompraProducto = x.CompraProductos.MarcaProducto
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DetalleCompra entity = new DetalleCompra()
            {
                CantidadProductos = Convert.ToInt32(numericUpDown1.Value),
                PrecioUnitario = decimal.Parse(textBox2.Text),
                IdCompraProducto = (int)comboBox1.SelectedValue
            };
            CompraRealizada Variable = new CompraRealizada()
            {
                Codigo = textBox1.Text.Trim(),
                IdDetalleFactura = (int)comboBox3.SelectedValue,
                IdFactura = (int)comboBox2.SelectedValue
            };
            if (DetalleComprarBL.Instance.Insert(entity))
            {
                if (CompraRealizadaBL.Instance.Insert(Variable))
                {

                    MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateGrid();
                    UpdateComboCompraProducto();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox5.Text = "";
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            _listado1 = DetalleComprarBL.Instance.SellecALL();
            var busqueda = from x in _listado1
                        select new
                        {
                            id = x.IdCompraProducto,
                            cantidad = x.CantidadProductos,
                            PrecioUnitarios = x.PrecioUnitario,
                            CompraProducto = x.CompraProductos.MarcaProducto
                        };
            var query = busqueda.Where(x => x.CompraProducto.ToLower().Contains(textBox5.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
