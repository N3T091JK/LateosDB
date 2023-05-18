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
            UpdateGrid1();
        }

        private void UpdateGrid1()
        {
            _listado = CompraProductoBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.IdCompraProducto,
                            MarcaProductos = x.MarcaProducto,
                            Cantidades = x.Cantidad,
                            Fecha = x.FechaRegistro
                        };
            dataGridView2.DataSource = query.ToList();
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

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            CompraProducto entity = new CompraProducto()
            {
                
                MarcaProducto = textBox1.Text.Trim(),
                Cantidad = Convert.ToInt32(numericUpDown1.Value),
                FechaRegistro = dateTimePicker1.Value
                
            };

            if (CompraProductoBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                UpdateComboCompraProducto();
                UpdateGrid1();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";              
            }
        }
        //----------------------------------------

        private void UpdateComboCompraProducto()
        {
            comboBox1.DisplayMember = "MarcaProducto";
            comboBox1.ValueMember = "IdCompraProducto";
            comboBox1.DataSource = CompraProductoBL.Instance.SellecALL();
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
                            Descuentos = x.Descuento,
                            CompraProducto = x.CompraProductos.MarcaProducto
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DetalleCompra entity = new DetalleCompra()
            {
                CantidadProductos = textBox4.Text.Trim(),
                PrecioUnitario = decimal.Parse(textBox2.Text),
                Descuento = decimal.Parse(textBox3.Text),
                IdCompraProducto = (int)comboBox1.SelectedValue
            };

            if (DetalleComprarBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                UpdateComboCompraProducto();
                UpdateGrid1();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
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
                            Descuentos = x.Descuento,
                            CompraProducto = x.CompraProductos.MarcaProducto
                        };
            var query = busqueda.Where(x => x.cantidad.ToLower().Contains(textBox5.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }



    }
}
